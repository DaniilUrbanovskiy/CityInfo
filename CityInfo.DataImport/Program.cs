using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CityInfo.DataImport
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.worldometers.info/geography/flags-of-the-world/");

            var elements = driver.FindElements(By.ClassName("col-md-4"));

            int i = 0;
            foreach (var element in elements)
            {
                i++;
                await RequestModel.AddCountry(element.Text, i);
                Console.WriteLine($"Completed {i}");
            }

            //var images = driver.FindElements(By.TagName("img"));
            //int i = 0;
            //foreach (var image in images)
            //{
            //    i++;
            //    WebClient downloader = new WebClient();
            //    downloader.DownloadFile(image.GetAttribute("src"), "C:\\Users\\Daniil\\images\\" + i + ".jpg");
            //}



            //Настраиваешь селениум
            //Будешь скрапить по одной стране
            //заскрапил страну(ссылку на флаг + название страны)
            //Скачал на локальное устройство флаг*
            //Сделал запрос себе на апи AddCountry
            //Передал туда параметры
            //Старана записалась в базу!!!
        }
    }
}

