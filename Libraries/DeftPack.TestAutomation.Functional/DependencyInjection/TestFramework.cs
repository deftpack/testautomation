using Autofac;
using Autofac.Features.ResolveAnything;
using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.Selenium;
using System;

namespace DeftPack.TestAutomation.Functional.DependencyInjection
{
    /// <summary>
    /// Setting up and exposing the IoC for internal dependency injection.
    /// </summary>
    public static class TestFramework
    {
        public static IContainer Container { get; private set; }

        static TestFramework()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ReportingModule>();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterType<WebDriverFactory>().AsSelf().SingleInstance();
            builder.RegisterType<TestEvaluator>().As<ITestEvaluator>().InstancePerLifetimeScope();
            builder.Register(x => DateTime.Now).SingleInstance();
            builder.Register(x => WebDriverConfiguration.Config).SingleInstance();
            builder.Register(x => x.Resolve<WebDriverFactory>().Default).InstancePerLifetimeScope();
            builder.RegisterType<TestActionDescriptionProvider>().As<ITestActionDescriptionProvider>().SingleInstance();

            Container = builder.Build();
        }
    }
}
