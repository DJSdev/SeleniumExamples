using System;
using System.IO;
using OpenQA.Selenium;
using NUnit.Framework;


namespace SeleniumExamples.Utils
{
    public class Logger
    {
        IWebDriver driver;
        private const string startLine = " ->";
        private const string messageFormat = "{0} {1}";

        public Logger(IWebDriver webdriver)
        {
            driver = webdriver;
        }

        private string CreateLogMessage(string message)
        {
            return string.Format(messageFormat, startLine, message);
        }

        public void LogMessage(string message)
        {
            string newMessage = CreateLogMessage(message);
            TestContext.WriteLine(newMessage);
        }

        public void LogBrowserUrl()
        {
            if (driver.Url != null)
            {
                LogMessage(string.Format("Browser URL: {0}", driver.Url));
            }
            else
            {
                LogMessage("Browser URL unavailable");
            }
        }

        public void LogScreenShot(IWebDriver driver, string fileName)
        {
            string cleanedFileName = CleanFileName(fileName);
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenShotPath = Directory.GetCurrentDirectory() + string.Format("\\{0}.png", cleanedFileName);
            screenShot.SaveAsFile(screenShotPath);
            TestContext.AddTestAttachment(screenShotPath);
        }

        private string CleanFileName(string filename)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            return string.Join("_", filename.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
        }
    }
}