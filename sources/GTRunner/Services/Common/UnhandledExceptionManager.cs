using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Castle.Core.Logging;
using GTRunner.Forms;
using GTRunner.Properties;

namespace GTRunner.Services.Common
{
	public class UnhandledExceptionManager
	{
		#region Fields

		private readonly ExceptionForm exceptionForm;
		private readonly ILogger logger;

		#endregion Fields

		#region Constructors

		public UnhandledExceptionManager(ExceptionForm exceptionForm, ILogger logger)
		{
			this.exceptionForm = exceptionForm;
			this.logger = logger;
		}

		#endregion Constructors

		#region Methods

		public void Attach()
		{
			if (Debugger.IsAttached)
			{
				return;
			}

			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += Application_ThreadException;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		}

		#endregion Methods

		#region Event handlers

		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			HandleException(e.Exception);
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			HandleException(e.ExceptionObject as Exception);
		}

		#endregion Event handlers

		#region Helpers

		private void HandleException(Exception e)
		{
			TryLogError(e);
			TryShowException(e);
			TryLogError(Resources.ApplicationTerminated);
			Environment.Exit(1);
		}

		// ReSharper disable EmptyGeneralCatchClause
		private void TryLogError(string error)
		{
			try
			{
				logger.Error(error);
			}
			catch
			{
				//
			}
		}
		// ReSharper restore EmptyGeneralCatchClause

		// ReSharper disable EmptyGeneralCatchClause
		private void TryLogError(Exception e)
		{
			try
			{
				logger.Error(Resources.UnhandledErrorOccurred, e);
			}
			catch
			{
				//
			}
		}
		// ReSharper restore EmptyGeneralCatchClause

		// ReSharper disable EmptyGeneralCatchClause
		private void TryLogError(string message, Exception e)
		{
			try
			{
				logger.Error(message, e);
			}
			catch
			{
				//
			}
		}
		// ReSharper restore EmptyGeneralCatchClause

		private void TryShowException(Exception exception)
		{
			try
			{
				exceptionForm.SetException(exception);
				exceptionForm.ShowDialog();
			}
			catch (Exception e)
			{
				TryLogError(Resources.FailedToShowExceptionWindow, e);
			}
		}

		#endregion Helpers
	}
}