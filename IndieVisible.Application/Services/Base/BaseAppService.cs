using IndieVisible.Domain.Core.Enums;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace IndieVisible.Application.Services
{
    public abstract class BaseAppService : IDisposable
    {
        public Guid CurrentUserId { get; set; }

        protected MediaType GetMediaType(string featuredImage)
        {

            if (string.IsNullOrWhiteSpace(featuredImage))
            {
                return MediaType.None;
            }

            var youtubePattern = @"(https?\:\/\/)?(www\.youtube\.com|youtu\.?be)\/.+";

            var match = Regex.Match(featuredImage, youtubePattern);

            if (match.Success)
            {
                return MediaType.Youtube;
            }

            var imageExtensions = new string[] { "jpg", "png", "gif", "tiff", "webp", "svg", "jfif", "jpeg", "bmp" };
            var videoExtensions = new string[] { "mp4", "avi", "mpeg", "vob", "webm", "mpg", "m4v", "wmv", "asf", "mov", "mpe", "3gp" };

            var extension = featuredImage.Split('.').Last();


            if (imageExtensions.Contains(extension.ToLower()))
            {
                return MediaType.Image;
            }
            else if (videoExtensions.Contains(extension.ToLower()))
            {
                return MediaType.Video;
            }

            return MediaType.Image;
        }

        protected virtual void Dispose(bool dispose)
        {
            // dispose resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
