using RestSharp;
using System.IO;
using System.Threading.Tasks;

namespace CityInfo.DataImport
{
    public class Requests
    {
        public static async Task AddCountry(string name, string pathToFlagName)
        {
            var client = new RestClient($"https://localhost:44396/admin/country/{name}");
            var request = new RestRequest(string.Empty, Method.Post);
            request.AddFile("flag", File.ReadAllBytes(pathToFlagName), name+".jpg");
            await client.ExecuteAsync(request);
        }
        public static async Task AddCity(string cityName, string countryName, string info, string pathToCityImageName)
        {
            var client = new RestClient($"https://localhost:44396/admin/city/{cityName}/country/{countryName}?info={info}");
            var request = new RestRequest(string.Empty, Method.Post);
            request.AddFile("cityImage", File.ReadAllBytes(pathToCityImageName), cityName + ".png");
            await client.ExecuteAsync(request);
        }
    }
}
