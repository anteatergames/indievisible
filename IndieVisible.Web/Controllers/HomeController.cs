using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Home;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Attributes;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Web.Controllers.Base;
using IndieVisible.Web.Enums;
using IndieVisible.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IndieVisible.Web.Controllers
{
    public class HomeController : SecureBaseController
    {
        private readonly IUserPreferencesAppService userPreferencesAppService;
        private readonly IFeaturedContentAppService featuredContentAppService;

        public HomeController(IUserPreferencesAppService userPreferencesAppService, IFeaturedContentAppService featuredContentAppService) : base()
        {
            this.userPreferencesAppService = userPreferencesAppService;
            this.featuredContentAppService = featuredContentAppService;
        }

        public IActionResult Index()
        {
            CarouselViewModel featured = featuredContentAppService.GetFeaturedNow();
            ViewBag.Carousel = featured;

            this.SetLanguage();

            Dictionary<string, string> genreDict = SetGenreTags();

            ViewData["Genres"] = genreDict;

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [Route("/termsandconditions")]
        public IActionResult Terms()
        {
            return View();
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Counters()
        {
            return ViewComponent("Counters", new { qtd = 3 });
        }

        public IActionResult Notifications()
        {
            return ViewComponent("Notification", new { qtd = 5 });
        }

        [Route("/timeline")]
        public IActionResult Timeline()
        {
            TimeLineViewModel model = GenerateTimeline();

            return View(model);
        }

        private void SetLanguage()
        {
            PostFromHomeViewModel postModel = new PostFromHomeViewModel();

            RequestCulture requestLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture;

            string lang = this.GetCookieValue(SessionValues.DefaultLanguage);
            if (lang != null)
            {
                SupportedLanguage langEnum = (SupportedLanguage)Enum.Parse(typeof(SupportedLanguage), lang);
                postModel.DefaultLanguage = langEnum;
            }
            else
            {
                if (!User.Identity.IsAuthenticated)
                {
                    postModel.DefaultLanguage = base.SetLanguageFromCulture(requestLanguage.UICulture.Name);
                }
                else
                {
                    UserPreferencesViewModel userPrefs = this.userPreferencesAppService.GetByUserId(this.CurrentUserId);

                    if (userPrefs != null)
                    {
                        this.SetLanguage(userPrefs.UiLanguage);
                        postModel.DefaultLanguage = userPrefs.UiLanguage;

                    }
                    else
                    {
                        postModel.DefaultLanguage = SupportedLanguage.English;
                    }
                }
            }

            this.SetCookieValue(SessionValues.DefaultLanguage, postModel.DefaultLanguage.ToString(), 7);

            ViewBag.PostFromHome = postModel;
        }


        private static TimeLineViewModel GenerateTimeline()
        {
            DateTime startDate = new DateTime(2018, 08, 27);
            TimeLineViewModel model = new TimeLineViewModel();

            model.Items.Add(new TimeLineItemViewModel
            {
                Start = true,
                Date = startDate,
                Icon = "fas fa-asterisk",
                Title = "The Idea",
                Subtitle = startDate.ToShortDateString(),
                Description = "This is where the whole idea began. We wrote a Google Document to sketch the idea and see the big picture forming."
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2018, 09, 13),
                Icon = "fas fa-play",
                Color = "success",
                Title = "The First Commit",
                Subtitle = "Every journey starts with a first step.",
                Description = "A simple README file added to start the repository."
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2018, 09, 14),
                Icon = "fas fa-cloud",
                Color = "warning",
                Title = "September 2018",
                Subtitle = "A month full of tasks",
                Description = "September 2018 was a busy month for us. We setup our CI/CD pipeline and also:",
                Items = {
                    "Archtecture defined",
                    "Menu defined",
                    "Basic Register and Login working",
                    "Profile page prototyped",
                    "Tag Cloud"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2018, 10, 01),
                Icon = "fas fa-shield-alt",
                Color = "info",
                Title = "October 2018",
                Subtitle = "Security first",
                Description = "October was a month to work on the security system. Several improvements were made on the Register and Login workflows."
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2018, 11, 01),
                Color = "danger",
                Title = "November 2018",
                Subtitle = "A really busy month!",
                Description = "November was awesome for INDIEVISIBLE. We manage to implement several core systems that are used across the whole platform.",
                Items = {
                    "Forgot password, password reset, email verification",
                    "Front page improvements",
                    "Facebook, Google and Microsoft Authentication",
                    "Game page prototyped",
                    "Terms of Use and Privacy Policy added",
                    "Image Upload",
                    "Use user image when registering with Facebook",
                    "AJAX front page",
                    "Latest games component",
                    "Counters component",
                    "Favicons and Manifest",
                    "Basic localization system implemented with Portuguese (by Daniel Gomes)  and Russian by Denis Mokhin)",
                    "Dynamic taglist on the front page",
                    "Basic staff roles defined",
                    "Translation project integration",
                    "OpenGraph implementated",
                    "Like/Unlike system",
                    "Comment system",
                    "Progressive Web App implemented"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2018, 12, 01),
                Color = "success",
                Title = "December 2018",
                Subtitle = "To close the year.",
                Description = "In December we implemented a few things needed for the launch day.",
                Items = {
                    "Language selection",
                    "Game activity feed",
                    "Content view and edit",
                    "Image cropping",
                    "GDPR cookies warning",
                    "Facebook sharing",
                    "Structured data from schema.org"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 01, 01),
                Icon = "fas fa-globe",
                Color = "primary",
                Title = "January 2019",
                Subtitle = "Happy new year! Let's work!",
                Description = "We started the year by optimizing the whole platform.",
                Items = {
                    "Page speed improvements",
                    "Search Engine Optimization (title, description, sitemap, etc",
                    "Added Bosnian, Croatian and Serbian languages added by Kamal Tufekčić",
                    "German language started by Thorben",
                    "Featured article system implemented (staff only)",
                    "Username validation",
                    "Cache management"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 02, 01),
                Icon = "fas fa-globe",
                Color = "success",
                Title = "Febuary 2019",
                Subtitle = "Some tweaks",
                Description = "IndieVisible is for everyone!",
                Items = {
                    "Image size descriptions",
                    "Accessibility improvements",
                    "Images on CDN"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 03, 01),
                Icon = "fas fa-vote-yea",
                Color = "primary",
                Title = "March 2019",
                Subtitle = "Democracy",
                Description = "The voting system! Users can now:",
                Items = {
                    "Suggest ideas",
                    "Vote on other people's ideas",
                    "Comment on ideas",
                    "Create your own brainstorm sessions"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 04, 01),
                Icon = "far fa-comment",
                Color = "primary",
                Title = "April 2019",
                Subtitle = "Fast posting",
                Description = "Like a good social network you can now:",
                Items = {
                    "Post directly from the front page",
                    "Add a image to post",
                    "Post from within your game",
                    "Game like"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 05, 01),
                Icon = "fas fa-trophy",
                Color = "success",
                Title = "May 2019",
                Subtitle = "Game On!",
                Description = "Climb the IndieVisible Ranks to the glory",
                Items = {
                    "Ranking System",
                    "Experience Points",
                    "Badges",
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 06, 01),
                Icon = "fab fa-connectdevelop",
                Color = "info",
                Title = "June 2019",
                Subtitle = "Social Interaction",
                Description = "Follow games and users and connect to users to increase your social network!",
                Items = {
                    "Notifications!",
                    "Game Follow",
                    "User Follow",
                    "User Connection System"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 07, 01),
                Icon = "fas fa-poll",
                Color = "success",
                Title = "July 2019",
                Subtitle = "This or that?",
                Description = "Polls, preferences and more!",
                Items = {
                    "Basic Polls - Get opinions from your fellow devs!",
                    "Better preferences - Now you can change your email, set your phone and more!",
                    "Two Factor Authentication - Be more safe with this security feature",
                    "Content post language selection",
                    "Ranking Page",
                    "Post new suggestions right from the sidebar",
                    "Basic search results",
                    "QR code generation"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 08, 01),
                Icon = "fas fa-question",
                Color = "primary",
                Title = "August 2019",
                Subtitle = "...",
                Description = "Nothing to see here, keep scrolling!"
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 09, 01),
                Icon = "fas fa-trash-alt",
                Color = "danger",
                Title = "September 2019",
                Subtitle = "You got the power!",
                Description = "Must have features!",
                Items = {
                    "You can now delete your own posts",
                    "Share your game!",
                    "Rank Levels page"
                }
            });

            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2019, 09, 01),
                Icon = "fas fa-users",
                Color = "info",
                Title = "October",
                Subtitle = "Team up!",
                Description = "Join forces to make games.",
                Items = {
                    "Team Management"
                }
            });

            // Future
            model.Items.Add(new TimeLineItemViewModel
            {
                Date = new DateTime(2020, 01, 01),
                Icon = "fas fa-bug",
                Color = "danger",
                Title = "January 2020",
                Subtitle = "Open Beta",
                Description = "At this point, we hope to have a consistent beta tester base so we can polish the platform and fix every possible bug tha shows up."
            });


            model.Items.Add(new TimeLineItemViewModel
            {
                End = true,
                Date = new DateTime(2020, 07, 01),
                Icon = "fas fa-star",
                Color = "success",
                Title = "July 2020",
                Subtitle = "Launch day!",
                Description = "This is the scheduled launch day. On this day, all the core features must be implented."
            });

            model.Items = model.Items.OrderBy(x => x.Date).ToList();
            return model;
        }

        #region private methods
        private static Dictionary<string, string> SetGenreTags()
        {
            List<KeyValuePair<string, string>> genreDict = new List<KeyValuePair<string, string>>();

            IEnumerable<GameGenre> genres = Enum.GetValues(typeof(GameGenre)).Cast<GameGenre>();

            genres.ToList().ForEach(x =>
            {
                string uiClass = x.GetAttributeOfType<UiInfoAttribute>().Class;

                genreDict.Add(new KeyValuePair<string, string>(x.ToString(), uiClass));
            });

            Dictionary<string, string> dict = genreDict.ToDictionary(x => x.Key, x => x.Value);

            return dict;
        }
        #endregion
    }
}
