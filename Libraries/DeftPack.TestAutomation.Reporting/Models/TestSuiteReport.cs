﻿namespace DeftPack.TestAutomation.Reporting.Models
{
    /// <summary>
    /// Test Suite Report Model
    /// </summary>
    internal class TestSuiteReport
    {
        public string Title { get; set; }
        public System.DateTime ExecutionDate { get; set; }
        public string TestSummaries { get; set; }
        public int PassCount { get; set; }
        public int FailCount { get; set; }
        public System.TimeSpan TimeSpent { get; set; }
    }
}
