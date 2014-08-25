namespace DeftPack.TestAutomation
{
    public class TestReporterFinishedEventArgs : System.EventArgs
    {
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public bool TestStatus { get; set; }
    }
}
