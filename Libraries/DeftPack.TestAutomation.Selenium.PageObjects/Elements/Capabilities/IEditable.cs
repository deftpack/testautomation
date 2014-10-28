namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    internal interface IEditable : ITextual, IElement
    {
        void Enter(string text);
    }
}