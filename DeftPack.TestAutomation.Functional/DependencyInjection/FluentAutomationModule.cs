using Autofac;
using DeftPack.TestAutomation.Reporting;
using DeftPack.TestAutomation.Selenium;
using FluentAutomation;
using FluentAutomation.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace DeftPack.TestAutomation.Functional.DependencyInjection
{
    public class FluentAutomationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var driverConfig = x.Resolve<WebDriverConfiguration>();
                return new FluentSettings
                {
                    ScreenshotPath = Path.Combine(x.Resolve<ReporterSetting>().RootFolderFullPath, TestScreenshotSaver.ScreenshotFolderName),
                    ScreenshotOnFailedAction = false,
                    ScreenshotOnFailedAssert = false,
                    ScreenshotOnFailedExpect = false,
                    WindowMaximized = true,
                    WaitTimeout = TimeSpan.FromSeconds(driverConfig.DefaultDriverWaitSeconds),
                    WaitUntilTimeout = TimeSpan.FromSeconds(driverConfig.DefaultDriverWaitSeconds)
                };
            }).SingleInstance();
            builder.Register<Func<IWebDriver>>(x => x.Resolve<IWebDriver>).InstancePerLifetimeScope();
            builder.RegisterType<LocalFileStoreProvider>().As<IFileStoreProvider>().InstancePerDependency();
            builder.RegisterType<CommandProvider>().As<ICommandProvider>().InstancePerLifetimeScope();
            builder.RegisterType<AssertProvider>().As<IAssertProvider>().InstancePerLifetimeScope();
            builder.RegisterType<ActionSyntaxProvider>().As<IActionSyntaxProvider>().InstancePerLifetimeScope();
        }
    }
}
