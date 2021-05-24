using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_elements
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

            HandleCheckBox(baseUrl, driver);

            HandleRadioButton(baseUrl, driver);

            HandleDropDownMenu(baseUrl, driver);

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

        public static void HandleCheckBox(string baseUrl, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl + "/special-elements/check-button-test-3/");
            IWebElement element = driver.FindElement(By.CssSelector("#post-33 > div > p:nth-child(8) > input[type=checkbox]:nth-child(1)"));
            element.Click();
            if(element.GetAttribute("checked") == "true")
            {
                PrintMessage.Green($"The checkbox value is checked: {element.GetAttribute("value")}");
            }
            else
            {
                PrintMessage.Red($"The checkbox value is unchecked: {element.GetAttribute("value")}");
            }
        }

        public static void HandleRadioButton(string baseUrl, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl + "/special-elements/radio-button-test/");
            IWebElement element = driver.FindElement(By.CssSelector("#post-10 > div > form > p:nth-child(6) > input[type=radio]:nth-child(1)"));
            element.Click();
            if(element.GetAttribute("checked") == "true")
            {
                PrintMessage.Green($"The radio button is checked with value: {element.GetAttribute("value")}");
            }
            else
            {
                PrintMessage.Red($"The radio button is unchecked with value: {element.GetAttribute("value")}");
            }
        }

        public static void HandleDropDownMenu(string baseUrl, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl + "/special-elements/drop-down-menu-test/");
            IWebElement elementFromDropDownMenu = driver.FindElement(By.CssSelector("#post-6 > div > p:nth-child(6) > select > option:nth-child(3)"));
            IWebElement elementSelectedInDropDownMenu = driver.FindElement(By.Name("DropDownTest"));
            PrintMessage.Green($"The selected value is: {elementSelectedInDropDownMenu.GetAttribute("value")}");
            PrintMessage.Green($"The third value in drop down menu is: {elementFromDropDownMenu.GetAttribute("value")}");
            elementFromDropDownMenu.Click();
            PrintMessage.Green($"The new selected value is: {elementSelectedInDropDownMenu.GetAttribute("value")}");
        }
    }
}
