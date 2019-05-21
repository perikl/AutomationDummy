using OpenQA.Selenium;
using System.Threading;

namespace ToptalTestAutomation.Pages
{
    public class LoginPage : BasePage
    {
        public const string pageUrl = "http://perikl.com/wp-admin/";

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement loginTextBox => _driver.FindElement(By.Id("user_login"));

        private IWebElement pwdTextBox => _driver.FindElement(By.Id("user_pass"));
                
        private IWebElement loginButton => _driver.FindElement(By.Id("wp-submit"));

        public void Login(string login, string password)
        {
            loginTextBox.SendKeys(login);
            Thread.Sleep(500);
            pwdTextBox.SendKeys(password);
            Thread.Sleep(500);
            loginButton.Click();            
        }
        
    }
}
