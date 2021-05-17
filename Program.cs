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

            var BaseUrl = "http://testing.todorvachev.com";

            // Search using Selenium for the element Name
            driver.Navigate().GoToUrl(BaseUrl + "/selectors/name/");

            IWebElement element = driver.FindElement(By.Name("myName"));

            if(element.Displayed) GreenMessage("I can see the search by Name!");

            // Search using Selenium for the element Id
            driver.Navigate().GoToUrl(BaseUrl + "/selectors/id/");

            element = driver.FindElement(By.Id("testImage"));

            if(element.Displayed) GreenMessage("I can see the search by Id!");

            // Search using Selenium for the element Class Name
            driver.Navigate().GoToUrl(BaseUrl + "/selectors/class-name/");

            element = driver.FindElement(By.ClassName("testClass"));

            if(element.Displayed) GreenMessage($"I can see the search by Class Name! His text is \"{element.Text}\"");

            driver.Quit();
        }

        private static void RedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void GreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
