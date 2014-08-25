namespace DeftPack.TestAutomation.Reporting.Templating
{
    public interface ITemplateEngine
    {
        string GetContent<T>(T model);
        string GetContent<T>(T model, string templateName);
    }
}