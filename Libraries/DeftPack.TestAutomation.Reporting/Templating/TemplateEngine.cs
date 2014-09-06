using RazorEngine;
using System.IO;
using System.Reflection;

namespace DeftPack.TestAutomation.Reporting.Templating
{
    public class TemplateEngine : ITemplateEngine
    {
        public string GetContent<T>(T model)
        {
            var fileName = typeof(T).FullName.Replace("Models", "Templates");
            var templateName = string.Format("{0}.html", fileName);
            var template = LoadTemplate(templateName);
            return Razor.Parse(template, model);
        }

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