using System;
using System.Windows;
using Castle.Facilities.Logging;
using Castle.Windsor;
using Castle.Windsor.Installer;
using log4net.Config;

namespace GTRunner
{
	public partial class App
	{
		#region Fields

		private IWindsorContainer container;

		#endregion Fields

		#region Event handlers

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			XmlConfigurator.Configure();
			container = GetContainer();
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		}

		private void App_OnExit(object sender, ExitEventArgs e)
		{
			if (container != null)
			{
				container.Dispose();
			}
		}

		void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			//
		}

		#endregion Event handlers

		#region Helpers

		private static IWindsorContainer GetContainer()
		{
			var container = new WindsorContainer().Install(FromAssembly.This());
			container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());

			return container;
		}

		#endregion Helpers
	}
}
