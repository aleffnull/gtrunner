using System;
using System.Windows;
using Castle.Core.Logging;
using GTRunner.Properties;

namespace GTRunner.Services.Common
{
	public class UnhandledExceptionsManager
	{
		#region Fields

		private readonly ILogger logger;

		#endregion Fields

		#region Constructors

		public UnhandledExceptionsManager(ILogger logger)
		{
			this.logger = logger;
		}

		#endregion Constructors

		#region Methods

		public void Handle(Exception exception)
		{
			logger.Error(Resources.UnhandledExceptionCaught, exception);
			Application.Current.Shutdown(-1);
		}

		#endregion Methods
	}
}