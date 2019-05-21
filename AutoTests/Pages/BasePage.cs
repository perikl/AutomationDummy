using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToptalTestAutomation.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;        

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
