using System;
using System.Windows;

namespace GTRunner.Windows
{
	public partial class MainWindow
	{
		#region Constructors

		public MainWindow()
		{
			InitializeComponent();
		}

		#endregion Constructors

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			throw new Exception("Test error");
		}
	}
}
