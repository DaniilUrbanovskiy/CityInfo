using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CityInfo.DataAccess;
using CityInfo.Domain.Entities;
using CityInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Services
{
    public class AdminService
    {
        private readonly SqlContext _context;
        private readonly BlobServiceClient _blobServiceClient;
        public AdminService(SqlContext context, BlobServiceClient blobServiceClient)
        {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        public async Task AddCountry(string name, Image image)
        {
            var imageUrl = await AddFileToBlob(image);
            _context.Countries.Add(new Country() 
            {
                Name = name,
                Flag = imageUrl
            });
            _context.SaveChanges();
        }

        public async Task RemoveCountry(string name)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Name == name);
            var imageUrl = country.Flag.Split("/").LastOrDefault();
            _context.Countries.Remove(country);
            await RemoveFileToBlob(imageUrl);
            _context.SaveChanges();
        }

        private async Task<string> AddFileToBlob(Image image) 
        {
            var settings = AppsettingsProvider.GetJsonAppsettingsFile();
            var blobContainer = _blobServiceClient.GetBlobContainerClient(settings["AzureBlob:BlobName"]);
            var blobClient = blobContainer.GetBlobClient(image.Name);
            var blobHttpHeader = new BlobHttpHeaders { ContentType = image.ContentType };
            await blobClient.UploadAsync(image.Body, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
            return $"{settings["AzureBlob:BlobUrl"]}/{settings["AzureBlob:BlobName"]}/{image.Name}";
        }
        private async Task RemoveFileToBlob(string name) 
        {
            var settings = AppsettingsProvider.GetJsonAppsettingsFile();
            var blobContainer = _blobServiceClient.GetBlobContainerClient(settings["AzureBlob:BlobName"]);
            var blobClient = blobContainer.GetBlobClient(name);
            await blobClient.DeleteAsync();
        }
    }
}