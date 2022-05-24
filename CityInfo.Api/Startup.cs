using Azure.Storage.Blobs;
using CityInfo.Api.Configurations;
using CityInfo.Api.Infrastructure;
using CityInfo.DataAccess;
using CityInfo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CityInfo.Api
{
    public record Startup(IConfiguration Configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwagger();
            services.AddServices();
            services.AddDbContext<SqlContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SqlContextProd")));
            services.AddJWTAuthorization(Configuration);
            services.AddAutoMapper(typeof(ApiMappingProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseCustomSwagger();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
