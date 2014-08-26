namespace DeftPack.TestAutomation.Selenium.PageElements.Capabilities
{
    public interface ISelectable : IElement
    {
        object Value { get; set; }
        void Select(int index);
    }
}