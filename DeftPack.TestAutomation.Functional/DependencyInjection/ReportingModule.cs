using Autofac;
using DeftPack.TestAutomation.Reporting;
using DeftPack.TestAutomation.Reporting.Templating;

namespace DeftPack.TestAutomation.Functional.DependencyInjection
{
    public class ReportingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TemplateEngine>().As<ITemplateEngine>().InstancePerLifetimeScope();
            builder.RegisterType<ReporterSetting>().AsSelf().SingleInstance();
            builder.Register(x => new ReportSaver(x.Resolve<ReporterSetting>().RootFolderFullPath))
                .InstancePerDependency();
            builder.Register(x => ReporterConfiguration.Config).SingleInstance();
            
            builder.Register((x, p) =>
            {
                var setting = x.Resolve<ReporterSetting>();
                var reportSaver = x.Resolve<ReportSaver>();
                var templateEnige = x.Resolve<ITemplateEngine>();
                return new TestReporter(setting.Title, setting.StartTime, p.Named<ITestSummary>("testSummary"), reportSaver,
                    templateEnige);
            }).OnRelease(x => x.Dispose()).InstancePerLifetimeScope();

            builder.Register(x =>
            {
                var setting = x.Resolve<ReporterSetting>();
                var reportSaver = x.Resolve<ReportSaver>();
                var templateEnige = x.Resolve<ITemplateEngine>();
                return new IndexReporter(setting.Title, setting.StartTime, reportSaver, templateEnige);
            }).SingleInstance();
        }
    }
}
