using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.Formatters
{
    public static class UrlFormatter
    {
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

        #region ExternalUrls
        private static string ExternalUrlCommon(string handler)
        {
            handler = handler.ToLower().Replace(" ", "-");
            return handler;
        }


        public static string ItchIo(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://{0}.itch.io", handler);
        }

        public static string GameJolt(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://gamejolt.com/@{0}", handler);
        }

        public static string UnityConnect(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://connect.unity.com/u/{0}", handler);
        }

        public static string IndieDb(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://www.indiedb.com/members/{0}", handler);
        }

        public static string GamedevNet(string handler)
        {
            handler = ExternalUrlCommon(handler);
            return String.Format("https://www.gamedev.net/profile/{0}", handler);
        }
        #endregion
    }
}
