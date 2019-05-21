using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ToptalTestAutomation.Engine
{
    public class DriverContext : BaseDriver
    {        
        private static ChromeDriver _driver;
        private static WebDriverWait _wait;


        public ChromeDriver Driver
        {
            get
            {
                if(_driver == null)
                {
                    _driver = new ChromeDriver();
                    _driver.Url = config["Url"];
                }
                return _driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                if(_wait == null)
                {
                    _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                }
                return _wait;
            }
        }

        public DriverContext() : base()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());            
        }
    }
}
