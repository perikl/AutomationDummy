using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToptalTestAutomation.Pages
{
    public class ProfilePage : BasePage
    {
        public const string adress = "profile.php";

        public ProfilePage(IWebDriver driver) : base(driver)
        {
        }
                
        public IWebElement FirstNameTextbox => _driver.FindElement(By.Id("first_name"));

        public IWebElement UsernameTextbox => _driver.FindElement(By.Id("user_login"));

        public IWebElement LastNameTextbox => _driver.FindElement(By.Id("last_name"));

        public IWebElement NicknameTextbox => _driver.FindElement(By.Id("nickname"));

        private IWebElement _displaynameCmb => _driver.FindElement(By.Id("display_name"));
        public void SelectDisplayname(string name)
        {
            _displaynameCmb.Click();
            var displaynameSelect = new SelectElement(_displaynameCmb);            
            displaynameSelect.SelectByText(name);
        }


        public IWebElement UpdateProfileButton => _driver.FindElement(By.Id("submit"));
    }
}
