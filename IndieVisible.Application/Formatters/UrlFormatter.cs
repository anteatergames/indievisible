using CloudinaryDotNet;
using IndieVisible.Domain.Core.Enums;
using System;
using System.Linq;
using System.Text;

namespace IndieVisible.Application.Formatters
{
    public static class UrlFormatter
    {
        #region Internal
        public static string GetDefaultImage(BlobType type)
        {
            string defaultImageNotRooted = string.Empty;

            switch (type)
            {
                case BlobType.ProfileImage:
                    defaultImageNotRooted = Constants.DefaultAvatar;
                    break;

                case BlobType.ProfileCover:
                    defaultImageNotRooted = Constants.DefaultProfileCoverImage;
                    break;

                case BlobType.GameThumbnail:
                    defaultImageNotRooted = Constants.DefaultGameThumbnail;
                    break;

                case BlobType.GameCover:
                    defaultImageNotRooted = Constants.DefaultGameCoverImage;
                    break;

                case BlobType.ContentImage:
                    defaultImageNotRooted = Constants.DefaultGameThumbnail;
                    break;

                case BlobType.FeaturedImage:
                    defaultImageNotRooted = Constants.DefaultFeaturedImage;
                    break;

                default:
                    defaultImageNotRooted = Constants.DefaultAvatar;
                    break;
            }

            defaultImageNotRooted = defaultImageNotRooted.Substring(1).Replace(@"/", @"\");

            return defaultImageNotRooted;
        }

        public static string ProfileImage(Guid userId)
        {
            return ProfileImage(userId, null, 0);
        }
        public static string ProfileImage(Guid userId, int width)
        {
            return ProfileImage(userId, null, width);
        }
        public static string ProfileImage(Guid userId, DateTime? lastUpdateDate)
        {
            return ProfileImage(userId, lastUpdateDate, 0);
        }
        public static string ProfileImage(Guid userId, DateTime? lastUpdateDate, int width)
        {
            string fileName = String.Format("profileimage_{0}_Personal", userId);

            string url = CdnCommon(userId, fileName, width);

            return url;
        }

        public static string ProfileCoverImage(Guid userId, Guid profileId)
        {
            return ProfileCoverImage(userId, profileId, null, false, 0);
        }
        public static string ProfileCoverImage(Guid userId, Guid profileId, DateTime? lastUpdateDate, bool hasCoverImage)
        {
            return ProfileCoverImage(userId, profileId, lastUpdateDate, hasCoverImage, 0);
        }
        public static string ProfileCoverImage(Guid userId, Guid profileId, DateTime? lastUpdateDate, bool hasCoverImage, int width)
        {
            long v = lastUpdateDate.HasValue ? lastUpdateDate.Value.Ticks : 1;

            string fileName = String.Format("profilecover_{0}", profileId);

            string url = hasCoverImage ? String.Format("{0}/{1}/{2}?v={3}", Constants.DefaultCdnPath, userId, fileName, v) : Constants.DefaultProfileCoverImage;

            url = url.Replace("//", "/").Replace("https:/", "https://");

            if (hasCoverImage && !url.Equals(Constants.DefaultGameCoverImage))
            {
                url = CdnCommon(userId, fileName, width);
            }

            return url;
        }


        public static string Image(Guid userId, BlobType type, string fileName)
        {
            return Image(userId, type, fileName, 0);
        }
        public static string Image(Guid userId, BlobType type, string fileName, int width)
        {
            return Image(userId, type, fileName, width, 0);
        }
        public static string Image(Guid userId, BlobType type, string fileName, int width, int quality)
        {
            return Image(userId, type, fileName, width, quality, false);
        }
        public static string Image(Guid userId, BlobType type, string fileName, int width, int quality, bool responsive)
        {
            var url = CdnCommon(userId, fileName, responsive, width, quality);

            return url;
        }

        public static string CdnCommon(Guid userId, string fileName)
        {
            return CdnCommon(userId, fileName, 0);
        }

        public static string CdnCommon(Guid userId, string fileName, int width)
        {
            return CdnCommon(userId, fileName, false, width, 0);
        }

        public static string CdnCommon(Guid userId, string fileName, bool responsive, int width, int quality)
        {
            string[] fileNameSplit = fileName.Split('/');
            if (fileNameSplit.Length > 1)
            {
                fileName = fileNameSplit.Last();
            }

            string publicId = String.Format("{0}/{1}", userId, fileName.Split('.')[0]);

            Cloudinary cloudinary = new Cloudinary();

            if (responsive)
            {
                StringBuilder sb = new StringBuilder();

                Transformation transformation = new Transformation().FetchFormat("auto").Width(300);
                string url300 = cloudinary.Api.UrlImgUp.Secure(true).Transform(transformation).BuildUrl(publicId);
                sb.Append(String.Format("{0} 300w, ", url300));

                transformation = new Transformation().FetchFormat("auto").Width(600);
                string url600 = cloudinary.Api.UrlImgUp.Secure(true).Transform(transformation).BuildUrl(publicId);
                sb.Append(String.Format("{0} 600w, ", url600));

                transformation = new Transformation().FetchFormat("auto").Width(900);
                string url900 = cloudinary.Api.UrlImgUp.Secure(true).Transform(transformation).BuildUrl(publicId);
                sb.Append(String.Format("{0} 900w", url900));

                return sb.ToString();
            }
            else
            {
                var transformation = new Transformation().FetchFormat("auto");

                if (width > 0)
                {
                    transformation = transformation.Width(width);
                }

                if (quality > 0)
                {
                    transformation = transformation.Quality(quality);
                }
                else
                {
                    transformation = transformation.Quality("auto");
                }

                string url2 = cloudinary.Api.UrlImgUp.Secure(true).Transform(transformation).BuildUrl(publicId);

                return url2;
            }
        }


        #endregion Internal

        #region ExternalUrls

        private static string ExternalUrlCommon(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler))
            {
                handler = handler.ToLower().Replace(" ", "-");
            }

            return handler;
        }

        private static string CompleteUrlCommon(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler))
            {
                handler = handler.Trim('/');
                if (!handler.StartsWith("http"))
                {
                    handler = String.Format("http://{0}", handler);
                }
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

        public static string IndiExpoProfile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("indiexpo.net"))
            {
                handler = ExternalUrlCommon(handler);
                return String.Format("https://www.indiexpo.net/users/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        public static string ArtstationProfile(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("artstation.com"))
            {
                return String.Format("https://www.artstation.com/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        #endregion Profiles

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

        public static string ItchIoGame(string userBase, string handler)
        {
            if (!handler.ToLower().Contains("itch.io"))
            {
                userBase = userBase.Replace("https://", string.Empty).Replace("http://", string.Empty).TrimEnd('/');
                handler = String.Format("https://{0}/{1}", userBase, handler.Trim('/'));
            }
            else if (handler.ToLower().Contains("itch.io") && !handler.ToLower().Contains("http"))
            {
                handler = String.Format("https://{0}", handler.Trim('/'));
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

        public static string IndiExpoGame(string handler)
        {
            if (!string.IsNullOrWhiteSpace(handler) && !handler.Contains("indiexpo.net"))
            {
                return String.Format("https://www.indiexpo.net/games/{0}", handler);
            }
            else
            {
                handler = CompleteUrlCommon(handler);
                return handler;
            }
        }

        #endregion ExternalUrls
    }
}