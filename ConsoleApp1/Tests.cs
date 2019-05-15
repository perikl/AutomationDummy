using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp1
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {            
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Url = "http://www.duckduckgo.com";
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Test()
        {
            var textbox = driver.FindElement(By.CssSelector("#search_form_input_homepage"));
            textbox.SendKeys("toptal");
            var buttonSearch = driver.FindElement(By.CssSelector("#search_button_homepage"));
            buttonSearch.Click();
            wait.Until((d) => d.FindElements(By.CssSelector("div#links a.result__a"))[0]);
            var firstElem = driver.FindElements(By.CssSelector("div#links a.result__a"))[0];
            firstElem.Click();
            
            wait.Until((d) => d.Url == "https://www.toptal.com/");            
            Assert.IsTrue(driver.Url == "https://www.toptal.com/");
        }

        [TearDown]
        public void End()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
