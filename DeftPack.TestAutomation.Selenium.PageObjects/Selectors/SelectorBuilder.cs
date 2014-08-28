using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    public class SelectorBuilder : ISelectorBuilder
    {
        public SelectorBuilder(string tagName)
        {
            
        }

        public ISelectorBuilder WithId(string id)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder WithId(Func<string, bool> idComparer)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder WithHtmlAttribute(string name, string value = null)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder WithHtmlAttribute(string name, Func<string, bool> valueComparer = null)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder WithHtml5Attribute(string name, string value = null)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder WithHtml5Attribute(string name, Func<string, bool> valueComparer = null)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder WithCssClass(Func<string, bool> nameComparer)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder ChildOf(ISelectorBuilder selectorBuilder)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder HasChild(ISelectorBuilder selectorBuilder)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder HasText(string textPart)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder HasText(Func<string, bool> textComparer)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Not(ISelectorBuilder selectorBuilder)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Visible()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Hidden()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Empty()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Enabled()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Disabled()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder First()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Last()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder InSequence(int th)
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Next()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Previous()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder Selected()
        {
            throw new NotImplementedException();
        }

        public ISelectorBuilder GotFocus()
        {
            throw new NotImplementedException();
        }
    }
}
