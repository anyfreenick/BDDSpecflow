using OpenQA.Selenium;

namespace BDDSpecflow.Selenium.PageObjects
{
    class JewelryAndWatchesPage
    {
        private IWebDriver _driver;

        public JewelryAndWatchesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FineJewlryLink
        {
            get { return _driver.FindElement(By.XPath("//span[text() = 'Fine Jewelry']")); }
        }

        public FineJewelryPage OpenFineJewelryPage()
        {
            FineJewlryLink.Click();
            return new FineJewelryPage(_driver);
        }
    }
}
