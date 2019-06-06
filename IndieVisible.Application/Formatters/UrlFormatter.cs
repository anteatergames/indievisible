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
    }
}
