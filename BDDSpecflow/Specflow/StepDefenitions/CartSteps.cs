using System;
using TechTalk.SpecFlow;
using BDDSpecflow.Selenium;
using BDDSpecflow.Selenium.PageObjects;

namespace BDDSpecflow.Specflow.StepDefenitions
{
    [Binding]
    public class CartSteps
    {

        static WebDriver driver;
        static MainPage mainpage;

        [BeforeFeature]
        public static void SetupTests()
        {
            driver = WebDriver.GetInstance(DriverType.Chrome);
            mainpage = new MainPage(driver.Driver);
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
            FineJewelryPage jewelPage = new JewelryAndWatchesPage(driver.Driver).OpenFineJewelryPage();
        }

        [When(@"Metal color is set")]
        public void WhenMetalColorIsSet()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Any item is chosen")]
        public void WhenAnyItemIsChosen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Information page of the product is opened")]
        public void WhenInformationPageOfTheProductIsOpened()
        {
            ScenarioContext.Current.Pending();
        }
        
        
        [When(@"Quantity of the product is (.*)")]
        public void WhenQuantityOfTheProductIs(int p0)
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
