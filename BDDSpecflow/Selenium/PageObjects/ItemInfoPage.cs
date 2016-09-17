using OpenQA.Selenium;

namespace BDDSpecflow.Selenium.PageObjects
{
    class ItemInfoPage
    {
        private IWebDriver _driver;
        
        public ItemInfoPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement AddToCartButton
        {
            get { return _driver.FindElement(By.Id("isCartBtn_btn")); }
        }

        public CartPage AddToCart()
        {
            AddToCartButton.Click();
            return new CartPage(_driver);
        }

        public string GetItemName()
        {
            return _driver.FindElement(By.Id("itemTitle")).Text;            
        }
    }
}
