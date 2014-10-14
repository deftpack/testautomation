
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Media;
using DeftPack.TestAutomation.Selenium.PageObjects.UnitTests.Factories;
using DeftPack.TestAutomation.Selenium.PageObjects.Views;
using NUnit.Framework;

namespace DeftPack.TestAutomation.Selenium.PageObjects.UnitTests
{
    public class ViewTests
    {
        private readonly WebElementMockFactory _mockFactory = new WebElementMockFactory();

        [CheckViewUrl("test")]
        class First : View
        {
            public Label Label { get { return Query<Label>(x => x.WithId("label")); } }
            public Image Image { get { return Query<Image>(x => x.WithId("image")); } }
        }

        [Test]
        public void IsLoaded_Successful()
        {
            //var webDriver = new Mock<IWebDriver>();
            //webDriver.SetupGet(x => x.Url).Returns("test");
            //webDriver.Setup(x => ((IJavaScriptExecutor)x).ExecuteScript("document.readyState"))
            //    .Returns("complete");
            //webDriver.Setup(x => ((IJavaScriptExecutor)x).ExecuteScript("window.SeleniumTesting.IsAjaxFinished()"))
            //    .Returns("true");
            //webDriver.Setup(x => ((IJavaScriptExecutor)x).ExecuteScript(It.Is<string>(y => y.Contains("QueryElement"))))
            //    .Returns(_mockFactory.Element(""));

            //var view = (First)(new ViewFactory().Create(typeof(First), webDriver.Object));

            //Assert.That(view.IsLoaded, Is.True);
        }

        [Test]
        public void IsLoaded_SuccessfulAndDynamicElementsIgnored()
        {

        }

        [Test]
        public void IsLoaded_Fails()
        {

        }

        [Test]
        public void IsRedirectedTo_Successful()
        {

        }

        [Test]
        public void IsRedirectedTo_Fails()
        {

        }
    }
}
