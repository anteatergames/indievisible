using IndieVisible.Application;
using IndieVisible.Application.Formatters;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Net;

namespace IndieVisible.Web.Controllers
{
    [Route("storage")]
    public class StorageController : SecureBaseController
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger logger;

        public StorageController(IHostingEnvironment hostingEnvironment
            , IHttpContextAccessor httpContextAccessor
            , ILogger<StorageController> logger)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }

        [ResponseCache(CacheProfileName = "Never")]
        [Route("userimage/{type:alpha}/{userId:guid}/{name?}")]
        public IActionResult UserImage(BlobType type, Guid userId, string name, string v)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = userId.ToString();
            }

            if (type == BlobType.ProfileImage)
            {
                name = String.Format("{0}_Personal", userId);
            }

            return GetImage(type, userId, name, v);
        }

        [ResponseCache(CacheProfileName = "Default")]
        [Route("image/{type:alpha}/{userId:guid}/{name}")]
        [Route("image/{name}")]
        [Route("image")]
        public IActionResult Image(BlobType type, Guid userId, string name, string v)
        {
            return GetImage(type, userId, name, v);
        }

        private IActionResult GetImage(BlobType type, Guid userId, string name, string v)
        {
            string baseUrl = Constants.DefaultCdnPath;
            name = name.Replace(Constants.DefaultImagePath, string.Empty);

            try
            {
                string storageBasePath = FormatBasePath(type, userId, baseUrl);

                string url = UrlFormatter.CdnCommon(userId, name);

                if (!string.IsNullOrWhiteSpace(v))
                {
                    url += "?v=" + v;
                }

                byte[] data;

                using (WebClient webClient = new WebClient())
                {
                    data = webClient.DownloadData(url);
                }

                string etag = ETagGenerator.GetETag(httpContextAccessor.HttpContext.Request.Path.ToString(), data);
                if (httpContextAccessor.HttpContext.Request.Headers.Keys.Contains(HeaderNames.IfNoneMatch) && httpContextAccessor.HttpContext.Request.Headers[HeaderNames.IfNoneMatch].ToString() == etag)
                {
                    return new StatusCodeResult(StatusCodes.Status304NotModified);
                }
                httpContextAccessor.HttpContext.Response.Headers.Add(HeaderNames.ETag, new[] { etag });

                return File(new MemoryStream(data), "image/jpeg");
            }
            catch (Exception ex)
            {
                string msg = $"Unable to save get the Image.";
                logger.Log(LogLevel.Error, ex, msg);

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

                        byte[] fileBytes = ms.ToArray();

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

                        byte[] fileBytes = ms.ToArray();

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

        #endregion Profile

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

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(image);

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;

                        imageUrl = base.UploadGameImage(userId, type, filename, fileBytes);
                    }
                }

                if (!string.IsNullOrWhiteSpace(currentImage) && !currentImage.Equals(defaultImage))
                {
                    string currentParam = GetImageNameFromUrl(currentImage);

                    base.DeleteGameImage(userId, type, currentParam);
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

        #endregion Game

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

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(upload);

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;

                        imageUrl = base.UploadContentImage(CurrentUserId, filename, fileBytes);
                    }
                }

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

                        byte[] fileBytes = ms.ToArray();

                        string extension = GetFileExtension(upload);

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;

                        imageUrl = base.UploadContentImage(CurrentUserId, filename, fileBytes);
                    }
                }

                var json = new
                {
                    uploaded = true,
                    url = UrlFormatter.Image(CurrentUserId, BlobType.ContentImage, imageUrl)
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

                if (!string.IsNullOrWhiteSpace(currentImage) && !currentImage.Equals(Constants.DefaultFeaturedImage))
                {
                    string currentParam = GetImageNameFromUrl(currentImage);

                    base.DeleteFeaturedImage(userId, currentParam);
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

        #endregion Content

        #region Private Methods

        private IActionResult ReturnDefaultImage(BlobType type)
        {
            string defaultImageNotRooted = UrlFormatter.GetDefaultImage(type);

            string retorno = Path.Combine(hostingEnvironment.WebRootPath, defaultImageNotRooted);

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

            return split;
        }

        private static string FormatBasePath(BlobType type, Guid userId, string baseUrl)
        {
            string storageBasePath = string.Empty;

            switch (type)
            {
                case BlobType.ProfileImage:
                    storageBasePath = baseUrl + userId + "/" + type.ToString().ToLower() + "_";
                    break;

                case BlobType.ProfileCover:
                    storageBasePath = baseUrl + userId + "/" + type.ToString().ToLower() + "_";
                    break;

                default:
                    storageBasePath = baseUrl + userId + "/";
                    break;
            }

            return storageBasePath;
        }

        #endregion Private Methods
    }
}