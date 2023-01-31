using Azure.Storage.Blobs;

namespace DSortAPI.Services
    {

    public class StorageServices : IStorageService
        {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public StorageServices(BlobServiceClient blobServiceClient, IConfiguration configuration)
            {
            _blobServiceClient= blobServiceClient;
            _configuration= configuration;
            }



        public void Upload(IFormFile formFile)
            {
            var containerName = _configuration.GetSection("Storage:ContainerName").Value;

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var bloblClient = containerClient.GetBlobClient(formFile.FileName);

            using var stream = formFile.OpenReadStream();
            bloblClient.Upload(stream, true);
            
            }
        }
    }
