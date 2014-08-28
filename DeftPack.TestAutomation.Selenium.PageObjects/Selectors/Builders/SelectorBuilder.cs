using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using System.Collections.Generic;
using System.Text;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors.Builders
{
    public class SelectorBuilder : ISelectorBuilder
    {
        private readonly StringBuilder _builder;

        private readonly Dictionary<Comparison, string> _modeDictionary = new Dictionary<Comparison, string>
        {
            { Comparison.Equals, "=" }, 
            { Comparison.NotEquals, "!=" },
            { Comparison.Contains, "*="},
            { Comparison.StartsWith, "^="},
            { Comparison.EndsWith, "$="}
        };

        internal SelectorBuilder(string tagName)
        {
            _builder = new StringBuilder(tagName);
        }

        internal SelectorBuilder(InputTypes type)
        {
            _builder = new StringBuilder("input");
            WithHtmlAttribute("type", type.ToString().ToLower());
        }

        public static SelectorBuilder Any
        {
            get { return new SelectorBuilder(string.Empty); }
        }

        public ISelectorBuilder WithId(string id)
        {
            _builder.AppendFormat("#{0}", id.Escape());
            return this;
        }

        public ISelectorBuilder WithHtmlAttribute(string name, string value = null, Comparison mode = Comparison.Equals)
        {
            _builder.Append(value == null ?
                string.Format("[{0}]", name.Escape()) :
                string.Format("[{0}{1}\"{2}\"]", name.Escape(), _modeDictionary[mode], value.Escape()));
            return this;
        }

        public ISelectorBuilder WithCssClass(string className)
        {
            _builder.AppendFormat(".{0}", className.Escape());
            return this;
        }

        public ISelectorBuilder WithText(string textPart)
        {
            _builder.AppendFormat(":contains(\"{0}\")", textPart.Escape());
            return this;
        }

        public ISelectorBuilder ChildOf(ISelectorBuilder selectorBuilder)
        {
            _builder.Insert(0, string.Format("{0} ", selectorBuilder.Selector));
            return this;
        }

        public ISelectorBuilder HasChild(ISelectorBuilder selectorBuilder)
        {
            _builder.AppendFormat(":has({0})", selectorBuilder.Selector);
            return this;
        }

        public ISelectorBuilder Not(ISelectorBuilder selectorBuilder)
        {
            _builder.AppendFormat(":not({0})", selectorBuilder.Selector);
            return this;
        }

        public ISelectorBuilder Visible()
        {
            _builder.Append(":visible");
            return this;
        }

        public ISelectorBuilder Hidden()
        {
            _builder.Append(":hidden");
            return this;
        }

        public ISelectorBuilder Empty()
        {
            _builder.Append(":empty");
            return this;
        }

        public ISelectorBuilder Enabled()
        {
            _builder.Append(":enabled");
            return this;
        }

        public ISelectorBuilder Disabled()
        {
            _builder.Append(":disabled");
            return this;
        }

        public ISelectorBuilder First()
        {
            _builder.Append(":first");
            return this;
        }

        public ISelectorBuilder Last()
        {
            _builder.Append(":last");
            return this;
        }

        public ISelectorBuilder InSequence(int th)
        {
            _builder.AppendFormat(":eq({0})", th);
            return this;
        }

        public ISelectorBuilder Selected()
        {
            _builder.Append(":selected");
            return this;
        }

        public ISelectorBuilder GotFocus()
        {
            _builder.Append(":focus");
            return this;
        }

        public string Selector
        {
            get { return _builder.ToString(); }
        }
    }
}
