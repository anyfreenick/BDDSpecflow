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
        [TestMethod]
        public void TestMethod1()
        {
            WebDriver driver = WebDriver.GetInstance(DriverType.Chrome);
            MainPage mainpage = new MainPage(driver.Driver);
            mainpage.Open();
            mainpage.OpenJewlryParagraph();
            FineJewelryPage jewelPage = new JewelryAndWatchesPage(driver.Driver).OpenFineJewelryPage();
            jewelPage.SetMetal();
            Assert.IsTrue(jewelPage.MetalSet(), "Error while selecting metal");
            ItemInfoPage iteminfo = jewelPage.OpenItemInfoPage(5);
            string str = iteminfo.GetItemName();
            iteminfo.AddToCart();
        }
    }
}
