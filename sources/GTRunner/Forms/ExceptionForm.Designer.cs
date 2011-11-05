// Copyright (C) 2005 - 2007 American College of Radiology
//

namespace GTRunner.Forms
{
	sealed partial class ExceptionForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
			this.okButton = new System.Windows.Forms.Button();
			this.errorPictureBox = new System.Windows.Forms.PictureBox();
			this.exceptionTextBox = new System.Windows.Forms.TextBox();
			this.MessageLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(293, 322);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "&OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// errorPictureBox
			// 
			this.errorPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("errorPictureBox.Image")));
			this.errorPictureBox.Location = new System.Drawing.Point(12, 12);
			this.errorPictureBox.Name = "errorPictureBox";
			this.errorPictureBox.Size = new System.Drawing.Size(34, 35);
			this.errorPictureBox.TabIndex = 3;
			this.errorPictureBox.TabStop = false;
			// 
			// exceptionTextBox
			// 
			this.exceptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.exceptionTextBox.Location = new System.Drawing.Point(12, 53);
			this.exceptionTextBox.Multiline = true;
			this.exceptionTextBox.Name = "exceptionTextBox";
			this.exceptionTextBox.ReadOnly = true;
			this.exceptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.exceptionTextBox.Size = new System.Drawing.Size(636, 263);
			this.exceptionTextBox.TabIndex = 4;
			// 
			// MessageLabel
			// 
			this.MessageLabel.AutoSize = true;
			this.MessageLabel.Location = new System.Drawing.Point(52, 23);
			this.MessageLabel.Name = "MessageLabel";
			this.MessageLabel.Size = new System.Drawing.Size(212, 13);
			this.MessageLabel.TabIndex = 5;
			this.MessageLabel.Text = "An error occurred, application will be closed";
			// 
			// ExceptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 357);
			this.Controls.Add(this.MessageLabel);
			this.Controls.Add(this.exceptionTextBox);
			this.Controls.Add(this.errorPictureBox);
			this.Controls.Add(this.okButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExceptionForm";
			this.ShowIcon = false;
			this.Text = "Error";
			((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.PictureBox errorPictureBox;
		private System.Windows.Forms.TextBox exceptionTextBox;
		private System.Windows.Forms.Label MessageLabel;
	}
}