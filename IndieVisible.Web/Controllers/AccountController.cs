using IndieVisible.Application;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Infra.CrossCutting.Identity.Models.AccountViewModels;
using IndieVisible.Infra.CrossCutting.Identity.Services;
using IndieVisible.Web.Controllers.Base;
using IndieVisible.Web.Enums;
using IndieVisible.Web.Exceptions;
using IndieVisible.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using static IndieVisible.Infra.CrossCutting.Identity.Services.EmailSenderExtensions;

namespace IndieVisible.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : SecureBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IProfileAppService profileAppService;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        private readonly IUserPreferencesAppService userPreferencesAppService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IProfileAppService profileAppService,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            IUserPreferencesAppService userPreferencesAppService) : base()
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.profileAppService = profileAppService;
            _emailSender = emailSender;
            _logger = logger;
            this.userPreferencesAppService = userPreferencesAppService;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        [Route("/account/login")]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded && !string.IsNullOrWhiteSpace(model.UserName))
                {
                    ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);

                    if (user != null && !string.IsNullOrWhiteSpace(user.UserName))
                    {
                        SetProfileOnSession(new Guid(user.Id), user.UserName);

                        await SetStaffRoles(user);

                        SetPreferences(user);
                    }

                    SetCache(user);

                    _logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }

                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            ApplicationUser user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load two-factor authentication user.");
            }

            LoginWithTwoFactorViewModel model = new LoginWithTwoFactorViewModel { RememberMe = rememberMe };
            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWith2fa(LoginWithTwoFactorViewModel model, bool rememberMe, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            string authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            ApplicationUser user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load two-factor authentication user.");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load two-factor authentication user.");
            }

            string recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/account/register")]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            MvcRegisterViewModel model = new MvcRegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MvcRegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                user.UserName = model.UserName;

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ProfileViewModel profile = profileAppService.GenerateNewOne(ProfileType.Personal);
                    profile.UserId = new Guid(user.Id);
                    profileAppService.Save(CurrentUserId, profile);

                    await SetStaffRoles(user);

                    SetPreferences(user);

                    _logger.LogInformation("User created a new account with password.");

                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            string redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            AuthenticationProperties properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);

                string email = info.Principal.FindFirstValue(ClaimTypes.Email);
                ApplicationUser existingUser = await _userManager.FindByEmailAsync(email);

                if (existingUser != null)
                {
                    SetProfileOnSession(new Guid(existingUser.Id), existingUser.UserName);

                    await SetStaffRoles(existingUser);

                    SetPreferences(existingUser);
                }

                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                ViewData["ButtonText"] = SharedLocalizer["Register"];
                string text = "You've successfully authenticated with your external account. Please choose a username to use and click the Register button to finish logging in.";

                string email = info.Principal.FindFirstValue(ClaimTypes.Email);

                MvcExternalLoginViewModel model = new MvcExternalLoginViewModel { Email = email };

                ApplicationUser existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    model.UserExists = true;
                    model.Username = existingUser.UserName;
                    text = "Oh! It looks like you already have a user registered here with us. Check your info below and confirm to link your account to your external account.";

                    ViewData["ButtonText"] = SharedLocalizer["Link Acounts"];
                }

                ViewData["RegisterText"] = SharedLocalizer[text];

                return View("ExternalLogin", model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(MvcExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result;

                // Get the information about the user from the external login provider
                ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new CustomApplicationException("Error loading external login information during confirmation.");
                }

                ApplicationUser user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                ApplicationUser existingUser = await _userManager.FindByEmailAsync(model.Email);

                if (existingUser != null)
                {
                    user = existingUser;
                }
                else
                {
                    await _userManager.CreateAsync(user);
                }

                result = await _userManager.AddLoginAsync(user, info);

                if (result.Succeeded)
                {
                    await SetStaffRoles(user);

                    SetPreferences(user);

                    Guid userGuid = new Guid(user.Id);
                    ProfileViewModel profile = profileAppService.GetByUserId(userGuid, ProfileType.Personal);
                    if (profile == null)
                    {
                        profile = profileAppService.GenerateNewOne(ProfileType.Personal);
                        profile.UserId = userGuid;
                    }

                    profile.Name = info.Principal.FindFirstValue(ClaimTypes.Name);

                    await SetProfileImage(info, user, profile);

                    profileAppService.Save(CurrentUserId, profile);

                    SetProfileOnSession(new Guid(user.Id), user.UserName);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);

                    return RedirectToLocal(returnUrl);
                }

                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userId}'.");
            }
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
                bool emailAlreadyConfirmed = await _userManager.IsEmailConfirmedAsync(user);
                if (user == null || !emailAlreadyConfirmed)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                string code = await _userManager.GeneratePasswordResetTokenAsync(user);
                string callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);

                await _emailSender.SendEmailPasswordResetAsync(model.Email, callbackUrl);
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new CustomApplicationException("A code must be supplied for password reset.");
            }
            ResetPasswordViewModel model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            IdentityResult result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            AddErrors(result);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ValidateUserName(string UserName, string Email)
        {
            OperationResultVo result;

            try
            {
                ApplicationUser user = await UserManager.FindByNameAsync(UserName);

                if (user == null)
                {
                    return Json(true);
                }
                else
                {
                    if (user.Email.Equals(Email))
                    {
                        return Json(true);
                    }

                    return Json(false);
                }
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(false);
                _logger.Log(LogLevel.Error, ex, ex.Message);
            }

            return Json(result);
        }

        private void SetPreferences(ApplicationUser user)
        {
            Application.ViewModels.UserPreferences.UserPreferencesViewModel preferences = userPreferencesAppService.GetByUserId(new Guid(user.Id));
            if (preferences == null || preferences.Id == Guid.Empty)
            {
                RequestCulture requestLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture;
                SupportedLanguage lang = base.SetLanguageFromCulture(requestLanguage.UICulture.Name);

                SetCookieValue(SessionValues.DefaultLanguage, lang.ToString(), 7);
            }
            else
            {
                SetCookieValue(SessionValues.DefaultLanguage, preferences.UiLanguage.ToString(), 7);
            }
        }

        #region Helpers

        // HACK replace by default admin user
        private async Task SetStaffRoles(ApplicationUser user)
        {
            await _userManager.AddToRoleAsync(user, Roles.Member.ToString());

            if (user.UserName.Equals("programad") || user.UserName.Equals("cadko"))
            {
                await _userManager.AddToRoleAsync(user, Roles.Administrator.ToString());
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        private async Task SetProfileImage(ExternalLoginInfo info, ApplicationUser user, ProfileViewModel profile)
        {
            if (string.IsNullOrWhiteSpace(profile.ProfileImageUrl) || profile.ProfileImageUrl.Equals(Constants.DefaultAvatar))
            {
                string imageFileName = await GetExternalProfilePicture(info, user);

                profile.ProfileImageUrl = imageFileName.Equals(Constants.DefaultAvatar) ? imageFileName : Constants.DefaultImagePath + imageFileName;
            }
        }

        private async Task<string> GetExternalProfilePicture(ExternalLoginInfo info, ApplicationUser user)
        {
            string imageUrl = Constants.DefaultAvatar;

            byte[] thumbnailBytes = null;
            if (info.LoginProvider == "Facebook")
            {
                string nameIdentifier = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                string thumbnailUrl = $"https://graph.facebook.com/{nameIdentifier}/picture?type=large";

                using (HttpClient httpClient = new HttpClient())
                {
                    string filename = user.Id + "_" + ProfileType.Personal.ToString();
                    thumbnailBytes = await httpClient.GetByteArrayAsync(thumbnailUrl);

                    imageUrl = base.UploadImage(new Guid(user.Id), BlobType.ProfileImage, filename, thumbnailBytes);
                }
            }

            return imageUrl;
        }

        private void SetCache(ApplicationUser user)
        {
            Guid key = new Guid(user.Id);
            ProfileViewModel cachedProfile = profileAppService.GetWithCache(key);

            if (cachedProfile == null)
            {
                ProfileViewModel profile = profileAppService.GetByUserId(key, ProfileType.Personal);
                if (profile != null)
                {
                    profileAppService.SetCache(key, profile);
                }
            }
        }

        #endregion Helpers
    }
}