using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    public interface ISelectorBuilder
    {
        ISelectorBuilder WithId(string id);
        ISelectorBuilder WithId(Func<string, bool> idComparer);
        ISelectorBuilder WithHtmlAttribute(string name, string value = null);
        ISelectorBuilder WithHtmlAttribute(string name, Func<string, bool> valueComparer);
        ISelectorBuilder WithHtml5Attribute(string name, string value = null);
        ISelectorBuilder WithHtml5Attribute(string name, Func<string, bool> valueComparer);
        ISelectorBuilder WithCssClass(Func<string, bool> nameComparer);
        ISelectorBuilder ChildOf(ISelectorBuilder selectorBuilder);
        ISelectorBuilder HasChild(ISelectorBuilder selectorBuilder);
        ISelectorBuilder HasText(string textPart);
        ISelectorBuilder HasText(Func<string, bool> textComparer);
        ISelectorBuilder Not(ISelectorBuilder selectorBuilder);
        ISelectorBuilder Visible();
        ISelectorBuilder Hidden();
        ISelectorBuilder Empty();
        ISelectorBuilder Enabled();
        ISelectorBuilder Disabled();
        ISelectorBuilder First();
        ISelectorBuilder Last();
        ISelectorBuilder InSequence(int th);
        ISelectorBuilder Next();
        ISelectorBuilder Previous();
        ISelectorBuilder Selected();
        ISelectorBuilder GotFocus();
    }
}