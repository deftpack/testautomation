using DeftPack.TestAutomation.Reporting.Models;
using DeftPack.TestAutomation.Reporting.Templating;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

namespace DeftPack.TestAutomation.Reporting
{
    public class IndexReporter : IIndexReporter
    {
        private const string IndexFileName = "index";

        private readonly IReportSaver _reportSaver;
        private readonly ITemplateEngine _templateEngine;
        private readonly ConcurrentQueue<TestSummary> _testSummaries = new ConcurrentQueue<TestSummary>();
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly TestSuiteReport _testSuiteReport;

        public IndexReporter(string title, DateTime startTime, IReportSaver reportSaver, ITemplateEngine templateEngine)
        {
            _reportSaver = reportSaver;
            _templateEngine = templateEngine;
            _stopwatch.Start();

            _testSuiteReport = new TestSuiteReport
            {
                ExecutionDate = startTime,
                Title = title
            };
        }

        public void HandleFinishedTestReport(ITestReporter t, TestReporterFinishedEventArgs args)
        {
            _testSummaries.Enqueue(new TestSummary
            {
                Description = args.TestDescription,
                Name = args.TestName,
                Status = args.TestStatus,
                Number = _testSummaries.Count + 1
            });
            GenerateReport();
        }

        //TODO: This is not thread-safe yet, needs to be changed
        private void GenerateReport()
        {
            _testSuiteReport.TimeSpent = _stopwatch.Elapsed;
            _testSuiteReport.FailCount = _testSummaries.Count(ts => !ts.Status);
            _testSuiteReport.PassCount = _testSummaries.Count - _testSuiteReport.FailCount;
            _testSuiteReport.TestSummaries = string.Join(string.Empty, _testSummaries.Select(sr => _templateEngine.GetContent(sr)));

            _reportSaver.Save(IndexFileName, _templateEngine.GetContent(_testSuiteReport));
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            GenerateReport();
        }
    }
}
