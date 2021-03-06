﻿using TechTalk.SpecFlow;
using BDDSpecflow.Selenium;
using BDDSpecflow.Selenium.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDDSpecflow.Specflow.StepDefenitions
{
    [Binding]
    public sealed class LoginNegativeSteps
    {

        static WebDriver driver;
        static LoginPage loginpage;

        [BeforeFeature]
        public static void SetupTests()
        {
            driver = WebDriver.GetInstance(DriverType.Chrome);
            loginpage = new LoginPage(driver.Driver);
        }

        [Given(@"Ebay Sign In page is open")]
        public void GivenEbaySignInPageIsOpen()
        {
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
