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
            SwitchToEnglish();
        }

        private IWebElement LanguageLink
        {
            get { return _driver.FindElement(By.Id("gh-eb-Geo-a-default")); }
        }

        private IWebElement EnglishLangLink
        {
            get { return _driver.FindElement(By.Id("gh-eb-Geo-a-en")); }            
        }

        private IWebElement FashionLink
        {
            get { return _driver.FindElement(By.XPath("//a[text() = 'Fashion']/..")); }
        }
        
        private IWebElement JewelryAndWatches
        {
            get { return _driver.FindElement(By.XPath("//a[@title = 'Fashion - Jewelry & Watches']")); }
        }   

        private void SwitchToEnglish()
        {
            LanguageLink.Click();
            EnglishLangLink.Click();
        }

        public void OpenJewlryParagraph()
        {
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            js.ExecuteScript("document.querySelector('a[title=\"Fashion - Jewelry & Watches\"]').click()");
        }
    }
}
