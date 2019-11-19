using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.Formatters
{
    public static class UrlFormatter
    {
        #region Internal
        public static string ProfileImage(Guid userId)
        {
            return String.Format("{0}/{1}/{2}", Constants.DefaultUserImagePath, BlobType.ProfileImage, userId);
        }
        public static string ProfileCoverImage(Guid userId, Guid profileId)
        {
            return ProfileCoverImage(userId, profileId, null);
        }

        public static string ProfileCoverImage(Guid userId, Guid profileId, string currentCoverImageUrl)
        {
            var url = string.IsNullOrWhiteSpace(currentCoverImageUrl) ? String.Format("{0}/{1}/profilecover_{2}", Constants.DefaultCdnPath, userId, profileId) : currentCoverImageUrl;

            return url.Replace("//", "/").Replace("https:/", "https://");
        }

        public static string Image(Guid userId, BlobType type, string fileName)
        {
            if (fileName.StartsWith(Constants.DefaultCdnPath))
            {
                return fileName;
            }
            else
            {
                return String.Format("{0}/{1}/{2}", Constants.DefaultCdnPath.TrimEnd('/'), userId, fileName);
            }
        }
        #endregion

        #region ExternalUrls
        private static string ExternalUrlCommon(string handler)
        {
            handler = handler.ToLower().Replace(" ", "-");
            return handler;
        }
        private static string CompleteUrlCommon(string handler)
        {
            handler = handler.Trim('/');
            if (!handler.StartsWith("http"))
            {
                handler = String.Format("http://{0}", handler);
            }
            return handler;
        }

        #region Profiles
        public static string ItchIoProfile(string handler)
        {

            if (!string.IsNullOrWhiteSpace(handler) && !handler.EndsWith("itch.io"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://{0}.itch.io", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string GameJoltProfile(string handler)
        {

            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("gamejolt.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://gamejolt.com/@{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string UnityConnectProfile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("connect.unity.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://connect.unity.com/u/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string IndieDbPofile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("indiedb.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.indiedb.com/members/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string GamedevNetProfile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("gamedev.net"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.gamedev.net/profile/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string AppleAppStoreProfile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("apps.apple.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://apps.apple.com/us/developer/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string GooglePlayStoreProfile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("play.google.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://play.google.com/store/apps/dev?id={0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }
        #endregion

        public static string Website(string handler)
        {
            handler = CompleteUrlCommon(handler);
            return handler;
        }

        public static string Facebook(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("facebook.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.facebook.com/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string Twitter(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("twitter.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://twitter.com/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string Instagram(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("instagram.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.instagram.com/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string Youtube(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("youtube.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.youtube.com/channel/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string XboxLiveProfile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("xbox.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://account.xbox.com/en-us/profile?gamertag={0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string PlayStationStoreProfile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("playstation.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://my.playstation.com/profile/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string SteamGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("store.steampowered.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://store.steampowered.com/app/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string GameJoltGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("gamejolt.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://gamejolt.com/games/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string ItchIoGame(string handler)
        {
            if (handler.ToLower().Contains("itch.io") && !handler.ToLower().Contains("http"))
            {
                handler = "https://" + handler;
            }
            return handler;
        }

        public static string GamedevNetGame(string handler)
        {
            return handler;
        }

        public static string IndieDbGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("indiedb.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.indiedb.com/games/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string UnityConnectGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("connect.unity.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://connect.unity.com/p/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string AppleAppStoreGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("apps.apple.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://apps.apple.com/us/app/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string GooglePlayStoreGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("play.google.com"))
            {
                return String.Format("https://play.google.com/store/apps/details?id={0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string XboxLiveGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("xbox.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.xbox.com/games/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string PlayStationStoreGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("store.playstation.com"))
            {
                return String.Format("https://store.playstation.com/en-us/product/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }
        #endregion
    }
}
