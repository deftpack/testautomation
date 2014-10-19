using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.UnitTests.Factories;
using NUnit.Framework;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.UnitTests
{
    [TestFixture]
    public class ElementTypeFinderTests
    {
        private readonly WebElementMockFactory _mockFactory = new WebElementMockFactory();
        private readonly IElementTypeFinder _typeFinder = new ElementTypeFinder();

        [TestCase("a", "", Result = typeof(Link))]
        [TestCase("button", "", Result = typeof(Button))]
        [TestCase("input", "submit", Result = typeof(Button))]
        [TestCase("input", "button", Result = typeof(Button))]
        [TestCase("input", "reset", Result = typeof(Button))]
        [TestCase("input", "image", Result = typeof(Button))]
        [TestCase("form", "", Result = typeof(Form))]
        [TestCase("frame", "", Result = typeof(Frame))]
        [TestCase("iframe", "", Result = typeof(Frame))]
        [TestCase("input", "checkbox", Result = typeof(CheckBox))]
        [TestCase("select", "", Result = typeof(Dropdown))]
        [TestCase("input", "file", Result = typeof(FileUploader))]
        [TestCase("input", "number", Result = typeof(NumberInput))]
        [TestCase("input", "range", Result = typeof(NumberInput))]
        [TestCase("input", "date", Result = typeof(NumberInput))]
        [TestCase("input", "week", Result = typeof(NumberInput))]
        [TestCase("input", "month", Result = typeof(NumberInput))]
        [TestCase("input", "time", Result = typeof(NumberInput))]
        [TestCase("input", "datetime", Result = typeof(NumberInput))]
        [TestCase("input", "radio", Result = typeof(RadioButton))]
        [TestCase("textarea", "", Result = typeof(TextBox))]
        [TestCase("input", "url", Result = typeof(TextBox))]
        [TestCase("input", "text", Result = typeof(TextBox))]
        [TestCase("input", "search", Result = typeof(TextBox))]
        [TestCase("input", "email", Result = typeof(TextBox))]
        [TestCase("input", "password", Result = typeof(TextBox))]
        [TestCase("img", "", Result = typeof(Image))]
        [TestCase("input", "hidden", Result = typeof(Label))]
        [TestCase("p", "", Result = typeof(Label))]
        [TestCase("h1", "", Result = typeof(Label))]
        [TestCase("h2", "", Result = typeof(Label))]
        [TestCase("h3", "", Result = typeof(Label))]
        [TestCase("h4", "", Result = typeof(Label))]
        [TestCase("h5", "", Result = typeof(Label))]
        [TestCase("h6", "", Result = typeof(Label))]
        [TestCase("span", "", Result = typeof(Label))]
        [TestCase("label", "", Result = typeof(Label))]
        [TestCase("table", "", Result = typeof(Table))]
        [TestCase("tbody", "", Result = typeof(TableBody))]
        [TestCase("thead", "", Result = typeof(TableHeader))]
        [TestCase("tfoot", "", Result = typeof(TableFooter))]
        [TestCase("tr", "", Result = typeof(TableRow))]
        [TestCase("td", "", Result = typeof(TableCell))]
        [TestCase("th", "", Result = typeof(TableCell))]
        public Type Find_ReturnsCorrectType(string tagName, string typeAttributeValue)
        {
            var element = string.IsNullOrWhiteSpace(typeAttributeValue)
                ? _mockFactory.Element(tagName)
                : _mockFactory.Input(typeAttributeValue);
            return _typeFinder.Find(element);
        }
    }
}
