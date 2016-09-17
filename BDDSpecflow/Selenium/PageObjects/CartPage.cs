using OpenQA.Selenium;

namespace BDDSpecflow.Selenium.PageObjects
{
    public class CartPage
    {
        private IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
