namespace DeftPack.TestAutomation
{
    public interface IReportSaver
    {
        void Save(string testName, string reportContent);
    }
}