using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using System;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    internal class SelectorBuilderFactory
    {
        public ISelectorBuilder Create<TElement>()
        {
            var tagNames = typeof(TElement).GetCustomAttributes<HtmlTagAttribute>().Select(x => x.TagName);
            var inputTypes = typeof (TElement).GetCustomAttributes<HtmlInputAttribute>().Select(x => x.InputType);
            var selectorBuilders = tagNames.Select(x => (ISelectorBuilder)(new SelectorBuilder(x))).ToList();
            selectorBuilders.AddRange(
                inputTypes.Select(
                    inputType => new SelectorBuilder("input")
                        .WithHtmlAttribute("type", inputType.ToString().ToLower())));


            return selectorBuilders.First();
        }


        public ISelectorBuilder Create<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
        {
            var baseBuilder = Create<TElement>();
            return builderFunc(baseBuilder);
        }
    }
}
