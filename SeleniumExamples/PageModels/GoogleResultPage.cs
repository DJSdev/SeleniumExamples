using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExamples.PageModels
{
    class GoogleResultPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public GoogleResultPage(IWebDriver wdriver, WebDriverWait wwait)
        {
            driver = wdriver;
            wait = wwait;
        }

        public void clickResultWithWebsite(string websiteUrl)
        {
            By link = By.XPath("//a[@href=\"" + websiteUrl + "\"]");
            wait.Until(ExpectedConditions.ElementToBeClickable(link));
            driver.FindElement(link).Click();
        }

        public bool isSearchSuccessful()
        {
            By resultStats = By.Id("result-stats");
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(resultStats));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
