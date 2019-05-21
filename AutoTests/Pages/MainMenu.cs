using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace ToptalTestAutomation.Pages
{
    public class MainMenu : BasePage
    {
        public MainMenu(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ProfileLink => _driver.FindElement(By.LinkText("Profile"));
        public IWebElement DisplayedNameLink => _driver.FindElement(By.ClassName("display-name"));
    }
}
