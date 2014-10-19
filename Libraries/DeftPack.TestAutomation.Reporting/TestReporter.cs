using DeftPack.TestAutomation.Reporting.Models;
using DeftPack.TestAutomation.Reporting.Templating;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DeftPack.TestAutomation.Reporting
{
    /// <summary>
    /// Reporter class for each individual test
    /// </summary>
    public class TestReporter : ITestReporter
    {
        public event TestReporterFinishedHandler Finished;

        private readonly IReportSaver _reportSaver;
        private readonly ITemplateEngine _templateEngine;
        private readonly TestReport _testReport;
        private readonly List<StepReport> _stepReports = new List<StepReport>();
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public TestReporter(
            string title,
            DateTime starTime,
            ITestSummary testSummary,
            IReportSaver reportSaver,
            ITemplateEngine templateEngine)
        {
            _reportSaver = reportSaver;
            _templateEngine = templateEngine;
            _stopwatch.Start();
            _testReport = new TestReport
            {
                TestCaseName = testSummary.Name,
                TestDescription = testSummary.Description,
                ExecutionDate = starTime,
                Title = title
            };
        }

        /// <summary>
        /// Generate a record a test step
        /// </summary>
        /// <param name="stepName">Name of the test step</param>
        /// <param name="expectedResult">The expected outcome of the given test step</param>
        /// <param name="actualResult">The actual outcome of the step</param>
        /// <param name="status">Status of the step. If passed true, if failed false.</param>
        public void ReportStep(string stepName, string expectedResult, string actualResult, bool status)
        {
            _stepReports.Add(new StepReport
            {
                ActualResult = actualResult,
                ExpectedResult = expectedResult,
                StepName = stepName,
                StepStatus = status,
                StepNumber = _stepReports.Count + 1
            });
        }

        private void FinishReport()
        {
            var isAllStepsPassed = _stepReports.All(x => x.StepStatus);

            _stopwatch.Stop();
            _testReport.TimeSpent = _stopwatch.Elapsed;
            _testReport.Status = isAllStepsPassed;
            _testReport.StepResults = string.Join(Environment.NewLine,
                _stepReports.Select(sr => _templateEngine.GetContent(sr)));
            _reportSaver.Save(_testReport.TestCaseName, _templateEngine.GetContent(_testReport));

            if (Finished != null)
            {
                Finished(this, new TestReporterFinishedEventArgs
                {
                    TestDescription = _testReport.TestDescription,
                    TestName = _testReport.TestCaseName,
                    TestStatus = isAllStepsPassed
                });
            }
        }

        public void Dispose()
        {
            FinishReport();
        }
    }
}
