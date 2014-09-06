namespace DeftPack.TestAutomation.Reporting.Models
{
    public class StepReport
    {
        public int StepNumber { get; set; }
        public string StepName { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }
        public bool StepStatus { get; set; }
    }
}
