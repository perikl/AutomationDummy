using NUnit.Framework;
using ToptalTestAutomation.Engine;
using ToptalTestAutomation.Pages;

namespace ToptalTestAutomation
{
    [TestFixture]
    public class WebTests : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            var driverContext = new DriverContext();
            driver = driverContext.Driver;
            wait = driverContext.Wait;
            driver.Navigate().GoToUrl(driverContext.GetConfig()["url"]);
            LoginPage loginPage = new LoginPage(driver);            
            loginPage.Login(driverContext.GetConfig()["login"], driverContext.GetConfig()["password"]);
            
        }

        [Test]
        public void ChangeNameProfileTest()
        {
            string newname = "newname";
            MainMenu menu = new MainMenu(driver);            
            wait.Until(d => menu.ProfileLink);
            menu.ProfileLink.Click();
            ProfilePage profilepage = new ProfilePage(driver);
            wait.Until(d => profilepage.UpdateProfileButton);
            profilepage.FirstNameTextbox.Clear();
            profilepage.FirstNameTextbox.SendKeys(newname);            
            profilepage.SelectDisplayname(newname);
            Assert.IsTrue(menu.DisplayedNameLink.Text.Equals(newname),"New firstname is not applied as displayed name");
            
        }

        [Test]
        public void UsernameCannotBechangedTest()
        {
            MainMenu menu = new MainMenu(driver);            
            wait.Until(d => menu.ProfileLink);
            menu.ProfileLink.Click();
            ProfilePage profilepage = new ProfilePage(driver);
            wait.Until(d => profilepage.UpdateProfileButton);            
            Assert.IsTrue(profilepage.UsernameTextbox.GetAttribute("disabled") == "true","Username textbox is not disabled");
        }

        [Test]
        public void DisplayedNameNotSavedWithoutSubmitTest()
        {
            string newname = "newlast";
            MainMenu menu = new MainMenu(driver);            
            wait.Until(d => menu.ProfileLink);
            menu.ProfileLink.Click();
            ProfilePage profilepage = new ProfilePage(driver);
            wait.Until(d => profilepage.UpdateProfileButton);
            profilepage.LastNameTextbox.Clear();
            profilepage.LastNameTextbox.SendKeys(newname);
            profilepage.SelectDisplayname(newname);
            Assert.IsTrue(menu.DisplayedNameLink.Text.Equals(newname), "New lastname is not applied as displayed name");
            menu.ProfileLink.Click();
            Assert.IsFalse(menu.DisplayedNameLink.Text.Equals(newname), "New lastname should not applied as displayed name after page refresh");
        }

        [Test]
        public void DisplayedNameSaveBySubmitTest()
        {
            string newname = "newnick";
            MainMenu menu = new MainMenu(driver);
            wait.Until(d => menu.ProfileLink);
            menu.ProfileLink.Click();
            ProfilePage profilepage = new ProfilePage(driver);
            wait.Until(d => profilepage.UpdateProfileButton);
            string oldNickname = profilepage.NicknameTextbox.GetAttribute("value");
            string oldname = menu.DisplayedNameLink.Text;
            profilepage.NicknameTextbox.Clear();
            profilepage.NicknameTextbox.SendKeys(newname);
            profilepage.SelectDisplayname(newname);
            Assert.IsTrue(menu.DisplayedNameLink.Text.Equals(newname), "New nickname is not applied as displayed name");
            profilepage.UpdateProfileButton.Click();
            menu.ProfileLink.Click();
            Assert.IsTrue(menu.DisplayedNameLink.Text.Equals(newname), "New nickname is not applied as displayed name after submit");

            profilepage.NicknameTextbox.Clear();
            profilepage.NicknameTextbox.SendKeys(oldNickname);
            profilepage.SelectDisplayname(oldname);
            profilepage.UpdateProfileButton.Click();
        }

        [OneTimeTearDown]
        public void End()
        {
            driver.Close();
            driver.Quit();            
        }
    }
    
}
