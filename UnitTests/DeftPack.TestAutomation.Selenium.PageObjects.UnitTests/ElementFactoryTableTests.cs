using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.UnitTests.Factories;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.UnitTests
{
    [TestFixture]
    public class ElementFactoryTableTests
    {
        private readonly TypeFinderMockFactory _typeFinderMockFactory = new TypeFinderMockFactory();
        private readonly WebElementMockFactory _mockFactory = new WebElementMockFactory();
        private IElementTypeFinder _typeFinder;
        private IWebElement _table;

        [SetUp]
        public void SetUp()
        {
            var head =
               _mockFactory.Wrapper("thead",
                   _mockFactory.Wrapper("tr",
                       _mockFactory.TextElement("th", "Head1"),
                       _mockFactory.TextElement("th", "Head2"),
                       _mockFactory.TextElement("th", "Head3")));
            var body =
                _mockFactory.Wrapper("tbody",
                    _mockFactory.Wrapper("tr",
                        _mockFactory.TextElement("td", "First Row"),
                        _mockFactory.Wrapper("td", _mockFactory.Element("img")),
                        _mockFactory.Wrapper("td", _mockFactory.Element("a"))),
                    _mockFactory.Wrapper("tr",
                        _mockFactory.TextElement("td", "Second Row"),
                        _mockFactory.Wrapper("td", _mockFactory.Element("img")),
                        _mockFactory.Wrapper("td", _mockFactory.Element("a"))));
            var foot =
                _mockFactory.Wrapper("tfoot",
                    _mockFactory.Wrapper("tr", _mockFactory.TextElement("td", "Foot1"),
                        _mockFactory.TextElement("td", "Foot2"),
                        _mockFactory.TextElement("td", "Foot3")));
            _table = _mockFactory.Table(body, head, foot);

            _typeFinder = _typeFinderMockFactory.Mock(new Dictionary<string, Type>
            {
                {"table", typeof (Table)},
                {"thead", typeof (TableHeader)},
                {"tbody", typeof (TableBody)},
                {"tfoot", typeof (TableFooter)},
                {"tr", typeof (TableRow)},
                {"td", typeof (TableCell)},
                {"th", typeof (TableCell)},
                {"img", typeof (Image)},
                {"a", typeof (Link)}
            });
        }

        [Test]
        public void Create_TableElementsCreated()
        {
            var element = new ElementFactory(_typeFinder).Create<Table>(_table);

            // -- Table parts are not null
            Assert.That(element.Header, Is.Not.Null);
            Assert.That(element.Body, Is.Not.Null);
            Assert.That(element.Footer, Is.Not.Null);
            // -- Number of rows are correct
            Assert.That(element.Header.Rows.Count(), Is.EqualTo(1));
            Assert.That(element.Body.Rows.Count(), Is.EqualTo(2));
            Assert.That(element.Footer.Rows.Count(), Is.EqualTo(1));
            // -- Number of cells are correct
            Assert.That(element.Header.Rows.First().Cells.Count(), Is.EqualTo(3));
            Assert.That(element.Body.Rows.First().Cells.Count(), Is.EqualTo(3));
            Assert.That(element.Body.Rows.Last().Cells.Count(), Is.EqualTo(3));
            Assert.That(element.Footer.Rows.First().Cells.Count(), Is.EqualTo(3));
            // -- Number of child elements correct
            Assert.That(element.Header.Rows.First().Cells.ElementAt(0).ChildElements.Count(), Is.EqualTo(0));
            Assert.That(element.Header.Rows.First().Cells.ElementAt(1).ChildElements.Count(), Is.EqualTo(0));
            Assert.That(element.Header.Rows.First().Cells.ElementAt(2).ChildElements.Count(), Is.EqualTo(0));
            Assert.That(element.Body.Rows.First().Cells.ElementAt(0).ChildElements.Count(), Is.EqualTo(0));
            Assert.That(element.Body.Rows.First().Cells.ElementAt(1).ChildElements.Count(), Is.EqualTo(1));
            Assert.That(element.Body.Rows.First().Cells.ElementAt(2).ChildElements.Count(), Is.EqualTo(1));
            Assert.That(element.Body.Rows.Last().Cells.ElementAt(0).ChildElements.Count(), Is.EqualTo(0));
            Assert.That(element.Body.Rows.Last().Cells.ElementAt(1).ChildElements.Count(), Is.EqualTo(1));
            Assert.That(element.Body.Rows.Last().Cells.ElementAt(2).ChildElements.Count(), Is.EqualTo(1));
            Assert.That(element.Footer.Rows.First().Cells.ElementAt(0).ChildElements.Count(), Is.EqualTo(0));
            Assert.That(element.Footer.Rows.First().Cells.ElementAt(1).ChildElements.Count(), Is.EqualTo(0));
            Assert.That(element.Footer.Rows.First().Cells.ElementAt(2).ChildElements.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Create_TableElementsCreatedWithCorrectText()
        {
            var element = new ElementFactory(_typeFinder).Create<Table>(_table);

            // -- Text in the child elements are correct
            Assert.That(element.Header.Rows.First().Cells.ElementAt(0).GetText(), Is.EqualTo("Head1"));
            Assert.That(element.Header.Rows.First().Cells.ElementAt(1).GetText(), Is.EqualTo("Head2"));
            Assert.That(element.Header.Rows.First().Cells.ElementAt(2).GetText(), Is.EqualTo("Head3"));
            Assert.That(element.Body.Rows.First().Cells.ElementAt(0).GetText(), Is.EqualTo("First Row"));
            Assert.That(element.Body.Rows.First().Cells.ElementAt(1).GetText(), Is.EqualTo(""));
            Assert.That(element.Body.Rows.First().Cells.ElementAt(2).GetText(), Is.EqualTo(""));
            Assert.That(element.Body.Rows.Last().Cells.ElementAt(0).GetText(), Is.EqualTo("Second Row"));
            Assert.That(element.Body.Rows.Last().Cells.ElementAt(1).GetText(), Is.EqualTo(""));
            Assert.That(element.Body.Rows.Last().Cells.ElementAt(2).GetText(), Is.EqualTo(""));
            Assert.That(element.Footer.Rows.First().Cells.ElementAt(0).GetText(), Is.EqualTo("Foot1"));
            Assert.That(element.Footer.Rows.First().Cells.ElementAt(1).GetText(), Is.EqualTo("Foot2"));
            Assert.That(element.Footer.Rows.First().Cells.ElementAt(2).GetText(), Is.EqualTo("Foot3"));
        }
    }
}
