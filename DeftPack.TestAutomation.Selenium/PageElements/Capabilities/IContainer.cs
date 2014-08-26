namespace DeftPack.TestAutomation.Selenium.PageElements.Capabilities
{
    public interface IContainer : IElement
    {
        bool Exists(IElementSelector selector);
        int Count(IElementSelector selector);
        void Scroll(int pixelsDown = 0, int pixelsRight = 0);
    }
}