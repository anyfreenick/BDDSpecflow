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

        private static WebDriver driver;
        private static MainPage mainpage;
        private static FineJewelryPage jewelPage;
        private static ItemInfoPage infoPage;
        static Random rnd;

        [BeforeFeature]
        public static void SetupTests()
        {
            driver = WebDriver.GetInstance(DriverType.Chrome);
            mainpage = new MainPage(driver.Driver);
            jewelPage = new FineJewelryPage(driver.Driver);
            infoPage = new ItemInfoPage(driver.Driver);
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
            infoPage = jewelPage.OpenItemInfoPage(rnd.Next(1, 50));
        }
        
        [When(@"Information page of the product is opened")]
        public void WhenInformationPageOfTheProductIsOpened()
        {
            Assert.IsTrue(infoPage.GetItemName() != null);
        }
        
        
        [When(@"Quantity of the product is (.*)")]
        public void WhenQuantityOfTheProductIs(int quantity)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"The product is added into the cart")]
        public void WhenTheProductIsAddedIntoTheCart()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"(.*) items with different names are added into the cart")]
        public void WhenItemsWithDifferentNamesAreAddedIntoTheCart(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"There is/are (.*) item/items in the cart")]
        public void ThenThereIsAreItemItemsInTheCart(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Summary Quantity all items in the cart are equals (.*)")]
        public void ThenSummaryQuantityAllItemsInTheCartAreEquals(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        //[AfterFeature]
        static public void ThenBrowserIsClosed()
        {
            driver.Driver.Quit();
        }
    }
}
