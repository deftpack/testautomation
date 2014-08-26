using DeftPack.TestAutomation.Selenium.HtmlElements.Capabilities;
using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Inputs
{
    [HtmlInput(InputTypes.File)]
    public class FileUploader : Element, IUploader
    {
        public string Path { get; private set; }
        public void Upload(string path)
        {
            Path = path;
            ProxyObject.SendKeys(path);
        }
    }
}
