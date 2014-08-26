using Autofac;
using Autofac.Features.ResolveAnything;
using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.Reporting;
using DeftPack.TestAutomation.Selenium;
using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Functional.DependencyInjection
{
    public static class TestFramework
    {
        public static IContainer Container { get; private set; }

        static TestFramework()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<FluentAutomationModule>();
            builder.RegisterModule<ReportingModule>();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterType<WebDriverFactory>().AsSelf().SingleInstance();
            builder.RegisterType<TestEvaluator>().As<ITestEvaluator>().InstancePerLifetimeScope();
            builder.Register(x => DateTime.Now).SingleInstance();
            builder.Register(x => WebDriverConfiguration.Config).SingleInstance();
            builder.Register(x => x.Resolve<WebDriverFactory>().Default).InstancePerLifetimeScope();
            builder.Register(x =>
            {
                var setting = x.Resolve<ReporterSetting>();
                var webDriver = x.Resolve<IWebDriver>();
                return new TestScreenshotSaver(webDriver, setting.RootFolderFullPath);
            }).InstancePerLifetimeScope();

            Container = builder.Build();
        }
    }
}
