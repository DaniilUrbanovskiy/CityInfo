using Azure.Storage.Blobs;
using CityInfo.Api.Infrastructure;
using CityInfo.DataAccess;
using CityInfo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.Api.Configurations
{
    public static class ServicesConfigurations
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<AdminService>();
            services.AddTransient<UserService>();
            services.AddTransient<CityService>();
            services.AddTransient<CountryService>();
            services.AddTransient(x => {
                return new BlobServiceClient(AppsettingsProvider.GetJsonAppsettingsFile()["ConnectionStrings:AzureBlobStorage"]);
            });

        }
    }
}
