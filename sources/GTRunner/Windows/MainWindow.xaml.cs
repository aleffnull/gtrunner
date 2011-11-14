using System;

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

		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			Title = "Loaded";
			//throw new Exception("Test error");
		}
	}
}
