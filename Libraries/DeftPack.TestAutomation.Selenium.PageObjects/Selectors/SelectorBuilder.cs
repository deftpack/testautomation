using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using System.Collections.Generic;
using System.Text;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
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

        public SelectorBuilder(string tagName)
        {
            _builder = new StringBuilder(tagName);
        }

        public SelectorBuilder(InputTypes type)
        {
            _builder = new StringBuilder("input");
            WithHtmlAttribute("type", type.ToString().ToLower());
        }

        /// <summary>
        /// Returns a selector builder without tag specified
        /// </summary>
        public static SelectorBuilder Any
        {
            get { return new SelectorBuilder(string.Empty); }
        }

        /// <summary>
        /// Add expression to select element with the given id attribute
        /// http://api.jquery.com/id-selector/
        /// </summary>
        /// <param name="id">Id to search for</param>
        /// <returns>Self</returns>
        public ISelectorBuilder WithId(string id)
        {
            _builder.AppendFormat("#{0}", id.Escape());
            return this;
        }

        /// <summary>
        /// Add expression to selects elements that have the specified attribute
        /// http://api.jquery.com/has-attribute-selector/
        /// http://api.jquery.com/attribute-equals-selector/
        /// http://api.jquery.com/attribute-not-equal-selector/
        /// http://api.jquery.com/attribute-starts-with-selector/
        /// http://api.jquery.com/attribute-ends-with-selector/
        /// http://api.jquery.com/attribute-contains-word-selector/
        /// </summary>
        /// <param name="name">Name of the attribute to look for</param>
        /// <param name="value">Value to compare</param>
        /// <param name="mode">Comparison mode</param>
        /// <returns>Self</returns>
        public ISelectorBuilder WithHtmlAttribute(string name, string value = null, Comparison mode = Comparison.Equals)
        {
            _builder.Append(value == null ?
                string.Format("[{0}]", name.Escape()) :
                string.Format("[{0}{1}\"{2}\"]", name.Escape(), _modeDictionary[mode], value.Escape()));
            return this;
        }

        /// <summary>
        /// Add expression to selects elements with the given class
        /// http://api.jquery.com/class-selector/
        /// </summary>
        /// <param name="className">A class to search for</param>
        /// <returns>Self</returns>
        public ISelectorBuilder WithCssClass(string className)
        {
            _builder.AppendFormat(".{0}", className.Escape());
            return this;
        }

        /// <summary>
        /// Add expression to select elements that contains the specified text
        /// http://api.jquery.com/contains-selector/
        /// </summary>
        /// <param name="textPart">A string of text to look for. It's case sensitive.</param>
        /// <returns>Self</returns>
        public ISelectorBuilder WithText(string textPart)
        {
            _builder.AppendFormat(":contains(\"{0}\")", textPart.Escape());
            return this;
        }

        /// <summary>
        /// Add expression to selects as a descendant of the specified element  
        /// http://api.jquery.com/descendant-selector/
        /// </summary>
        /// <param name="selectorBuilder">Selector builder for the ancestor element</param>
        /// <returns>Self</returns>
        public ISelectorBuilder ChildOf(ISelectorBuilder selectorBuilder)
        {
            _builder.Insert(0, string.Format("{0} ", selectorBuilder.Build()));
            return this;
        }

        /// <summary>
        /// Add expression to selects elements which contain at least one element that matches the specified selector
        /// http://api.jquery.com/has-selector/
        /// </summary>
        /// <param name="selectorBuilder">Selector builder for the descendant element</param>
        /// <returns>Self</returns>
        public ISelectorBuilder HasChild(ISelectorBuilder selectorBuilder)
        {
            _builder.AppendFormat(":has({0})", selectorBuilder.Build());
            return this;
        }

        /// <summary>
        /// Add expression to selects elements that do not match the given selector.
        /// http://api.jquery.com/not-selector/
        /// </summary>
        /// <param name="selectorBuilder">Selector builder for the blacklisting</param>
        /// <returns>Self</returns>
        public ISelectorBuilder Not(ISelectorBuilder selectorBuilder)
        {
            _builder.AppendFormat(":not({0})", selectorBuilder.Build());
            return this;
        }

        /// <summary>
        /// Add expression to selects elements that are visible
        /// http://api.jquery.com/visible-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder Visible()
        {
            _builder.Append(":visible");
            return this;
        }

        /// <summary>
        /// Add expression to selects elements that are hidden
        /// http://api.jquery.com/hidden-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder Hidden()
        {
            _builder.Append(":hidden");
            return this;
        }

        /// <summary>
        /// Add expression to select elements that have no children (including text nodes)
        /// http://api.jquery.com/empty-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder Empty()
        {
            _builder.Append(":empty");
            return this;
        }

        /// <summary>
        /// Add expression to selects elements that are enabled
        /// http://api.jquery.com/enabled-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder Enabled()
        {
            _builder.Append(":enabled");
            return this;
        }

        /// <summary>
        /// Add expression to selects elements that are disabled
        /// http://api.jquery.com/disabled-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder Disabled()
        {
            _builder.Append(":disabled");
            return this;
        }

        /// <summary>
        /// Add expression to selects the first matched element
        /// http://api.jquery.com/first-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder First()
        {
            _builder.Append(":first");
            return this;
        }

        /// <summary>
        /// Add expression to selects the last matched element
        /// http://api.jquery.com/last-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder Last()
        {
            _builder.Append(":last");
            return this;
        }

        /// <summary>
        /// Add expression to select the element at (zero-based) index n within the matched set
        /// http://api.jquery.com/eq-selector/
        /// </summary>
        /// <param name="index">The index of the element</param>
        /// <returns>Self</returns>
        public ISelectorBuilder InSequence(int index)
        {
            _builder.AppendFormat(":eq({0})", index);
            return this;
        }

        /// <summary>
        /// Add expression to selects elements that are selected
        /// http://api.jquery.com/selected-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder Selected()
        {
            _builder.Append(":selected");
            return this;
        }

        /// <summary>
        /// Add expression to selects element if it is currently focused
        /// http://api.jquery.com/focus-selector/
        /// </summary>
        /// <returns>Self</returns>
        public ISelectorBuilder GotFocus()
        {
            _builder.Append(":focus");
            return this;
        }

        /// <summary>
        /// Creates the full jQuery selector expression
        /// </summary>
        /// <returns>jQuery selector</returns>
        public string Build()
        {
            return _builder.ToString();
        }
    }
}
