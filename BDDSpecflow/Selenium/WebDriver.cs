using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace BDDSpecflow.Selenium
{
    public sealed class WebDriver
    {
        private static IWebDriver _webdriver;

        private static WebDriver instance;

        private WebDriver() { }

        public static WebDriver GetInstance(DriverType drivertype)
        {
            if (instance == null)
            {
                instance = new WebDriver();
                switch (drivertype)
                {
                    case DriverType.Firefox:
                        instance.Driver = new FirefoxDriver();
                        break;
                    case DriverType.Chrome:
                        instance.Driver = new ChromeDriver();
                        break;
                    default:
                        instance.Driver = new FirefoxDriver();
                        break;
                }
            }
            return instance;
        }

        public IWebDriver Driver
        {
            private set { _webdriver = value; }
            get { return _webdriver; }
        }

        public void NullDriver()
        {
            instance = null;
        }
    }
    public enum DriverType
    {
        Firefox,
        Chrome
    }
}
