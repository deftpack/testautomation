using Autofac;
using Autofac.Features.ResolveAnything;
using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.Reporting;
using DeftPack.TestAutomation.Reporting.Templating;
using DeftPack.TestAutomation.Selenium;
using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Functional.Framework
{
    public static class TestFramework
    {
        public static IContainer Container { get; private set; }

        static TestFramework()
        {
            var builder = new ContainerBuilder();
            RegisterSingletons(builder);
            RegisterTestScoped(builder);
            Container = builder.Build();
        }

        private static void RegisterTestScoped(ContainerBuilder builder)
        {
            builder.Register(x => x.Resolve<WebDriverFactory>().Default).InstancePerLifetimeScope();
            builder.RegisterType<TemplateEngine>().As<ITemplateEngine>().InstancePerLifetimeScope();
            builder.RegisterType<TestEvaluator>().As<ITestEvaluator>().InstancePerLifetimeScope();
            builder.Register(x =>
            {
                var setting = x.Resolve<ReporterSetting>();
                var webDriver = x.Resolve<IWebDriver>();
                return new TestScreenshotSaver(webDriver, setting.RootFolderFullPath);
            }).InstancePerLifetimeScope();
            builder.Register((x, p) =>
            {
                var setting = x.Resolve<ReporterSetting>();
                var reportSaver = x.Resolve<ReportSaver>();
                var templateEnige = x.Resolve<ITemplateEngine>();
                return new TestReporter(setting.Title, setting.StartTime, p.Named<ITestSummary>("testSummary"), reportSaver,
                    templateEnige);
            }).OnRelease(x => x.Dispose()).InstancePerLifetimeScope();
        }

        private static void RegisterSingletons(ContainerBuilder builder)
        {
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.Register(x => DateTime.Now).SingleInstance();
            builder.Register(x => ReporterConfiguration.Config).SingleInstance();
            builder.Register(x => WebDriverConfiguration.Config).SingleInstance();
            builder.Register(x => new ReportSaver(x.Resolve<ReporterSetting>().RootFolderFullPath));
            builder.RegisterType<ReporterSetting>().AsSelf().SingleInstance();
            builder.RegisterType<WebDriverFactory>().AsSelf().SingleInstance();
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
