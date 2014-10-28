namespace DeftPack.TestAutomation.Reporting.Templating
{
    /// <summary>
    /// Creates output based on the template and its associated model
    /// </summary>
    public interface ITemplateEngine
    {
        /// <summary>
        /// Generate content from the model and its template
        /// </summary>
        /// <typeparam name="T">Type of the model</typeparam>
        /// <param name="model">Model that holds the data should be outputted</param>
        /// <returns>Generated content</returns>
        string GetContent<T>(T model);

        /// <summary>
        /// Generate content from the model and its template
        /// </summary>
        /// <typeparam name="T">Type of the model</typeparam>
        /// <param name="model">Model that holds the data should be outputted</param>
        /// <param name="templateName">The full qualified resource name of the template</param>
        /// <returns>Generated content</returns>
        string GetContent<T>(T model, string templateName);
    }
}