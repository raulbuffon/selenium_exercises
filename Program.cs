using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            var Url = "http://testing.todorvachev.com";

            driver.Navigate().GoToUrl(Url);

            Thread.Sleep(3000);

            driver.Quit();
        }
    }
}
