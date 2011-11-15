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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Title = "Loaded";
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			throw new Exception("Test error");
		}
	}
}
