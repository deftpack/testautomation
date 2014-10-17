using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public interface IElementProvider
    {
        ISelectorBuilder Any { get; }
        ISelectorBuilder Tag(string tagName);
        TElement Query<TElement>(Func<ISelectorBuilder> builderFunc) where TElement : Element;
        TElement Query<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc) where TElement : Element;
    }
}