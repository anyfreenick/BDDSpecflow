using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BDDSpecflow.Selenium.PageObjects
{
    public class CartPage
    {
        private IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private string Subtotal
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.XPath("//div[text()[contains(.,'Subtotal')]]")).Text;
                }
                catch(NoSuchElementException)
                {
                    return null;
                }
            }
        }

        public int GetTotalItemsInCart()
        {
            Regex pattern = new Regex(@".+\(([0-9]+).+\).+");
            Match match = pattern.Match(Subtotal);
            int itemsInCart = int.Parse(match.Groups[1].Value);
            return itemsInCart;
        }
        
        public int GetItemsCount()
        {
            try
            {
                return _driver.FindElements(By.XPath("//div[contains(@id, 'sellerBucket')]")).Count;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}
