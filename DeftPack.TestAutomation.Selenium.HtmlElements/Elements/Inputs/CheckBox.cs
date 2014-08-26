using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Inputs
{
    [HtmlInput(InputTypes.Checkbox)]
    public class CheckBox : Element
    {
        public bool IsSelected
        {
            get { return ProxyObject.Selected; }
        }

        public void SetState(bool isChecked)
        {
            if (IsSelected != isChecked)
                ProxyObject.Click();
        }

        public void Toggle()
        {
            ProxyObject.Click();
        }
    }
}
