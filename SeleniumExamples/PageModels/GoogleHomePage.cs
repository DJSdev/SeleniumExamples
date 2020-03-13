using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExamples.PageModels
{
    class GoogleHomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public GoogleHomePage(IWebDriver wdriver, WebDriverWait wwait)
        {
            driver = wdriver;
            wait = wwait;
        }

        public void typeSearchBar(string search)
        {
            driver.FindElement(By.Name("q")).SendKeys(search);
        }

        public void clickSearch()
        {
            By button = By.Name("btnK");
            wait.Until(ExpectedConditions.ElementToBeClickable(button));
            driver.FindElement(button).Click();
        }
    }
}
