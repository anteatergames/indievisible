using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Home;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using System.Collections.Generic;

namespace IndieVisible.Application
{
    public static class FakeData
    {
        public static CarouselViewModel FakeCarousel()
        {
            CarouselViewModel carousel = new CarouselViewModel();

            carousel.Items = new List<FeaturedContentViewModel>();

            FeaturedContentViewModel item1 = new FeaturedContentViewModel
            {
                Url = "#",
                ImageUrl = "/images/featured/fez.jpg",
                Title = "Fez",
                Introduction = "Fez made history, admit it."
            };
            carousel.Items.Add(item1);

            FeaturedContentViewModel item2 = new FeaturedContentViewModel
            {
                Url = "#",
                ImageUrl = "/images/featured/indies.jpg",
                Title = "Indie love",
                Introduction = "Why people love to play independent games?"
            };
            carousel.Items.Add(item2);

            FeaturedContentViewModel item3 = new FeaturedContentViewModel
            {
                Url = "#",
                ImageUrl = "/images/featured/indiedev.jpg",
                Title = "Wildlife channel presents",
                Introduction = "Independent developers. Where they live? What they eat."
            };
            carousel.Items.Add(item3);

            FeaturedContentViewModel item4 = new FeaturedContentViewModel
            {
                Url = "#",
                ImageUrl = "/images/featured/bioshock-collection.jpg",
                Title = "BioIndie",
                Introduction = "Bioshock is becoming indie"
            };
            carousel.Items.Add(item4);

            return carousel;
        }

        public static CountersViewModel FakeCounters()
        {
            CountersViewModel counters = new CountersViewModel();

            counters.GamesCount = 1658;
            counters.UsersCount = 2659;
            counters.ArticlesCount = 981;
            counters.JamsCount = 42;

            return counters;
        }

        public static List<GameListItemViewModel> FakeFeaturedGames()
        {
            List<GameListItemViewModel> games = new List<GameListItemViewModel>();

            GameListItemViewModel game2 = new GameListItemViewModel();
            game2.ThumbnailUrl = "/images/games/gameplaceholder.jpg";
            game2.DeveloperImageUrl = "/images/profileimages/fakedeveloper1.jpg";
            game2.Title = "Who I See";
            game2.DeveloperName = "ChillingCircuits";
            game2.Price = "FREE";
            games.Add(game2);

            GameListItemViewModel game3 = new GameListItemViewModel();
            game3.ThumbnailUrl = "/images/games/gameplaceholder.jpg";
            game3.DeveloperImageUrl = "/images/profileimages/fakedeveloper2.jpg";
            game3.Title = "Black Paradox";
            game3.DeveloperName = "fantasticostudio";
            game3.Price = "FREE";
            games.Add(game3);

            GameListItemViewModel game1 = new GameListItemViewModel();
            game1.ThumbnailUrl = "/images/games/gameplaceholder.jpg";
            game1.DeveloperImageUrl = "/images/profileimages/fakedeveloper3.jpg";
            game1.Title = "SWITCH!";
            game1.DeveloperName = "NitrogenLive";
            game1.Price = "FREE";
            games.Add(game1);

            return games;
        }

        public static ProfileViewModel FakeProfile()
        {
            ProfileViewModel profile = new ProfileViewModel();

            profile.Type = ProfileType.Personal;

            profile.Name = "Jon Doe";
            profile.Motto = "Code Lover";
            profile.CoverImageUrl = "/images/wallpapers/gamer.jpg";

            profile.Bio = "A game developer willing to rock the game development world with funny games.";

            profile.StudioName = "Awesome Game Studio";
            profile.Location = "Atlantis";

            profile.GameJoltUrl = string.Empty;
            profile.ItchIoUrl = string.Empty;
            profile.IndieDbUrl = string.Empty;
            profile.UnityConnectUrl = string.Empty;
            profile.GameDevNetUrl = string.Empty;

            profile.Counters.Followers = 6000;
            profile.Counters.Following = 654;
            profile.Counters.Connections = 8651;
            profile.Counters.Games = 42;
            profile.Counters.Posts = 7;
            profile.Counters.Comments = 95191;
            profile.Counters.Jams = 25;

            profile.IndieXp.Level = 5;
            profile.IndieXp.LevelXp = 500;
            profile.IndieXp.NextLevelXp = 1500;

            profile.ExternalLinks.Add(ExternalLinks.Website, "http://www.indievisible.net");
            profile.ExternalLinks.Add(ExternalLinks.Facebook, "http://www.facebook.com");

            return profile;
        }
    }
}
