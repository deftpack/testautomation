namespace DeftPack.TestAutomation.Reporting.Models
{
    /// <summary>
    /// Test Report Model
    /// </summary>
    public class TestReport
    {
        public string Title { get; set; }
        public string TestCaseName { get; set; }
        public System.DateTime ExecutionDate { get; set; }
        public string TestDescription { get; set; }
        public string StepResults { get; set; }
        public System.TimeSpan TimeSpent { get; set; }
        public bool Status { get; set; }
    }
}
