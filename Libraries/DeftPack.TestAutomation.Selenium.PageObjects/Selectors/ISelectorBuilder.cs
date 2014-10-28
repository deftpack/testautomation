namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    public interface ISelectorBuilder
    {
        /// <summary>
        /// Add expression to select element with the given id attribute
        /// </summary>
        /// <param name="id">Id to search for</param>
        /// <returns>Self</returns>
        ISelectorBuilder WithId(string id);

        /// <summary>
        /// Add expression to selects elements that have the specified attribute
        /// </summary>
        /// <param name="name">Name of the attribute to look for</param>
        /// <param name="value">Value to compare</param>
        /// <param name="mode">Comparison mode</param>
        /// <returns>Self</returns>
        ISelectorBuilder WithHtmlAttribute(string name, string value = null, Comparison mode = Comparison.Equals);

        /// <summary>
        /// Add expression to selects elements with the given class
        /// </summary>
        /// <param name="className">A class to search for</param>
        /// <returns>Self</returns>
        ISelectorBuilder WithCssClass(string className);

        /// <summary>
        /// Add expression to select elements that contains the specified text
        /// </summary>
        /// <param name="textPart">A string of text to look for. It's case sensitive.</param>
        /// <returns>Self</returns>
        ISelectorBuilder WithText(string textPart);

        /// <summary>
        /// Add expression to selects as a descendant of the specified element  
        /// </summary>
        /// <param name="selectorBuilder">Selector builder for the ancestor element</param>
        /// <returns>Self</returns>
        ISelectorBuilder ChildOf(ISelectorBuilder selectorBuilder);

        /// <summary>
        /// Add expression to selects elements which contain at least one element that matches the specified selector
        /// </summary>
        /// <param name="selectorBuilder">Selector builder for the descendant element</param>
        /// <returns>Self</returns>
        ISelectorBuilder HasChild(ISelectorBuilder selectorBuilder);

        /// <summary>
        /// Add expression to selects elements that do not match the given selector.
        /// </summary>
        /// <param name="selectorBuilder">Selector builder for the blacklisting</param>
        /// <returns>Self</returns>
        ISelectorBuilder Not(ISelectorBuilder selectorBuilder);

        /// <summary>
        /// Add expression to selects elements that are visible
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder Visible();

        /// <summary>
        /// Add expression to selects elements that are hidden
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder Hidden();

        /// <summary>
        /// Add expression to select elements that have no children (including text nodes)
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder Empty();

        /// <summary>
        /// Add expression to selects elements that are enabled
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder Enabled();

        /// <summary>
        /// Add expression to selects elements that are disabled
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder Disabled();

        /// <summary>
        /// Add expression to selects the first matched element
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder First();

        /// <summary>
        /// Add expression to selects the last matched element
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder Last();

        /// <summary>
        /// Add expression to select the element at (zero-based) index n within the matched set
        /// </summary>
        /// <param name="index">The index of the element</param>
        /// <returns>Self</returns>
        ISelectorBuilder InSequence(int index);

        /// <summary>
        /// Add expression to selects elements that are selected
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder Selected();

        /// <summary>
        /// Add expression to selects element if it is currently focused
        /// </summary>
        /// <returns>Self</returns>
        ISelectorBuilder GotFocus();

        /// <summary>
        /// Creates the full selector expression
        /// </summary>
        /// <returns>Selector</returns>
        string Build();
    }
}