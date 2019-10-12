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
            return String.Format("{0}/{1}/profilecover_{2}", Constants.DefaultCdnPath, userId, profileId);
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

        #region Old
        public static string ItchIo(string handler)
        {

            if (!string.IsNullOrWhiteSpace(handler) && !handler.EndsWith("itch.io"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://{0}.itch.io", handler);
            }
            else
            {
                return handler;
            }
        }

        public static string GameJolt(string handler)
        {

            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("gamejolt.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://gamejolt.com/@{0}", handler);
            }
            else
            {
                return handler;
            }
        }

        public static string UnityConnect(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("connect.unity.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://connect.unity.com/u/{0}", handler);
            }
            else
            {
                return handler;
            }
        }

        public static string IndieDb(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("indiedb.com"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.indiedb.com/members/{0}", handler);
            }
            else
            {
                return handler;
            }
        }

        public static string GamedevNet(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("gamedev.net"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.gamedev.net/profile/{0}", handler);
            }
            else
            {
                return handler;
            }
        }
        #endregion

        public static string Website(string handler)
        {
            handler = handler.Trim('/');
            if (!handler.StartsWith("http"))
            {
                handler = String.Format("http://{0}", handler);
            }
            return handler;
        }

        public static string Facebook(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://www.facebook.com/{0}", handler);
        }

        public static string Twitter(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://twitter.com/{0}", handler);
        }

        public static string Instagram(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://www.instagram.com/{0}", handler);
        }

        public static string Youtube(string handler)
        {
            return String.Format("https://www.youtube.com/channel/{0}", handler);
        }

        public static string XboxLive(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://account.xbox.com/en-us/profile?gamertag={0}", handler);
        }

        public static string Psn(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://my.playstation.com/profile/{0}", handler);
        }

        public static string Steam(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://steamcommunity.com/id/{0}", handler);
        }
        #endregion
    }
}
