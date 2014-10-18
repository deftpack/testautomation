using Autofac;
using DeftPack.TestAutomation.Reporting;
using DeftPack.TestAutomation.Reporting.Templating;

namespace DeftPack.TestAutomation.Functional.DependencyInjection
{
    /// <summary>
    /// Module to register all the reporting related types in the IoC (AutoFac container)
    /// </summary>
    public class ReportingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TemplateEngine>().As<ITemplateEngine>().InstancePerLifetimeScope();
            builder.RegisterType<ReporterSetting>().AsSelf().SingleInstance();
            builder.Register(x => new ReportSaver(x.Resolve<ReporterSetting>().RootFolderFullPath))
                .As<IReportSaver>()
                .InstancePerDependency();
            builder.Register(x => ReporterConfiguration.Config).SingleInstance();

            builder.Register((x, p) =>
            {
                var setting = x.Resolve<ReporterSetting>();
                var reportSaver = x.Resolve<IReportSaver>();
                var templateEnige = x.Resolve<ITemplateEngine>();
                return new TestReporter(setting.Title, setting.StartTime, p.Named<ITestSummary>("testSummary"), reportSaver,
                    templateEnige);
            }).As<ITestReporter>().OnRelease(x => x.Dispose()).InstancePerLifetimeScope();

            builder.Register(x =>
            {
                var setting = x.Resolve<ReporterSetting>();
                var reportSaver = x.Resolve<IReportSaver>();
                var templateEnige = x.Resolve<ITemplateEngine>();
                return new IndexReporter(setting.Title, setting.StartTime, reportSaver, templateEnige);
            }).As<IIndexReporter>().SingleInstance();
        }
    }
}
