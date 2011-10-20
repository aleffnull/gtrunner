using System;
using System.Windows.Forms;
using GTRunner.Forms;

namespace GTRunner
{
	static class Program
	{
		#region Main

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		#endregion Main
	}
}
