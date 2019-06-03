using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.Formatters
{
    public static class UrlFormatter
    {
        public static string ProfileImage(Guid userId)
        {
            //return String.Format("{0}/{1}/{2}/{3}_Personal", Constants.DefaultImagePath, BlobType.ProfileImage, userId, userId);
            return String.Format("{0}/{1}/{2}", Constants.DefaultUserImagePath, BlobType.ProfileImage, userId, userId);
            //return String.Format("{0}/{1}/profileimage_{2}_Personal", Constants.DefaultCdnPath, userId, userId);
        }
        public static string ProfileCoverImage(Guid userId, Guid profileId)
        {
            //return String.Format("{0}/{1}/{2}/{3}", Constants.DefaultUserImagePath, BlobType.ProfileCover, userId, profileId);
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
                //return String.Format("{0}/{1}/{2}/{3}", Constants.DefaultImagePath, type, userId, fileName);
                return String.Format("{0}/{1}/{2}", Constants.DefaultCdnPath.TrimEnd('/'), userId, fileName);
            }
        }
    }
}
