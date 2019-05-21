using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToptalTestAutomation.Engine
{
    public abstract class BaseTest
    {
        public IWebDriver driver;
        public WebDriverWait wait;
    }
}
