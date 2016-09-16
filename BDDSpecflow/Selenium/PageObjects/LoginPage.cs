using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSpecflow.Selenium.PageObjects
{
    public class LoginPage
    {
        private const string _url = "https://signin.ebay.com/";
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LoginField
        {
            get { return _driver.FindElement(By.XPath("(//div[@id='pri_signin']//input[@class='fld'])[1]")); }
        }

        public IWebElement PasswordField
        {
            get { return _driver.FindElement(By.XPath("(//div[@id='pri_signin']//input[@class='fld'])[2]")); }
        }

        public IWebElement SubmitButton
        {
            get { return _driver.FindElement(By.Id("sgnBt")); }
        }

        public IWebElement LoginErrorMessage
        {
            get { return _driver.FindElement(By.Id("errf")); }
        }

        public string LoginErrorMessageText
        {
            get { return LoginErrorMessage.GetAttribute("aria-describedby"); }
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(_url);
            _driver.Manage().Window.Maximize();
        }

        public bool ErrorMessageDisplayed()
        {
            if (LoginErrorMessage.Displayed)
                return true;
            else
                return false;
        }
    }
}
