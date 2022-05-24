using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace CityInfo.DataImport
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //45.142.37.169:47166        u98icAnr         bcZPYLEQ

            Proxy proxy = new Proxy();
            proxy.SslProxy = "45.142.37.169:47166";
            ChromeOptions options = new ChromeOptions();
            options.Proxy = proxy;

            IWebDriver driver = new ChromeDriver(options);

            //    await AddCountries(driver);
            //    await AddCities(driver);
        }
        private static async Task AddCountries(IWebDriver driver)
        {
            WebClient downloader = new WebClient();
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
                await Requests.AddCountry(countryName, pathToFlag);
            }
        }
        private static async Task AddCities(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.delicious.com.au/travel/international/gallery/100-cities-deserve-place-travel-bucket-list/o4lzlr69?page=100");

            var elements = driver.FindElements(By.ClassName("slide"));

            Actions action = new Actions(driver);

            for (int i = 0; i < elements.Count; i++)
            {
                var cityCountry = elements[i].FindElement(By.ClassName("slide-title")).Text.Replace(" ", "").Split(",");

                var cityName = cityCountry[0];
                var countryName = cityCountry[1];

                var info = elements[i].FindElement(By.ClassName("description")).Text;

                var cityImageLink = elements[i].FindElement(By.TagName("img")).GetAttribute("src");

                var pathToCityImage = Path.Combine("C:", "Users", "Daniil", "images", cityName + ".png");

                ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Navigate().GoToUrl(cityImageLink);

                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(pathToCityImage, ScreenshotImageFormat.Png);

                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.FirstOrDefault());

                await Requests.AddCity(cityName, countryName, info, pathToCityImage);
            }
        }
    }
}

