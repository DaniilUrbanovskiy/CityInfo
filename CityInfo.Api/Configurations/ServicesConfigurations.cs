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
           
        }
    }
}
