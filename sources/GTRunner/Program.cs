using System;
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

			using (var container = GetContainer())
			{
				var exceptionManager = container.Resolve<UnhandledExceptionManager>();
				exceptionManager.Attach();
				//throw new Exception("test");
				var mainForm = container.Resolve<MainForm>();
				Application.Run(mainForm);
			}
		}

		#endregion Helpers
	}
}
