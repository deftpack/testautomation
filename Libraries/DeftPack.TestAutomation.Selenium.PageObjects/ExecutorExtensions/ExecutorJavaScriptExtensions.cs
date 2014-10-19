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

        /// <summary>
        /// Fetches JavaScript objects
        /// </summary>
        /// <typeparam name="TReturned">Type of the object returned</typeparam>
        /// <param name="executor">The executor to be used</param>
        /// <param name="command">Client side command to be executed</param>
        /// <returns>Returns the object returned on the client side by the command</returns>
        internal static TReturned GetJsObject<TReturned>(this IJavaScriptExecutor executor, string command)
        {
            return (TReturned)executor.GetJsObject(command);
        }

        /// <summary>
        /// Loads a JavaScript library to the browsers memory
        /// </summary>
        /// <param name="executor">The executor to be used</param>
        /// <param name="fileName">Full qualified name of the resource to be loaded</param>
        internal static void LoadJavaScriptLibrary(this IJavaScriptExecutor executor, string fileName)
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
