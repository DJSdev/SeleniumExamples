using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExamples.Utils;

namespace SeleniumExamples.Bases
{
    public class BaseDriver
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public Logger logger;
        public BaseDriver(BrowserDriver webdriver)
        {
            driver = webdriver.Driver;
            wait = webdriver.Wait;
            logger = new Logger(driver);
        }
    }
}
