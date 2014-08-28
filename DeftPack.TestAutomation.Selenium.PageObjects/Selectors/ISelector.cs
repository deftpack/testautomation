namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    public interface ISelector
    {
        string XPath { get; }
        IElement Element { get; }
    }
}