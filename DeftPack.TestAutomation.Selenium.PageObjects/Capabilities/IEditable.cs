namespace DeftPack.TestAutomation.Selenium.PageObjects.Capabilities
{
    public interface IEditable : ITextual, IElement
    {
        void Enter(string text);
    }
}