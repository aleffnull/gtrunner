using System;
using System.Diagnostics;
using System.Windows.Forms;
using Castle.Facilities.Logging;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GTRunner.Forms;
using GTRunner.Properties;
using GTRunner.Services.Common;
using log4net;
using log4net.Config;

namespace GTRunner
{
	static class Program
	{
		#region Fields

		private static readonly ILog log = LogManager.GetLogger(typeof(Program));

		#endregion Fields

		#region Main

		[STAThread]
		static void Main()
		{
			XmlConfigurator.Configure();
			log.Info(Resources.ApplicationStarted);

			RunApplication();
			log.Info(Resources.ApplicationStopped);
		}

		#endregion Main

		#region Helpers

		private static void AttachExceptionManager(UnhandledExceptionManager exceptionManager)
		{
			Application.ThreadException += exceptionManager.Application_ThreadException;
			AppDomain.CurrentDomain.UnhandledException += exceptionManager.CurrentDomain_UnhandledException;
		}

		private static IWindsorContainer GetContainer()
		{
			var container = new WindsorContainer().Install(FromAssembly.This());
			container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());

			return container;
		}

		private static void RunApplication()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (!Debugger.IsAttached)
			{
				Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			}

			using (var container = GetContainer())
			{
				var exceptionManager = container.Resolve<UnhandledExceptionManager>();
				if (!Debugger.IsAttached)
				{
					AttachExceptionManager(exceptionManager);
				}

				var mainForm = container.Resolve<MainForm>();
				Application.Run(mainForm);
			}
		}

		#endregion Helpers
	}
}
