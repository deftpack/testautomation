using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.UnitTests.Factories;
using Moq;
using NUnit.Framework;

namespace DeftPack.TestAutomation.Selenium.PageObjects.UnitTests
{
    [TestFixture(typeof(Button))]
    [TestFixture(typeof(CheckBox))]
    [TestFixture(typeof(Dropdown))]
    [TestFixture(typeof(FileUploader))]
    [TestFixture(typeof(NumberInput))]
    [TestFixture(typeof(RadioButton))]
    [TestFixture(typeof(TextBox))]
    [TestFixture(typeof(Image))]
    [TestFixture(typeof(Label))]
    public class ElementFactoryElementTests<TElement> where TElement : Element
    {
        private readonly WebElementMockFactory _mockFactory = new WebElementMockFactory();
        private IElementTypeFinder _typeFinder;

        [SetUp]
        public void SetUp()
        {
            _typeFinder = new Mock<IElementTypeFinder>().Object;
        }

        [Test]
        public void Create_ElementSuccessfullyCreated()
        {
            var element = new ElementFactory(_typeFinder).Create<TElement>(_mockFactory.Element(""));
            Assert.That(element, Is.Not.Null);
        }
    }
}
