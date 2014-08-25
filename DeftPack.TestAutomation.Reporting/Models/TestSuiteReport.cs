namespace DeftPack.TestAutomation.Reporting.Models
{
    public class TestSuiteReport
    {
        public string Title { get; set; }
        public System.DateTime ExecutionDate { get; set; }
        public string TestSummaries { get; set; }
        public int PassCount { get; set; }
        public int FailCount { get; set; }
        public System.TimeSpan TimeSpent { get; set; }
    }
}
