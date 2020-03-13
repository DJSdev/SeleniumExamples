using System.Collections.Generic;
using TechTalk.SpecFlow;
using SeleniumExamples.Utils;
using SeleniumExamples.Bases;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class CommonSteps : BaseDriver
    {
        public CommonSteps(BrowserDriver webdriver) : base(webdriver)
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Close();
        }

        [AfterStep]
        public void AfterStepCleanUp()
        {
            if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                logger.LogBrowserUrl();
                logger.LogScreenShot(driver, "test.png");
                var runsettings = RunSettings.GetRunSettings();
                foreach (KeyValuePair<string, string> setting in runsettings)
                {
                    logger.LogMessage(string.Format("{0}: {1}", setting.Key, setting.Value));
                }
            }
        }
    }
}
