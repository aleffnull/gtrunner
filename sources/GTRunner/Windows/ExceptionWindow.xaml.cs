using System;

namespace GTRunner.Windows
{
	public partial class ExceptionWindow
	{
		#region Constructors

		public ExceptionWindow()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		public void SetException(Exception exception)
		{
			ExceptionTextBox.Text = exception.ToString();
		}

		#endregion Methods

		#region Event handlers

		private void OkButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			Close();
		}

		#endregion Event handlers
	}
}
