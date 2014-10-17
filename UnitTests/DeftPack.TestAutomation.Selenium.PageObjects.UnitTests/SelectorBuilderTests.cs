
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using NUnit.Framework;
using System.Text;

namespace DeftPack.TestAutomation.Selenium.PageObjects.UnitTests
{
    [TestFixture]
    public class SelectorBuilderTests
    {
        [Test]
        public void Build_jQueryElementSelectorsCreatedSuccessfully()
        {
            var selectorBuilder = new SelectorBuilder("div")
                .ChildOf(new SelectorBuilder("div").WithId("parent"))
                .Disabled()
                .Empty()
                .Enabled()
                .First()
                .GotFocus()
                .HasChild(new SelectorBuilder("div").WithId("child"))
                .Hidden()
                .InSequence(3)
                .Last()
                .Not(new SelectorBuilder(string.Empty).WithId("incorrect"))
                .Selected()
                .Visible()
                .WithCssClass("class")
                .WithId("correct")
                .WithText("text");

            var jQuerySelectorBuilder = new StringBuilder()
                .Append(@"div#parent")
                .Append(@" div")
                .Append(@":disabled")
                .Append(@":empty")
                .Append(@":enabled")
                .Append(@":first")
                .Append(@":focus")
                .Append(@":has(div#child)")
                .Append(@":hidden")
                .Append(@":eq(3)")
                .Append(@":last")
                .Append(@":not(#incorrect)")
                .Append(@":selected")
                .Append(@":visible")
                .Append(@".class")
                .Append(@"#correct")
                .Append(@":contains(""text"")");

            Assert.That(selectorBuilder.Build(), Is.EqualTo(jQuerySelectorBuilder.ToString()));
        }

        [Test]
        public void Build_jQueryAttributeSelectorsCreatedSuccessfully()
        {
            var selectorBuilder = new SelectorBuilder("div")
                .WithHtmlAttribute("test")
                .WithHtmlAttribute("test", "1", Comparison.Equals)
                .WithHtmlAttribute("test", "2", Comparison.Contains)
                .WithHtmlAttribute("test", "3", Comparison.EndsWith)
                .WithHtmlAttribute("test", "4", Comparison.NotEquals)
                .WithHtmlAttribute("test", "5", Comparison.StartsWith);

            var jQuerySelectorBuilder = new StringBuilder()
                .Append(@"div")
                .Append(@"[test]")
                .Append(@"[test=""1""]")
                .Append(@"[test*=""2""]")
                .Append(@"[test$=""3""]")
                .Append(@"[test!=""4""]")
                .Append(@"[test^=""5""]");

            Assert.That(selectorBuilder.Build(), Is.EqualTo(jQuerySelectorBuilder.ToString()));
        }
    }
}
