using OpenQA.Selenium;
using System.IO;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions
{
    internal static class ExecutorJavaScriptExtensions
    {
        private static object GetJsObject(this IJavaScriptExecutor executor, string command)
        {
            return executor.ExecuteScript(string.Format(@"return {0};", command));
        }

        internal static TReturned GetJsObject<TReturned>(this IJavaScriptExecutor executor, string command)
        {
            return (TReturned)executor.GetJsObject(command);
        }

        internal static void LoadJavaScriptLibray(this IJavaScriptExecutor executor, string fileName)
        {
            executor.ExecuteScript(LoadContent(fileName));
        }

        private static string LoadContent(string fileName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
