using ImageMagick;
using IndieVisible.Application;
using IndieVisible.Application.Formatters;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Net;

namespace IndieVisible.Web.Controllers
{
    [Route("storage")]
    [Route("azurestorage")] // TODO temp, remove after adjusting the database
    public class StorageController : SecureBaseController
    {
        private readonly IHostingEnvironment _hostingEnv;
        private static IHttpContextAccessor HttpContextAccessor;

        public StorageController(IHostingEnvironment hostingEnv, IHttpContextAccessor httpContextAccessor)
        {
            _hostingEnv = hostingEnv;
            HttpContextAccessor = httpContextAccessor;
        }

        [ResponseCache(CacheProfileName = "Never")]
        [Route("userimage/{type:alpha}/{userId:guid}/{name?}")]
        public IActionResult UserImage(BlobType type, Guid userId, string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                name = userId.ToString();
            }

            if (type == BlobType.ProfileImage)
            {
                name = String.Format("{0}_Personal", userId);
            }



            return GetImage(type, userId, name);
        }

        [ResponseCache(CacheProfileName = "Default")]
        [Route("image/{type:alpha}/{userId:guid}/{name}")]
        [Route("image/{name}")]
        [Route("image")]
        public IActionResult Image(BlobType type, Guid userId, string name)
        {
            return GetImage(type, userId, name);
        }

        private IActionResult GetImage(BlobType type, Guid userId, string name)
        {
            string baseUrl = Constants.DefaultCdnPath;
            name = name.Replace(Constants.DefaultImagePath, string.Empty);

            try
            {
                string storageBasePath = string.Empty;

                storageBasePath = FormatBasePath(type, userId, baseUrl, storageBasePath);

                string url = storageBasePath + name;

                byte[] data;

                using (WebClient webClient = new WebClient())
                {
                    data = webClient.DownloadData(url);
                }

                string etag = ETagGenerator.GetETag(HttpContextAccessor.HttpContext.Request.Path.ToString(), data);
                if (HttpContextAccessor.HttpContext.Request.Headers.Keys.Contains(HeaderNames.IfNoneMatch) && HttpContextAccessor.HttpContext.Request.Headers[HeaderNames.IfNoneMatch].ToString() == etag)
                {
                    return new StatusCodeResult(StatusCodes.Status304NotModified);
                }
                HttpContextAccessor.HttpContext.Response.Headers.Add(HeaderNames.ETag, new[] { etag });

                return File(new MemoryStream(data), "image/jpeg");
            }
            catch (Exception)
            {
                return ReturnDefaultImage(type);
            }
        }

