using IndieVisible.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace IndieVisible.Application.Services
{
    public class AzureCloudStorageService : IImageStorageService
    {
        private readonly IConfiguration _config;
        private CloudStorageAccount storageAccount;

        public AzureCloudStorageService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> StoreImageAsync(string container, string fileName, byte[] image)
        {
            string storageConnectionString = _config["Storage:ConnectionString"];

            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                // If the connection string is valid, proceed with operations against Blob storage here.
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);
                bool created = await cloudBlobContainer.CreateIfNotExistsAsync();
                if (created)
                {
                    // Set the permissions so the blobs are public.
                    BlobContainerPermissions permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    };

                    await cloudBlobContainer.SetPermissionsAsync(permissions);
                }

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                if (image != null)
                {
                    await cloudBlockBlob.UploadFromByteArrayAsync(image, 0, image.Length);
                }
            }

            return fileName;
        }

        public async Task<string> DeleteImageAsync(string container, string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string storageConnectionString = _config["Storage:ConnectionString"];

                if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
                {
                    // If the connection string is valid, proceed with operations against Blob storage here.
                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);

                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);

                    await cloudBlockBlob.DeleteIfExistsAsync();
                }
            }

            return fileName;
        }
    }
}