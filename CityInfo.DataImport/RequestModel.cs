using RestSharp;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityInfo.DataImport
{
    public class RequestModel
    {
        public static async Task AddCountry(string name, string pathToFlagName)
        {
            var client = new RestClient($"https://localhost:44396/admin/country/{name}");
            var request = new RestRequest(string.Empty, Method.Post);
            request.AddFile("flag", System.IO.File.ReadAllBytes(pathToFlagName), name+".jpg");
            await client.ExecuteAsync(request);
        }
    }
}
