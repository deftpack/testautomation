namespace DeftPack.TestAutomation.Selenium.PageElements.Capabilities
{
    public interface IEditable : ITextual, IElement
    {
        new string Text { get; set; }
        void Enter(string text);
        void Type(string text);
    }
}