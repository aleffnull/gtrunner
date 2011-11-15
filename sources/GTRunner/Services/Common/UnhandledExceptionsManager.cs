using System;
using System.Windows;
using Castle.Core.Logging;
using GTRunner.Properties;
using GTRunner.Windows;

namespace GTRunner.Services.Common
{
	public class UnhandledExceptionsManager
	{
		#region Fields

		private readonly ExceptionWindow exceptionWindow;
		private readonly ILogger logger;

		#endregion Fields

		#region Constructors

		public UnhandledExceptionsManager(ExceptionWindow exceptionWindow, ILogger logger)
		{
			this.exceptionWindow = exceptionWindow;
			this.logger = logger;
		}

		#endregion Constructors

		#region Methods

		public void Handle(Exception exception)
		{
			TryLogError(exception);
			TryShowErrorWindow(exception);

			Application.Current.Shutdown(-1);
		}

		#endregion Methods

		#region Helpers

		// ReSharper disable EmptyGeneralCatchClause
		private void TryLogError(Exception exception)
		{
			try
			{
				logger.Error(Resources.UnhandledExceptionCaught, exception);
			}
			catch
			{
				//
			}
		}
		// ReSharper restore EmptyGeneralCatchClause

		private void TryShowErrorWindow(Exception exceptionToShow)
		{
			try
			{
				exceptionWindow.ShowDialog();
			}
			catch (Exception exception)
			{
				TryLogError(exception);
			}
		}

		#endregion Helpers
	}
}