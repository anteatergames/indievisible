using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using IndieVisible.Application.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IndieVisible.Application.Services
{
    public class CloudinaryService : IImageStorageService
    {
        public CloudinaryService()
        {
        }

        public async Task<string> StoreImageAsync(string container, string fileName, byte[] image)
        {
            Cloudinary cloudinary = new Cloudinary();

            string publicId = String.Format("{0}/{1}", container, fileName);

            MemoryStream stream = new MemoryStream(image);

            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                PublicId = publicId,
                File = new FileDescription(fileName, stream),
                Invalidate = true
            };

            ImageUploadResult uploadResult = await cloudinary.UploadAsync(uploadParams);

            return fileName;
        }

        public async Task<string> DeleteImageAsync(string container, string fileName)
        {
            Cloudinary cloudinary = new Cloudinary();

            string publicId = String.Format("{0}/{1}", container, fileName);

            DelResResult result = await cloudinary.DeleteResourcesAsync(publicId);

            return fileName;
        }
    }
}