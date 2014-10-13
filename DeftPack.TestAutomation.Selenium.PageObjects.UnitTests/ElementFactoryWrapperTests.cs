using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Containers;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Media;
using DeftPack.TestAutomation.Selenium.PageObjects.UnitTests.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.UnitTests
{
    [TestFixture]
    public class ElementFactoryWrapperTests
    {
        private readonly TypeFinderMockFactory _typeFinderMockFactory = new TypeFinderMockFactory();
        private readonly WebElementMockFactory _mockFactory = new WebElementMockFactory();

        [Test]
        public void Create_LinkCreatedSuccessfully()
        {
            var link =
                _mockFactory.Wrapper("a",
                    _mockFactory.Element("img"),
                    _mockFactory.TextElement("span", "Click on "),
                    _mockFactory.TextElement("span", "this"),
                    _mockFactory.TextElement("span", " link"));

            var typeFinder = _typeFinderMockFactory.Mock(new Dictionary<string, Type>
            {
                {"span", typeof (Label)},
                {"img", typeof (Image)},
                {"a", typeof (Link)}
            });

            var element = new ElementFactory(typeFinder).Create<Link>(link);

            Assert.That(element.ChildElements.Count(), Is.EqualTo(4));
            Assert.That(element.GetText(), Is.EqualTo("Click on this link"));
            Assert.That(element.ChildElements.ElementAt(0), Is.InstanceOf<Image>());
            Assert.That(element.ChildElements.ElementAt(1), Is.InstanceOf<Label>());
            Assert.That(element.ChildElements.ElementAt(2), Is.InstanceOf<Label>());
            Assert.That(element.ChildElements.ElementAt(3), Is.InstanceOf<Label>());
        }

        [Test]
        public void Create_FormCreatedSuccessfully()
        {
            var form =
                _mockFactory.Wrapper("form",
                    _mockFactory.Input("range"),
                    _mockFactory.Input("text"),
                    _mockFactory.Input("datetime"),
                    _mockFactory.Input("submit"));

            var typeFinder = _typeFinderMockFactory.Mock(
                new Dictionary<string, Type>
                {
                    {"form", typeof (Form)}
                },
                new Dictionary<string, Type>
                {
                    {"range", typeof (NumberInput)},
                    {"text", typeof (TextBox)},
                    {"datetime", typeof (NumberInput)},
                    {"submit", typeof (Button)}
                });

            var element = new ElementFactory(typeFinder).Create<Form>(form);

            Assert.That(element.ChildElements.Count(), Is.EqualTo(4));
            Assert.That(element.ChildElements.ElementAt(0), Is.InstanceOf<NumberInput>());
            Assert.That(element.ChildElements.ElementAt(1), Is.InstanceOf<TextBox>());
            Assert.That(element.ChildElements.ElementAt(2), Is.InstanceOf<NumberInput>());
            Assert.That(element.ChildElements.ElementAt(3), Is.InstanceOf<Button>());
        }

        [Test]
        public void Create_FrameCreatedSuccessfully()
        {
            var frame =
                _mockFactory.Wrapper("iframe",
                    _mockFactory.Wrapper("a",
                        _mockFactory.Element("img")),
                    _mockFactory.Wrapper("form",
                        _mockFactory.Element("button")));

            var typeFinder = _typeFinderMockFactory.Mock(new Dictionary<string, Type>
            {
                {"iframe", typeof (Frame)},
                {"a", typeof (Link)},
                {"img", typeof (Image)},
                {"form", typeof (Form)},
                {"button", typeof (Button)}
            });

            var element = new ElementFactory(typeFinder).Create<Frame>(frame);

            Assert.That(element.ChildElements.Count(), Is.EqualTo(2));
            Assert.That(element.ChildElements.ElementAt(0), Is.InstanceOf<Link>());
            Assert.That(element.ChildElements.ElementAt(1), Is.InstanceOf<Form>());
            Assert.That(element.ChildElements.OfType<Link>().First().ChildElements.Count(), Is.EqualTo(1));
            Assert.That(element.ChildElements.OfType<Form>().First().ChildElements.Count(), Is.EqualTo(1));
            Assert.That(element.ChildElements.OfType<Link>().First().ChildElements.First(), Is.InstanceOf<Image>());
            Assert.That(element.ChildElements.OfType<Form>().First().ChildElements.First(), Is.InstanceOf<Button>());
        }
    }
}
