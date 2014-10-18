using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.IO;

namespace DeftPack.TestAutomation.Functional
{
    /// <summary>
    /// Saves screenshot to the given location made on the actual screen by a Selenium Web Driver
    /// </summary>
    public class TestScreenshotSaver : ITestScreenshotSaver
    {
        public static string ScreenshotFolderName = "Screenshots";
        private readonly IWebDriver _webDriver;
        private readonly string _screenShotLocation;

        public TestScreenshotSaver(IWebDriver webDriver, string rootLocation)
        {
            _webDriver = webDriver;
            _screenShotLocation = Path.Combine(rootLocation, ScreenshotFolderName);

            if (!Directory.Exists(_screenShotLocation))
            {
                Directory.CreateDirectory(_screenShotLocation);
            }
        }

        /// <summary>
        /// Immediately creates and saves the screenshot
        /// </summary>
        /// <param name="testName">The name of test. This going to be the first part of the file name.</param>
        /// <param name="screenshotDescription">Short description of the screenshot which going to be the second part of the file name (i.e.: failed)</param>
        private void TakeScreenShot(string testName, string screenshotDescription)
        {
            var screenshotDriver = _webDriver as ITakesScreenshot;
            if (screenshotDriver == null) return;

            var screenshot = screenshotDriver.GetScreenshot();
            var saveLocation = Path.Combine(
                _screenShotLocation,
                string.Format("{0}_{1}.png", testName, screenshotDescription));
            screenshot.SaveAsFile(saveLocation, ImageFormat.Png);
        }

        /// <summary>
        ///  Event handler for test reporter. When a test reporter finished, it creates and saves a screenshot.
        /// </summary>
        /// <param name="t">Test reporter</param>
        /// <param name="args">Finished test report arguments</param>
        public void HandleFinishedTestReport(ITestReporter t, TestReporterFinishedEventArgs args)
        {
            TakeScreenShot(args.TestName, args.TestStatus ? "passed" : "failed");
        }
    }
}
