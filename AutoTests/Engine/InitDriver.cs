using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
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
                    if(_driver == null)
                    {
                        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    }
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
