using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using BDDSpecflow.Selenium;
using BDDSpecflow.Selenium.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDDSpecflow.Specflow.StepDefenitions
{
    [Binding]
    public sealed class LoginNegative
    {

        static WebDriver driver;
        LoginPage loginpage;

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [Given]
        public void GivenAliexpressSignInPageIsOpen()
        {
            driver = WebDriver.GetInstance(DriverType.Chrome);
            loginpage = new LoginPage(driver.Driver);
            loginpage.Open();
        }

        [When(@"I set Account ""(.*)""")]
        public void WhenISetAccount(string login)
        {
            loginpage.LoginField.SendKeys(login);
        }

        [When(@"I set Password ""(.*)""")]
        public void WhenISetPassword(string password)
        {
            loginpage.PasswordField.SendKeys(password);
        }

        [When(@"I click SignIn button")]
        public void WhenIClickSignInButton()
        {
            loginpage.SubmitButton.Click();
        }

        [Then(@"I get error ""(.*)""")]
        public void ThenIGetError(string errorMessage)
        {
            Assert.IsTrue(loginpage.LoginErrorMessageText == errorMessage);
        }

        [AfterFeature]
        static public void ThenBrowserIsClosed()
        {
            driver.Driver.Quit();
        }
    }
}
