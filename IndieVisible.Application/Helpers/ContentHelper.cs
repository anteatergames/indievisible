using IndieVisible.Application.Formatters;
using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.Helpers
{
    public static class ContentHelper
    {
        public static string SetFeaturedImage(Guid userId, string featuredImage, ImageRenderType type)
        {
            if (string.IsNullOrWhiteSpace(featuredImage) || featuredImage.Equals(Constants.DefaultFeaturedImage))
            {
                return Constants.DefaultFeaturedImage;
            }
            else
            {
                switch (type)
                {
                    case ImageRenderType.LowQuality:
                        return UrlFormatter.Image(userId, ImageType.FeaturedImage, featuredImage, 600, 10);

                    case ImageRenderType.Responsive:
                        return UrlFormatter.Image(userId, ImageType.FeaturedImage, featuredImage, 0, 0, true);

                    case ImageRenderType.Full:
                    default:
                        return UrlFormatter.Image(userId, ImageType.FeaturedImage, featuredImage);
                }
            }
        }
    }
}