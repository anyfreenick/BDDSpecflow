using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace BDDSpecflow.Selenium.PageObjects
{
    public class FineJewelryPage
    {
        private IWebDriver _driver;
        private Random rnd = new Random();

        public FineJewelryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement PlatinumSelectedFilter
        {
            get { return _driver.FindElement(By.XPath("//span[text() = 'Platinum']/..")); }
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

        public bool MetalSet()
        {
            if (PlatinumSelectedFilter.Displayed)
                if (PlatinumSelectedFilter.GetAttribute("data-key") == "Metal")
                    if (PlatinumSelectedFilter.GetAttribute("data-name") == "Platinum")
                        return true;
            return false;
        }

        public ItemInfoPage OpenItemInfoPage(int itemIndex)
        {
            Items[itemIndex].Click();
            return new ItemInfoPage(_driver);
        }
    }
}
