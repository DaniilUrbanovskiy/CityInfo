using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CityInfo.Api.Infrastructure
{
    public static class AppsettingsProvider
    {
        public static IConfigurationRoot GetJsonAppsettingsFile() => new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings.json", false)
           .Build();
    }
}
