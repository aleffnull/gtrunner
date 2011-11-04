using System;
using System.Windows.Forms;
using GTRunner.Forms;
using log4net.Config;

namespace GTRunner
{
	static class Program
	{
		#region Main

		[STAThread]
		static void Main()
		{
			XmlConfigurator.Configure();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		#endregion Main
	}
}
