using IndieVisible.Domain.Core.Enums;
using IndieVisible.Infra.CrossCutting.Identity;
using IndieVisible.Infra.CrossCutting.Identity.Model;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Infra.CrossCutting.IoC;
using IndieVisible.Infra.Data.MongoDb;
using IndieVisible.Web.Extensions;
using IndieVisible.Web.Middlewares;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndieVisible.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            //string cs = Configuration.GetConnectionString("DefaultConnection");

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
                            string profileImg = context.User["picture"]["data"].Value<string>("url");
                            identity.AddClaim(new Claim("fbprofilepicture", profileImg));
                            return Task.CompletedTask;
                        }
                    };
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                })
                .AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                    microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
                });


            services.AddAutoMapperSetup();

            services.AddSession(opt =>
            {
                opt.Cookie.Name = ".IndieVisible.Session";
                opt.Cookie.IsEssential = true;
            });

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.AddResponseCompression();

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            services.AddMvc(options =>
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
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "Resources"; })
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(SharedResources));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddProgressiveWebApp();

            List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("en"),
                    new CultureInfo("pt-BR"),
                    new CultureInfo("pt"),
                    new CultureInfo("ru-RU"),
                    new CultureInfo("ru"),
                    new CultureInfo("bs"),
                    new CultureInfo("sr"),
                    new CultureInfo("hr"),
                    new CultureInfo("de")
                };

            services.Configure<RequestLocalizationOptions>(opts =>
            {

                opts.DefaultRequestCulture = new RequestCulture("en-US");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });

            services.AddTransient<ICookieMgrService, CookieMgrService>();

            services.Configure<ConfigOptions>(myOptions =>
            {
                myOptions.FacebookAppId = Configuration["Authentication:Facebook:AppId"];
            });

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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

            //app.UseETagger();

            IOptions<RequestLocalizationOptions> options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSession();

            //app.UseSitemapMiddleware();

            app.UseRewriter(new RewriteOptions()
               .AddRedirectToHttps()
            );

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "azurestorage",
                    template: "{controller=storage}/{action=image}/{id}"
                );

                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
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
    }
}
