using TechTalk.SpecFlow;
using NUnit.Framework;
using SeleniumExamples.Utils;
using SeleniumExamples.Bases;
using SeleniumExamples.PageModels;


namespace SeleniumExamples.Steps
{
    [Binding]
    public class SearchForRedditOnGoogleSteps : BaseDriver
    {
        private GoogleHomePage homePage;
        private GoogleResultPage resultPage;

        public SearchForRedditOnGoogleSteps(BrowserDriver webdriver) : base(webdriver)
        {

        }

        [Given(@"that (.*) \+ (.*) equals (.*)")]
        public void GivenThatEquals(int int1, int int2, int expected)
        {
            int actual = int1 + int2;
            Assert.AreEqual(expected, actual);
        }

        [Given(@"I navigate to google\.com")]
        public void GivenINavigateToGoogle_Com()
        {
            driver.Url = RunSettings.baseGoogleUrl;
            driver.Navigate();
            homePage = new GoogleHomePage(driver, wait);
        }
        
        [Given(@"I type (.*) into the search bar")]
        public void GivenITypeIntoTheSearchBar(string search)
        {
            homePage.typeSearchBar(search);
        }
        
        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            homePage.clickSearch();
        }
        
        [When(@"I click on the first result with (.*) in the result")]
        public void WhenIClickOnTheFirstResultWithRedditInTheResult(string resultText)
        {
            resultPage = new GoogleResultPage(driver, wait);
            resultPage.clickResultWithWebsite(resultText);
        }

        [Then(@"I see the result screen display")]
        public void ThenISeeTheResultScreenDisplay()
        {
            resultPage = new GoogleResultPage(driver, wait);
            Assert.IsTrue(resultPage.isSearchSuccessful());
        }
        
        [Then(@"I am taken to reddit\.com")]
        public void ThenIAmTakenToReddit_Com()
        {
            Assert.AreEqual("https://www.reddit.com/", driver.Url);
        }
    }
}
