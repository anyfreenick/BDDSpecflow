using OpenQA.Selenium;

namespace BDDSpecflow.Selenium.PageObjects
{
    public class ItemInfoPage
    {
        private IWebDriver _driver;
        
        public ItemInfoPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AddToCartButton
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.Id("isCartBtn_btn"));
                }
                catch(NoSuchElementException)
                {
                    return null;
                }
            }
        }

        public IWebElement QtyTextBox
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.Id("qtyTextBox"));
                }
                catch(NoSuchElementException)
                {
                    return null;
                }
            }
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
