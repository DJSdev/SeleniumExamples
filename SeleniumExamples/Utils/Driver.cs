using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExamples.Utils
{
    public class BrowserDriver
    {
        private string _browser = RunSettings.browser;

        private IWebDriver _driver;
        public IWebDriver Driver
        {
            get
            {
                if (_driver != null)
                    return _driver;

                switch (_browser)
                {
                    case "Chrome":
                        ChromeOptions optionsChrome = new ChromeOptions();
                        _driver = new ChromeDriver(optionsChrome);
                        break;
                    case "Firefox":
                        FirefoxOptions optionsFF = new FirefoxOptions();
                        _driver = new FirefoxDriver(optionsFF);
                        break;
                    default:
                        throw new Exception("No WebDriver selected. Please set a browser in runsettings");
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                _driver.Manage().Window.Maximize();
                return _driver;
            }
        }

        private WebDriverWait _wait;
        public WebDriverWait Wait
        {
            get
            {
                if (_wait == null)
                {
                    _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                }
                return _wait;
            }
        }
    }
}