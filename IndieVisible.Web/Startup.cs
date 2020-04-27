using IndieVisible.Domain.Core.Enums;
using IndieVisible.Infra.CrossCutting.Identity;
using IndieVisible.Infra.CrossCutting.Identity.Model;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Infra.CrossCutting.IoC;
using IndieVisible.Infra.Data.MongoDb;
using IndieVisible.Web.Extensions;
using IndieVisible.Web.Middlewares;
using IndieVisible.Web.RewriterRules;
using IndieVisible.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndieVisible.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
                options.ConsentCookie.Name = "IndieVisible.Consent";
            });

            MongoDbPersistence.Configure();

            services.AddIdentityMongoDbProvider<ApplicationUser, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }, options =>
            {
                options.ConnectionString = Configuration["MongoSettings:Connection"];
                options.DatabaseName = Configuration["MongoSettings:DatabaseName"];
            })
                .AddDefaultTokenProviders();

            SetupAuthentication(services);

            services.AddAutoMapperSetup();

            services.AddSession(opt =>
            {
                opt.Cookie.Name = ".IndieVisible.Session";
                opt.Cookie.IsEssential = true;
            });

            services.AddResponseCompression();

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            //services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddLocalization();

            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 2592000,
                        VaryByHeader = HeaderNames.ETag
                    });
                options.CacheProfiles.Add("Short",
                    new CacheProfile()
                    {
                        Duration = 86400,
                        VaryByHeader = HeaderNames.ETag
                    });
                options.CacheProfiles.Add("Never",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            })
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(SharedResources));
            });

            services.AddMemoryCache();

            services.AddProgressiveWebApp();

            services.AddTransient<ICookieMgrService, CookieMgrService>();

            services.Configure<ConfigOptions>(myOptions =>
            {
                myOptions.FacebookAppId = Configuration["Authentication:Facebook:AppId"];
            });

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseHsts();

            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".webmanifest"] = "application/manifest+json";
            provider.Mappings[".vtt"] = "text/vtt";

            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider,
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=2592000";
                }
            });

            app.UseRouting();

            app.UseRequestLocalization(options =>
                options
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures)
                    );

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            RewriteOptions rewriteOptions = new RewriteOptions()
                .AddRedirectToHttps()
                .Add(new NonWwwRule())
                .AddRedirectToWwwPermanent();

            app.UseRewriter(rewriteOptions);

            app.UseSitemapMiddleware();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "azurestorage",
                    pattern: "{controller=storage}/{action=image}/{id}"
                );

                routes.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateUserRoles(serviceProvider).Wait();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            RoleManager<Role> roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            List<Roles> roles = Enum.GetValues(typeof(Roles)).Cast<Roles>().ToList();

            foreach (Roles role in roles)
            {
                await CreateIfNotExists(roleManager, role.ToString());
            }
        }

        private static async Task CreateIfNotExists(RoleManager<Role> RoleManager, string roleName)
        {
            bool roleCheck = await RoleManager.RoleExistsAsync(roleName);
            if (!roleCheck)
            {
                await RoleManager.CreateAsync(new Role(roleName));
            }
        }


        private void SetupAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(o =>
                            {
                                o.Cookie.Name = ".IndieVisible.Identity.Application";
                                o.LoginPath = new PathString("/login");
                                o.AccessDeniedPath = new PathString("/home/access-denied");
                            })
                            .AddFacebook(o =>
                            {
                                o.AppId = Configuration["Authentication:Facebook:AppId"];
                                o.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                                o.Fields.Add("picture");
                                o.Events = new OAuthEvents
                                {
                                    OnCreatingTicket = context =>
                                    {
                                        ClaimsIdentity identity = (ClaimsIdentity)context.Principal.Identity;
                                        string profileImg = context.User.GetProperty("picture").GetProperty("data").GetProperty("url").GetString();
                                        identity.AddClaim(new Claim("urn:facebook:picture", profileImg));
                                        return Task.CompletedTask;
                                    }
                                };
                            })
                            .AddGoogle(googleOptions =>
                            {
                                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                                googleOptions.Events = new OAuthEvents
                                {
                                    OnCreatingTicket = context =>
                                    {
                                        ClaimsIdentity identity = (ClaimsIdentity)context.Principal.Identity;
                                        string profileImg = context.User.GetProperty("picture").GetString();
                                        identity.AddClaim(new Claim("urn:google:picture", profileImg));
                                        return Task.FromResult(0);
                                    }
                                };
                            })
                            .AddMicrosoftAccount(microsoftOptions =>
                            {
                                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                                microsoftOptions.SaveTokens = true;
                                microsoftOptions.Events = new OAuthEvents
                                {
                                    OnCreatingTicket = context =>
                                    {
                                        ClaimsIdentity identity = (ClaimsIdentity)context.Principal.Identity;
                                        identity.AddClaim(new Claim("urn:microsoft:accesstoken", context.TokenResponse.AccessToken));

                                        return Task.FromResult(0);
                                    }
                                };
                            })
                            .AddGithub(githubOptions =>
                            {
                                githubOptions.ClientId = Configuration["Authentication:Github:ClientId"];
                                githubOptions.ClientSecret = Configuration["Authentication:Github:ClientSecret"];
                            });
        }

        string[] supportedCultures = new string[]
                {
                    "en-US",
                    "en",
                    "pt-BR",
                    "pt",
                    "ru-RU",
                    "ru",
                    "bs",
                    "sr",
                    "hr",
                    "de"
                };
    }
}