using System.Diagnostics;
using System.Windows.Forms;

namespace GTRunner.Services.Common
{
	public class ExceptionsManager
	{
		#region Properties

		public bool HandleExceptions
		{
			get { return !Debugger.IsAttached; }
		}

		#endregion Properties

		#region Methods

		public void SetMode()
		{
			if (HandleExceptions)
			{
				Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			}
		}

		#endregion Methods
	}
}