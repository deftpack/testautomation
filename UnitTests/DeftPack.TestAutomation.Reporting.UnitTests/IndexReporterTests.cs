using DeftPack.TestAutomation.Reporting.Models;
using DeftPack.TestAutomation.Reporting.Templating;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Reporting.UnitTests
{
    public class IndexReporterTests
    {
        private string _reportContent;
        private readonly Mock<IReportSaver> _reportSaver = new Mock<IReportSaver>();
        private readonly Mock<ITemplateEngine> _templateEngine = new Mock<ITemplateEngine>();

        [SetUpAttribute]
        public void SetUp()
        {
            _reportSaver
                .Setup(rs => rs.Save(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((name,content) => _reportContent = content);
            _templateEngine.Setup(te => te.GetContent(It.IsAny<Models.TestSummary>())).Returns<Models.TestSummary>(ToString);
            _templateEngine.Setup(te => te.GetContent(It.IsAny<TestSuiteReport>())).Returns<TestSuiteReport>(ToString);
        }

        [Test]
        public void IndexReportGenerated()
        {
            var tests = new List<Models.TestSummary>
            {
                new Models.TestSummary { Number = 1, Name = "First", Description = "Do the first test", Status = true},
                new Models.TestSummary { Number = 2, Name = "Second", Description = "Do the second test", Status = false},
                new Models.TestSummary { Number = 3, Name = "Third", Description = "Do the third test", Status = true}
            };

            var testReport = new TestSuiteReport
            {
                ExecutionDate = DateTime.Now,
                Title = "Title",
                PassCount = 2,
                FailCount = 1,
                TestSummaries = string.Join(Environment.NewLine, tests.Select(ToString))
            };

            using (
                var reporter = new IndexReporter(testReport.Title, testReport.ExecutionDate, _reportSaver.Object, _templateEngine.Object))
            {
                reporter.HandleFinishedTestReport(null, new TestReporterFinishedEventArgs
                {
                    TestName = tests[0].Name,TestDescription = tests[0].Description, TestStatus = tests[0].Status
                });
                reporter.HandleFinishedTestReport(null, new TestReporterFinishedEventArgs
                {
                    TestName = tests[1].Name, TestDescription = tests[1].Description, TestStatus = tests[1].Status
                });
                reporter.HandleFinishedTestReport(null, new TestReporterFinishedEventArgs
                {
                    TestName = tests[2].Name, TestDescription = tests[2].Description, TestStatus = tests[2].Status
                });
            }

            Assert.AreEqual(_reportContent, ToString(testReport));
        }

        private string ToString(Models.TestSummary summary)
        {
            return string.Format("{0}|{1}|{2}|{3}", summary.Number, summary.Name, summary.Description, summary.Status);
        }

        private string ToString(TestSuiteReport suiteReport)
        {
            return string.Format("{0}|{1}|{2}|{3}\n{4}", suiteReport.Title, suiteReport.PassCount, suiteReport.FailCount, 
                suiteReport.ExecutionDate, suiteReport.TestSummaries);
        }
    }
}
