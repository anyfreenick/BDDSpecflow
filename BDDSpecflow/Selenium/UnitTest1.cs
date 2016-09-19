using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDSpecflow.Selenium;
using BDDSpecflow.Selenium.PageObjects;
using OpenQA.Selenium;

namespace BDDSpecflow.Selenium
{
    [TestClass]
    public class UnitTest1
    {

        private static CartPage cartpage;
        //[TestMethod]
        public void TestMethod1()
        {
            WebDriver driver = WebDriver.GetInstance(DriverType.Chrome);
            MainPage mainpage = new MainPage(driver.Driver);
            mainpage.Open();
            mainpage.OpenJewlryParagraph();
            FineJewelryPage jewelPage = new JewelryAndWatchesPage(driver.Driver).OpenFineJewelryPage();
            int a = jewelPage.Items.Count;
            jewelPage.SetMetal();
            Assert.IsTrue(jewelPage.MetalSet(), "Error while selecting metal");
            ItemInfoPage iteminfo = jewelPage.OpenItemInfoPage(3);
            string str = iteminfo.GetItemName();
            if (iteminfo.QtyTextBox != null)
            {
                Assert.IsTrue(iteminfo.QtyTextBox.GetAttribute("value") == 1.ToString());
            }

            for (int i = 1; i < a; i++)
            {
                if (iteminfo.AddToCartButton != null)
                {
                    cartpage = iteminfo.AddToCart();
                    break;
                }
                else
                {
                    driver.Driver.Navigate().Back();
                    jewelPage.OpenItemInfoPage(i);
                }
            }
            int b = cartpage.GetTotalItemsInCart();

        }
    }
}
