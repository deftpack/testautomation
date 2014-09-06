using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.IO;

namespace DeftPack.TestAutomation.Functional
{
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

        public void HandleFinishedTestReport(ITestReporter t, TestReporterFinishedEventArgs args)
        {
            TakeScreenShot(args.TestName, args.TestStatus ? "passed" : "failed");
        }
    }
}
