using DeftPack.TestAutomation.Reporting.Models;
using DeftPack.TestAutomation.Reporting.Templating;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Reporting.UnitTests
{
    [TestFixture]
    public class TestReporterTests
    {
        private string _reportContent;
        private readonly Mock<IReportSaver> _reportSaver = new Mock<IReportSaver>();
        private readonly Mock<ITemplateEngine> _templateEngine = new Mock<ITemplateEngine>();

        [SetUp]
        public void SetUp()
        {
            _reportSaver
                .Setup(rs => rs.Save(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((name, content) => _reportContent = content);
            _templateEngine.Setup(te => te.GetContent(It.IsAny<StepReport>())).Returns<StepReport>(ToString);
            _templateEngine.Setup(te => te.GetContent(It.IsAny<TestReport>())).Returns<TestReport>(ToString);
        }

        [Test]
        public void ReportGeneratedAboutSuccesfulTest()
        {
            var steps = new List<StepReport>
            {
                new StepReport {
                    StepNumber = 1, StepName = "First", ExpectedResult = "Do the first thing", 
                    ActualResult = "First thing is done", StepStatus = true
                },
                new StepReport {
                    StepNumber = 2, StepName = "Second", ExpectedResult = "Do the second thing", 
                    ActualResult = "Second thing is done", StepStatus = true
                },
                new StepReport {
                    StepNumber = 3, StepName = "Third", ExpectedResult = "Do the third thing", 
                    ActualResult = "Third thing is done", StepStatus = true
                }
            };

            var testReport = new TestReport
            {
                ExecutionDate = DateTime.Now,
                Status = true,
                TestCaseName = "Name",
                Title = "Title",
                TestDescription = "Description",
                StepResults = string.Join(Environment.NewLine, steps.Select(ToString))
            };

            using (
                var reporter = new TestReporter(testReport.Title, testReport.ExecutionDate,
                    new TestSummary { Description = testReport.TestDescription, Name = testReport.TestCaseName },
                    _reportSaver.Object, _templateEngine.Object))
            {
                reporter.ReportStep(steps[0].StepName, steps[0].ExpectedResult, steps[0].ActualResult, steps[0].StepStatus);
                reporter.ReportStep(steps[1].StepName, steps[1].ExpectedResult, steps[1].ActualResult, steps[1].StepStatus);
                reporter.ReportStep(steps[2].StepName, steps[2].ExpectedResult, steps[2].ActualResult, steps[2].StepStatus);
            }

            Assert.AreEqual(_reportContent, ToString(testReport));
        }

        [Test]
        public void ReportGeneratedAboutFailedTest()
        {
            var steps = new List<StepReport>
            {
                new StepReport {
                    StepNumber = 1, StepName = "First", ExpectedResult = "Do the first thing", 
                    ActualResult = "First thing is done", StepStatus = true
                },
                new StepReport {
                    StepNumber = 2, StepName = "Second", ExpectedResult = "Do the second thing", 
                    ActualResult = "Second thing is done", StepStatus = true
                },
                new StepReport {
                    StepNumber = 3, StepName = "Third", ExpectedResult = "Do the third thing", 
                    ActualResult = "Third thing is done", StepStatus = false
                }
            };

            var testReport = new TestReport
            {
                ExecutionDate = DateTime.Now,
                Status = false,
                TestCaseName = "Name",
                Title = "Title",
                TestDescription = "Description",
                StepResults = string.Join(Environment.NewLine, steps.Select(ToString))
            };

            using (
                var reporter = new TestReporter(testReport.Title, testReport.ExecutionDate,
                    new TestSummary { Description = testReport.TestDescription, Name = testReport.TestCaseName },
                    _reportSaver.Object, _templateEngine.Object))
            {
                reporter.ReportStep(steps[0].StepName, steps[0].ExpectedResult, steps[0].ActualResult, steps[0].StepStatus);
                reporter.ReportStep(steps[1].StepName, steps[1].ExpectedResult, steps[1].ActualResult, steps[1].StepStatus);
                reporter.ReportStep(steps[2].StepName, steps[2].ExpectedResult, steps[2].ActualResult, steps[2].StepStatus);
            }

            Assert.AreEqual(_reportContent, ToString(testReport));
        }

        private string ToString(StepReport stepReport)
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}", stepReport.StepNumber, stepReport.StepName,
                stepReport.ExpectedResult, stepReport.ActualResult, stepReport.StepStatus);
        }

        private string ToString(TestReport stepReport)
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}\n{5}", stepReport.Title,
                stepReport.TestCaseName, stepReport.TestDescription, stepReport.ExecutionDate,
                stepReport.Status, stepReport.StepResults);
        }
    }
}
