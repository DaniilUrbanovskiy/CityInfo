using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityInfo.DataImport
{
    public class RequestModel
    {
        public static async Task AddCountry(string name, int i)
        {
            var _httpClient = new HttpClient();

            var formContent = new MultipartFormDataContent();

            var FilePath = @"C:\\Users\\Daniil\\images\\" + i + ".jpg";

            formContent.Add(new StreamContent(File.OpenRead(FilePath)));

            await _httpClient.PostAsync($"https://localhost:44396/admin/country/{name}", formContent);
        }
    }
}
