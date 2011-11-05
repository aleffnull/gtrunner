using System;
using System.Windows.Forms;

namespace GTRunner.Forms
{
	public partial class ExceptionForm : Form
	{
		#region Constructors

		public ExceptionForm()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		public void SetException(Exception exception)
		{
			exceptionTextBox.Text = exception.ToString();
		}

		#endregion Methods
	}
}