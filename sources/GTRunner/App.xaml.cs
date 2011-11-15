using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using Castle.Facilities.Logging;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GTRunner.Services.Common;
using GTRunner.Windows;
using log4net.Config;

namespace GTRunner
{
	public partial class App
	{
		#region Fields

		private IWindsorContainer container;

		#endregion Fields

		#region Properties

		private IWindsorContainer Container
		{
			get { return container ?? (container = GetContainer()); }
		}

		private UnhandledExceptionsManager ExceptionsManager
		{
			get { return Container.Resolve<UnhandledExceptionsManager>(); }
		}

		#endregion Properties

		#region Event handlers

		private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			ExceptionsManager.Handle(e.Exception);
			e.Handled = true;
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			XmlConfigurator.Configure();
			RunApplication();
		}

		private void App_OnExit(object sender, ExitEventArgs e)
		{
			Container.Dispose();
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			ExceptionsManager.Handle(e.ExceptionObject as Exception);
		}

		#endregion Event handlers

		#region Helpers

		private static IWindsorContainer GetContainer()
		{
			var container = new WindsorContainer().Install(FromAssembly.This());
			container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());

			return container;
		}

		private void RunApplication()
		{
			if (!Debugger.IsAttached)
			{
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			}

			ShutdownMode = ShutdownMode.OnMainWindowClose;
			MainWindow = Container.Resolve<MainWindow>();
			MainWindow.Show();
		}

		#endregion Helpers
	}
}