        #region Profile
        [HttpPost]
        [Route("uploadavatar")]
        public IActionResult UploadProfileAvatar(IFormFile image, string currentImage, Guid userId)
        {
            try
            {
                string imageUrl = string.Empty;

                if (image != null && image.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.CopyTo(ms);

                        OptimizeImage(ms);

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(image);

                        string filename = userId + "_Personal";

                        imageUrl = base.UploadImage(userId, BlobType.ProfileImage, filename, fileBytes);
                    }
                }

                var json = new
                {
                    size = image?.Length,
                    oldImage = currentImage,
                    imageUrl = imageUrl
                };

                return Json(json);
            }
            catch (Exception ex)
            {
                var json = new
                {
                    error = ex.Message
                };

                return Json(json);
            }
        }
        [HttpPost]
        [Route("uploadprofilecoverimage")]
        public IActionResult UploadProfileCoverImage(IFormFile image, string currentImage, Guid userId, Guid profileId)
        {
            try
            {
                string imageUrl = string.Empty;

                if (image != null && image.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.CopyTo(ms);

                        OptimizeImage(ms);

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(image);

                        string filename = profileId.ToString();

                        imageUrl = base.UploadImage(userId, BlobType.ProfileCover, filename, fileBytes);
                    }
                }

                var json = new
                {
                    size = image?.Length,
                    oldImage = currentImage,
                    imageUrl = imageUrl
                };

                return Json(json);
            }
            catch (Exception ex)
            {
                var json = new
                {
                    error = ex.Message
                };

                return Json(json);
            }
        }
        #endregion

        #region Game
        [HttpPost]
        [Route("uploadgamethumbnail")]
        public IActionResult UploadGameThumbnail(IFormFile image, Guid gameId, string currentImage, Guid userId)
        {
            return UploadGameImage(image, BlobType.GameThumbnail, Constants.DefaultGameThumbnail, gameId, currentImage, userId);
        }

        [HttpPost]
        [Route("uploadgamecoverimage")]
        public IActionResult UploadGameCoverImage(IFormFile image, Guid gameId, string currentImage, Guid userId)
        {
            return UploadGameImage(image, BlobType.GameCover, Constants.DefaultGameCoverImage, gameId, currentImage, userId);
        }

        private IActionResult UploadGameImage(IFormFile image, BlobType type, string defaultImage, Guid gameId, string currentImage, Guid userId)
        {
            try
            {
                string imageUrl = string.Empty;

                if (image != null && image.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.CopyTo(ms);

                        OptimizeImage(ms);

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(image);

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;

                        imageUrl = base.UploadGameImage(userId, type, filename, fileBytes);
                    }
                }

                if (!string.IsNullOrWhiteSpace(currentImage))
                {
                    if (!currentImage.Equals(defaultImage))
                    {
                        string currentParam = GetImageNameFromUrl(currentImage);

                        string delete = base.DeleteGameImage(userId, type, currentParam);
                    }
                }

                var json = new
                {
                    size = image?.Length,
                    gameId = gameId,
                    oldImage = currentImage,
                    imageUrl = imageUrl
                };

                return Json(json);
            }
            catch (Exception ex)
            {
                var json = new
                {
                    error = ex.Message
                };

                return Json(json);
            }
        }
        #endregion

        #region Content
        [HttpPost]
        [Route("uploadcontentimage")]
        public IActionResult UploadContentImage(IFormFile upload)
        {
            try
            {
                string imageUrl = string.Empty;

                if (upload != null && upload.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        upload.CopyTo(ms);

                        if (upload.ContentType.StartsWith("image"))
                        {
                            OptimizeImage(ms);
                        }

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(upload);

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;


                        imageUrl = base.UploadContentImage(CurrentUserId, filename, fileBytes);
                    }
                }
                string baseUrl = GetAbsoluteBaseUri();

                var json = new
                {
                    uploaded = true,
                    url = imageUrl
                };

                return Json(json);
            }
            catch (Exception ex)
            {
                var json = new
                {
                    error = ex.Message
                };

                return Json(json);
            }
        }
        [HttpPost]
        [Route("uploadarticleimage")]
        public IActionResult UploadArticleImage(IFormFile upload)
        {
            try
            {
                string imageUrl = string.Empty;

                if (upload != null && upload.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        upload.CopyTo(ms);

                        if (upload.ContentType.StartsWith("image"))
                        {
                            OptimizeImage(ms);
                        }

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(upload);

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;


                        imageUrl = base.UploadContentImage(CurrentUserId, filename, fileBytes);
                    }
                }
                string baseUrl = GetAbsoluteBaseUri();

                var json = new
                {
                    uploaded = true,
                    url = UrlFormatter.Image(this.CurrentUserId, BlobType.ContentImage, imageUrl)
                };

                return Json(json);
            }
            catch (Exception ex)
            {
                var json = new
                {
                    error = ex.Message
                };

                return Json(json);
            }
        }


        [HttpPost]
        [Route("uploadfeaturedimage")]
        public IActionResult UploadFeaturedImage(IFormFile featuredimage, Guid id, string currentImage, Guid userId)
        {
            try
            {
                string imageUrl = string.Empty;

                if (featuredimage != null && featuredimage.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        featuredimage.CopyTo(ms);

                        if (featuredimage.ContentType.StartsWith("image"))
                        {
                            OptimizeImage(ms);
                        }

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(featuredimage);

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;

                        if (userId == Guid.Empty)
                        {
                            userId = CurrentUserId;
                        }

                        imageUrl = base.UploadFeaturedImage(userId, filename, fileBytes);
                    }
                }

                if (!string.IsNullOrWhiteSpace(currentImage))
                {
                    if (!currentImage.Equals(Constants.DefaultFeaturedImage))
                    {
                        string currentParam = GetImageNameFromUrl(currentImage);

                        string delete = base.DeleteFeaturedImage(userId, currentParam);
                    }
                }

                var json = new
                {
                    size = featuredimage?.Length,
                    id = id,
                    oldImage = currentImage,
                    imageUrl = imageUrl
                };

                return Json(json);
            }
            catch (Exception ex)
            {
                var json = new
                {
                    error = ex.Message
                };

                return Json(json);
            }
        }
        #endregion

        #region Private Methods
        private IActionResult ReturnDefaultImage(BlobType type)
        {
            string defaultImageNotRooted = GetDefaultImage(type);

            string retorno = Path.Combine(_hostingEnv.WebRootPath, defaultImageNotRooted);

            byte[] bytes = System.IO.File.ReadAllBytes(retorno);

            return File(new MemoryStream(bytes), "image/png");
        }

        private static string GetFileExtension(IFormFile uploadedFile)
        {
            string[] split = uploadedFile.FileName.Split('.');
            string extension = split.Length > 1 ? split[1] : "jpg";
            return extension;
        }

        private static string GetImageNameFromUrl(string currentImage)
        {
            string[] urlSplit = currentImage.Split('/');
            string split = urlSplit[urlSplit.Length - 1];
            //NameValueCollection queryStringParams = HttpUtility.ParseQueryString(split);
            //string currentParam = queryStringParams["name"];
            //return currentParam;

            return split;
        }

        private string GetAbsoluteBaseUri()
        {
            return "https://" + HttpContextAccessor.HttpContext.Request.Host.ToString();
        }

        private static string FormatBasePath(BlobType type, Guid userId, string baseUrl, string storageBasePath)
        {
            switch (type)
            {
                case BlobType.ProfileImage:
                    storageBasePath = baseUrl + userId + "/" + type.ToString().ToLower() + "_";
                    break;
                case BlobType.ProfileCover:
                    storageBasePath = baseUrl + userId + "/" + type.ToString().ToLower() + "_";
                    break;
                case BlobType.GameThumbnail:
                case BlobType.GameCover:
                case BlobType.ContentImage:
                case BlobType.FeaturedImage:
                default:
                    storageBasePath = baseUrl + userId + "/";
                    break;
            }

            return storageBasePath;
        }

        private static string GetDefaultImage(BlobType type)
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

        private static void OptimizeImage(MemoryStream ms)
        {
            ms.Position = 0;

            ImageOptimizer optimizer = new ImageOptimizer();
            optimizer.LosslessCompress(ms);

            //using (MagickImage image = new MagickImage(ms))
            //{
            //    image.Alpha(AlphaOption.Remove);
            //    image.BackgroundColor = MagickColors.White;
            //    image.Format = MagickFormat.Jpeg;

            //    image.Write(ms);
            //}
        }
        #endregion
    }
}