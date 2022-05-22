using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CityInfo.DataImport
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            WebClient downloader = new WebClient();
            IWebDriver driver = new ChromeDriver();

            //await AddCountries(downloader, driver);

            //use this with cities
            //https://www.delicious.com.au/travel/international/gallery/100-cities-deserve-place-travel-bucket-list/o4lzlr69
        }
        private static async Task AddCountries(WebClient downloader, IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.worldometers.info/geography/flags-of-the-world/");

            var elements = driver.FindElements(By.ClassName("col-md-4"));

            for (int i = 0; i < elements.Count; i++)
            {
                var countryName = elements[i].Text;
                if (string.IsNullOrWhiteSpace(countryName))
                {
                    break;
                }
                var countryFlagLink = elements[i].FindElement(By.TagName("img")).GetAttribute("src");

                var pathToFlag = Path.Combine("C:", "Users", "Daniil", "images", countryName + ".jpg");

                downloader.DownloadFile(countryFlagLink, pathToFlag);
                await RequestModel.AddCountry(countryName, pathToFlag);
            }
        }
    }
}

