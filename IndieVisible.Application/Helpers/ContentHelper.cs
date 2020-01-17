using IndieVisible.Application.Formatters;
using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.Helpers
{
    public static class ContentHelper
    {
        public static string SetFeaturedImage(Guid userId, string featuredImage, ImageType type)
        {
            if (string.IsNullOrWhiteSpace(featuredImage) || featuredImage.Equals(Constants.DefaultFeaturedImage))
            {
                return Constants.DefaultFeaturedImage;
            }
            else
            {
                switch (type)
                {
                    case ImageType.LowQuality:
                        return UrlFormatter.Image(userId, BlobType.FeaturedImage, featuredImage, 600, 10);
                    case ImageType.Responsive:
                        return UrlFormatter.Image(userId, BlobType.FeaturedImage, featuredImage, 0, 0, true);
                    case ImageType.Full:
                    default:
                        return UrlFormatter.Image(userId, BlobType.FeaturedImage, featuredImage);
                }
            }
        }
    }
}
