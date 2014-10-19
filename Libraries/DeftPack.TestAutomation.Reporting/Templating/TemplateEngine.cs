using RazorEngine;
using System.IO;
using System.Reflection;

namespace DeftPack.TestAutomation.Reporting.Templating
{
    /// <summary>
    /// Creates output based on the template and its associated model
    /// </summary>
    public class TemplateEngine : ITemplateEngine
    {
        /// <summary>
        /// Generate content from the model and its template
        /// </summary>
        /// <typeparam name="T">Type of the model</typeparam>
        /// <param name="model">Model that holds the data should be outputted</param>
        /// <returns>Generated content</returns>
        public string GetContent<T>(T model)
        {
            var fileName = typeof(T).FullName.Replace("Models", "Templates");
            var templateName = string.Format("{0}.html", fileName);
            return GetContent(model, templateName);
        }

        /// <summary>
        /// Generate content from the model and its template
        /// </summary>
        /// <typeparam name="T">Type of the model</typeparam>
        /// <param name="model">Model that holds the data should be outputted</param>
        /// <param name="templateName">The full qualified resource name of the template</param>
        /// <returns>Generated content</returns>
        public string GetContent<T>(T model, string templateName)
        {
            var template = LoadTemplate(templateName);
            return Razor.Parse(template, model);
        }

        private string LoadTemplate(string templateName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(templateName);
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}