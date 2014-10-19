namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public interface IEditable : ITextual, IElement
    {
        void Enter(string text);
    }
}