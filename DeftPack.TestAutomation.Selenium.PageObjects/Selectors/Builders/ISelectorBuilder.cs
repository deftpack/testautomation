namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors.Builders
{
    public interface ISelectorBuilder
    {
        ISelectorBuilder WithId(string id);
        ISelectorBuilder WithHtmlAttribute(string name, string value = null, Comparison mode = Comparison.Equals);
        ISelectorBuilder WithCssClass(string className);
        ISelectorBuilder WithText(string textPart);
        ISelectorBuilder ChildOf(ISelectorBuilder selectorBuilder);
        ISelectorBuilder HasChild(ISelectorBuilder selectorBuilder);
        ISelectorBuilder Not(ISelectorBuilder selectorBuilder);
        ISelectorBuilder Visible();
        ISelectorBuilder Hidden();
        ISelectorBuilder Empty();
        ISelectorBuilder Enabled();
        ISelectorBuilder Disabled();
        ISelectorBuilder First();
        ISelectorBuilder Last();
        ISelectorBuilder InSequence(int th);
        ISelectorBuilder Selected();
        ISelectorBuilder GotFocus();
        string Selector { get; }
    }
}