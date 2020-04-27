using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Infra.CrossCutting.Abstractions;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Infra.CrossCutting.Identity.Models.ManageViewModels;
using IndieVisible.Infra.CrossCutting.Identity.Services;
using IndieVisible.Web.Areas.Member.Controllers.Base;
using IndieVisible.Web.Enums;
using IndieVisible.Web.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace IndieVisible.Web.Areas.Member.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class PreferencesController : MemberBaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly INotificationSender notificationSender;
        private readonly ILogger logger;
        private readonly UrlEncoder urlEncoder;

        private readonly IUserPreferencesAppService userPreferencesAppService;

        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private const string RecoveryCodesKey = nameof(RecoveryCodesKey);

        public PreferencesController(
            UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , INotificationSender notificationSender
            , ILogger<PreferencesController> logger
            , UrlEncoder urlEncoder
            , IMapper mapper
            , IUserPreferencesAppService userPreferencesAppService) : base()
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.notificationSender = notificationSender;
            this.logger = logger;
            this.urlEncoder = urlEncoder;

            this.userPreferencesAppService = userPreferencesAppService;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            IndexViewModel model = new IndexViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            string email = user.Email;
            if (model.Email != email)
            {
                IdentityResult setEmailResult = await userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new CustomApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            string phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                IdentityResult setPhoneResult = await userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new CustomApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            StatusMessage = "Your profile has been updated";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Languages()
        {
            UserPreferencesViewModel vm = userPreferencesAppService.GetByUserId(CurrentUserId);
            vm.StatusMessage = StatusMessage;

            return await Task.Run(() => View(vm));
        }

        [HttpPost]
        public IActionResult Languages(UserPreferencesViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            try
            {
                vm.UserId = CurrentUserId;

                userPreferencesAppService.Save(CurrentUserId, vm);

                SetPreferencesCookies(vm);

                SetAspNetCultureCookie(vm.UiLanguage);

                StatusMessage = "Your preferences were updated";
                return RedirectToAction(nameof(Languages));
            }
            catch (Exception ex)
            {
                string msg = $"Unable to save your preferences.";
                logger.Log(LogLevel.Error, ex, msg);

                throw new CustomApplicationException(msg);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendVerificationEmail(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            string code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            string callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
            string email = user.Email;
            await notificationSender.SendEmailConfirmationAsync(email, callbackUrl);

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            bool hasPassword = await userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToAction(nameof(SetPassword));
            }

            ChangePasswordViewModel model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            IdentityResult changePasswordResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await signInManager.SignInAsync(user, isPersistent: false);
            logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Your password has been changed.";

            return RedirectToAction(nameof(ChangePassword));
        }

        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            bool hasPassword = await userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                return RedirectToAction(nameof(ChangePassword));
            }

            SetPasswordViewModel model = new SetPasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            IdentityResult addPasswordResult = await userManager.AddPasswordAsync(user, model.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                AddErrors(addPasswordResult);
                return View(model);
            }

            await signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = "Your password has been set.";

            return RedirectToAction(nameof(SetPassword));
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLogins()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            ExternalLoginsViewModel model = new ExternalLoginsViewModel { CurrentLogins = await userManager.GetLoginsAsync(user) };
            model.OtherLogins = (await signInManager.GetExternalAuthenticationSchemesAsync())
                .Where(auth => model.CurrentLogins.All(ul => auth.Name != ul.LoginProvider))
                .ToList();
            model.ShowRemoveButton = await userManager.HasPasswordAsync(user) || model.CurrentLogins.Count > 1;
            model.StatusMessage = StatusMessage;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LinkLogin(string provider)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            // Request a redirect to the external login provider to link a login for the current user
            string redirectUrl = Url.Action(nameof(LinkLoginCallback));
            AuthenticationProperties properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, userManager.GetUserId(User));
            return new ChallengeResult(provider, properties);
        }

        [HttpGet]
        public async Task<IActionResult> LinkLoginCallback()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync(user.Id);
            if (info == null)
            {
                throw new CustomApplicationException($"Unexpected error occurred loading external login info for user with ID '{user.Id}'.");
            }

            IdentityResult result = await userManager.AddLoginAsync(user, info);
            if (!result.Succeeded)
            {
                throw new CustomApplicationException($"Unexpected error occurred adding external login for user with ID '{user.Id}'.");
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            StatusMessage = SharedLocalizer["The external login was added."];
            return RedirectToAction(nameof(ExternalLogins));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel model)
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            IdentityResult result = await userManager.RemoveLoginAsync(user, model.LoginProvider, model.ProviderKey);
            if (!result.Succeeded)
            {
                throw new CustomApplicationException($"Unexpected error occurred removing external login for user with ID '{user.Id}'.");
            }

            await signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = SharedLocalizer["The external login was removed."];
            return RedirectToAction(nameof(ExternalLogins));
        }

        [HttpGet]
        public async Task<IActionResult> TwoFactorAuthentication()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            TwoFactorAuthenticationViewModel model = new TwoFactorAuthenticationViewModel
            {
                HasAuthenticator = await userManager.GetAuthenticatorKeyAsync(user) != null,
                Is2faEnabled = user.TwoFactorEnabled,
                RecoveryCodesLeft = await userManager.CountRecoveryCodesAsync(user),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Disable2faWarning()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if (!user.TwoFactorEnabled)
            {
                throw new CustomApplicationException($"Unexpected error occured disabling 2FA for user with ID '{user.Id}'.");
            }

            return View(nameof(Disable2fa));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Disable2fa()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            IdentityResult disable2faResult = await userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new CustomApplicationException($"Unexpected error occured disabling 2FA for user with ID '{user.Id}'.");
            }

            logger.LogInformation("User with ID {UserId} has disabled 2fa.", user.Id);
            return RedirectToAction(nameof(TwoFactorAuthentication));
        }

        [HttpGet]
        public async Task<IActionResult> EnableAuthenticator()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            EnableAuthenticatorViewModel model = new EnableAuthenticatorViewModel();
            await LoadSharedKeyAndQrCodeUriAsync(user, model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnableAuthenticator(EnableAuthenticatorViewModel model)
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadSharedKeyAndQrCodeUriAsync(user, model);
                return View(model);
            }

            // Strip spaces and hypens
            string verificationCode = model.Code.Replace(" ", string.Empty).Replace("-", string.Empty);

            bool is2faTokenValid = await userManager.VerifyTwoFactorTokenAsync(
                user, userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);

            if (!is2faTokenValid)
            {
                ModelState.AddModelError("Code", "Verification code is invalid.");
                await LoadSharedKeyAndQrCodeUriAsync(user, model);
                return View(model);
            }

            await userManager.SetTwoFactorEnabledAsync(user, true);
            logger.LogInformation("User with ID {UserId} has enabled 2FA with an authenticator app.", user.Id);
            IEnumerable<string> recoveryCodes = await userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
            TempData[RecoveryCodesKey] = recoveryCodes.ToArray();

            return RedirectToAction(nameof(ShowRecoveryCodes));
        }

        [HttpGet]
        public IActionResult ShowRecoveryCodes()
        {
            string[] recoveryCodes = (string[])TempData[RecoveryCodesKey];
            if (recoveryCodes == null)
            {
                return RedirectToAction(nameof(TwoFactorAuthentication));
            }

            ShowRecoveryCodesViewModel model = new ShowRecoveryCodesViewModel { RecoveryCodes = recoveryCodes };
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetAuthenticatorWarning()
        {
            return View(nameof(ResetAuthenticator));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetAuthenticator()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            await userManager.SetTwoFactorEnabledAsync(user, false);
            await userManager.ResetAuthenticatorKeyAsync(user);
            logger.LogInformation("User with id '{UserId}' has reset their authentication app key.", user.Id);

            return RedirectToAction(nameof(EnableAuthenticator));
        }

        [HttpGet]
        public async Task<IActionResult> GenerateRecoveryCodesWarning()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if (!user.TwoFactorEnabled)
            {
                throw new CustomApplicationException($"Cannot generate recovery codes for user with ID '{user.Id}' because they do not have 2FA enabled.");
            }

            return View(nameof(GenerateRecoveryCodes));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateRecoveryCodes()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new CustomApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if (!user.TwoFactorEnabled)
            {
                throw new CustomApplicationException($"Cannot generate recovery codes for user with ID '{user.Id}' as they do not have 2FA enabled.");
            }

            IEnumerable<string> recoveryCodes = await userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
            logger.LogInformation("User with ID {UserId} has generated new 2FA recovery codes.", user.Id);

            ShowRecoveryCodesViewModel model = new ShowRecoveryCodesViewModel { RecoveryCodes = recoveryCodes.ToArray() };

            return View(nameof(ShowRecoveryCodes), model);
        }

        #region Helpers

        private void SetPreferencesCookies(UserPreferencesViewModel preferences)
        {
            SetCookieValue(SessionValues.PostLanguage, preferences.UiLanguage.ToString(), 7);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private string FormatKey(string unformattedKey)
        {
            StringBuilder result = new StringBuilder();
            int currentPosition = 0;
            while (currentPosition + 4 < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition, 4)).Append(" ");
                currentPosition += 4;
            }
            if (currentPosition < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition));
            }

            return result.ToString().ToLowerInvariant();
        }

        private string GenerateQrCodeUri(string email, string unformattedKey)
        {
            return string.Format(
                AuthenticatorUriFormat,
                urlEncoder.Encode("IndieVisible"),
                urlEncoder.Encode(email),
                unformattedKey);
        }

        private async Task LoadSharedKeyAndQrCodeUriAsync(ApplicationUser user, EnableAuthenticatorViewModel model)
        {
            string unformattedKey = await userManager.GetAuthenticatorKeyAsync(user);
            if (string.IsNullOrEmpty(unformattedKey))
            {
                await userManager.ResetAuthenticatorKeyAsync(user);
                unformattedKey = await userManager.GetAuthenticatorKeyAsync(user);
            }

            model.SharedKey = FormatKey(unformattedKey);
            model.AuthenticatorUri = GenerateQrCodeUri(user.Email, unformattedKey);
        }

        #endregion Helpers
    }
}