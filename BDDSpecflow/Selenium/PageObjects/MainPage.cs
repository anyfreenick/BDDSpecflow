using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BDDSpecflow.Selenium.PageObjects
{
    public class MainPage
    {
        private const string _url = "https://www.ebay.com/";
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(_url);
            _driver.Manage().Window.Maximize();
        }

        private IWebElement LanguageLink
        {
            get { return _driver.FindElement(By.Id("gh-eb-Geo-a-default")); }
        }

        private IWebElement EnglishLangLink
        {
            get { return _driver.FindElement(By.Id("gh-eb-Geo-a-en")); }
        }

        public void SwitchToEnglish()
        {
            LanguageLink.Click();
            EnglishLangLink.Click();
        }

        public void OpenJewlryParagraph()
        {

        }
    }
}
