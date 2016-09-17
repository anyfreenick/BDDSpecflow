using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BDDSpecflow.Selenium.PageObjects
{
    class FineJewelryPage
    {
        private IWebDriver _driver;
        private Random rnd = new Random();

        public FineJewelryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement PlatinumCheckBox
        {
            get { return _driver.FindElement(By.Id("e1-17")); }
        }

        public List<IWebElement> Items
        {
            get { return _driver.FindElements(By.XPath("//a[contains(@class,'vip')]")).ToList(); }
        }

        public void SetMetal()
        {
            PlatinumCheckBox.Click();
        }
    }
}
