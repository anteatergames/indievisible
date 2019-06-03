using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IndieVisible.Application.Services
{
    public class BaseAppService
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

            var extension = featuredImage?.Split('.').Last();


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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
