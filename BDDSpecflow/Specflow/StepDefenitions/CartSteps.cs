using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using BDDSpecflow.Selenium;
using BDDSpecflow.Selenium.PageObjects;

namespace BDDSpecflow.Specflow.StepDefenitions
{
    [Binding]
    public class CartSteps
    {

        private WebDriver driver;
        private MainPage mainpage;
        private FineJewelryPage jewelPage;
        private ItemInfoPage infoPage;
        private CartPage cartpage;
        private Random rnd;
        private int itemsOnPage;

        [BeforeScenario]
        public void SetupTests()
        {
            driver = WebDriver.GetInstance(DriverType.Chrome);
            mainpage = new MainPage(driver.Driver);
            jewelPage = new FineJewelryPage(driver.Driver);
            infoPage = new ItemInfoPage(driver.Driver);
            cartpage = new CartPage(driver.Driver);
            rnd = new Random();
        }

        [When(@"Ebay site is open")]
        public void WhenEbaySiteIsOpen()
        {
            mainpage.Open();
        }
        
        [When(@"Jewelry Sets paragraph is opened")]
        public void WhenJewelrySetsParagraphIsOpened()
        {
            mainpage.OpenJewlryParagraph();
            jewelPage = new JewelryAndWatchesPage(driver.Driver).OpenFineJewelryPage();
            itemsOnPage = jewelPage.Items.Count;
        }

        [When(@"Metal color is set")]
        public void WhenMetalColorIsSet()
        {
            jewelPage.SetMetal();
            Assert.IsTrue(jewelPage.MetalSet(), "Error while selecting metal type");
        }

        [When(@"Any item is chosen")]
        public void WhenAnyItemIsChosen()
        {
            jewelPage.OpenItemInfoPage(rnd.Next(1, 50));
        }        

        [When(@"Information page of the product is opened")]
        public void WhenInformationPageOfTheProductIsOpened()
        {
            Assert.IsTrue(infoPage.GetItemName() != null);
        }
        
        
        [When(@"Quantity of the product is (.*)")]
        public void WhenQuantityOfTheProductIs(int quantity)
        {
            if (infoPage.QtyTextBox != null)
            {
                Assert.IsTrue(infoPage.QtyTextBox.GetAttribute("value") == quantity.ToString());
            }
        }
        
        [When(@"The product is added into the cart")]
        public void WhenTheProductIsAddedIntoTheCart()
        {
            for(int i = 1; i < itemsOnPage; i++)
            {
                if (infoPage.AddToCartButton != null)
                {
                    cartpage = infoPage.AddToCart();
                    break;
                }
                else
                {
                    driver.Driver.Navigate().Back();
                    jewelPage.OpenItemInfoPage(i);
                }
            }
        }
        
        [When(@"(.*) items with different names are added into the cart")]
        public void WhenItemsWithDifferentNamesAreAddedIntoTheCart(int itemsToAddToCart)
        {
            for (int i = 0; i < itemsToAddToCart; i++)
            {
                jewelPage.OpenItemInfoPage(rnd.Next(0, itemsOnPage));
                for (int j = 1; j < itemsOnPage; j++)
                {
                    if (infoPage.AddToCartButton != null)
                    {
                        cartpage = infoPage.AddToCart();
                        if (i == 2)
                            break;
                        driver.Driver.Navigate().Back();
                        driver.Driver.Navigate().Back();
                        break;
                    }
                    else
                    {
                        driver.Driver.Navigate().Back();
                        jewelPage.OpenItemInfoPage(rnd.Next(0, itemsOnPage));
                    }
                }
            }
        }
        
        [Then(@"There is/are (.*) item/items in the cart")]
        public void ThenThereIsAreItemItemsInTheCart(int itemsInCart)
        {
            Assert.IsTrue(cartpage.GetItemsCount() == itemsInCart, "There not " + itemsInCart + " items in the cart");
        }
        
        [Then(@"Summary Quantity all items in the cart are equals (.*)")]
        public void ThenSummaryQuantityAllItemsInTheCartAreEquals(int itemsInCart)
        {
            Assert.IsTrue(cartpage.GetTotalItemsInCart() == itemsInCart, "There not " + itemsInCart + " items in the cart");
        }

        [AfterScenario]
        public void ThenBrowserIsClosed()
        {
            driver.Driver.Quit();
            driver.NullDriver();
        }
    }
}
