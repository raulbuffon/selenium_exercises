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

            var baseUrl = "http://testing.todorvachev.com";

            // Search using Selenium for the element Name
            FindByName(baseUrl, driver);

            // Search using Selenium for the element Id
            FindById(baseUrl, driver);

            // Search using Selenium for the element Class Name
            FindByClassName(baseUrl, driver);

            // Search using Selenium for the element CSS path
            FindByCssPath(baseUrl, driver);

            // Search using Selenium for the element X path
            FindByXPath(baseUrl, driver);
            
            // Exception handle if dont find the element in search
            FindHandlingException(baseUrl, driver);

            HandleTextInputField(baseUrl, driver);

            driver.Quit();
        }

        public static void FindByName(string baseUrl, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl + "/selectors/name/");
            IWebElement element = driver.FindElement(By.Name("myName"));
            if(element.Displayed) PrintMessage.Green("I can see the search by Name!");
        }

        public static void FindById(string baseUrl, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl + "/selectors/id/");
            IWebElement element = driver.FindElement(By.Id("testImage"));
            if(element.Displayed) PrintMessage.Green("I can see the search by Id!");
        }

        public static void FindByClassName(string baseUrl, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl + "/selectors/class-name/");
            IWebElement element = driver.FindElement(By.ClassName("testClass"));
            if(element.Displayed) PrintMessage.Green($"I can see the search by Class Name! His text is \"{element.Text}\"");
        }

        public static void FindByCssPath(string baseUrl, IWebDriver driver)
        {
            var cssPath = "#post-108 > div > figure > img";
            driver.Navigate().GoToUrl(baseUrl + "/selectors/css-path/");
            IWebElement element = driver.FindElement(By.CssSelector(cssPath));
            if(element.Displayed) PrintMessage.Green($"I can see the search by Css Path");
        }

        public static void FindByXPath(string baseUrl, IWebDriver driver)
        {
            var xPath = "//*[@id=\"post-108\"]/div/figure/img";
            driver.Navigate().GoToUrl(baseUrl + "/selectors/css-path/");
            IWebElement element = driver.FindElement(By.XPath(xPath));
            if(element.Displayed) PrintMessage.Green($"I can see the search by X Path");            
        }

        public static void FindHandlingException(string baseUrl, IWebDriver driver)
        {
            var wrongXPath = "//*[@id=\"post-1088888\"]/div/figure/img";
            driver.Navigate().GoToUrl(baseUrl + "/selectors/css-path/");
            try
            {   
                IWebElement element = driver.FindElement(By.XPath(wrongXPath));
                if(element.Displayed) PrintMessage.Green($"I can see the search by X Path");
            }
            catch(NoSuchElementException)
            {
                PrintMessage.Red($"I cannot see the search by X Path, something is wrong here ;-;");
            }
        }

        public static void HandleTextInputField(string baseUrl, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl + "/special-elements/text-input-field/");
            IWebElement element = driver.FindElement(By.Name("username"));
            element.SendKeys("Test text");
            PrintMessage.Green($"The entry is: {element.GetAttribute("value")}");                
        }         
    }
}
