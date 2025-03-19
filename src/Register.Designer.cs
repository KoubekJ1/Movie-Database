namespace MovieDatabase
{
	partial class Register
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
			labelUsername = new Label();
			labelPassword = new Label();
			textBoxUsername = new TextBox();
			textBoxPassword = new TextBox();
			labelConfirmPassword = new Label();
			textBoxConfirmPassword = new TextBox();
			labelFirstName = new Label();
			textBoxFirstName = new TextBox();
			labelSurname = new Label();
			textBoxSurname = new TextBox();
			labelDOB = new Label();
			labelEmail = new Label();
			textBoxEmail = new TextBox();
			labelNationality = new Label();
			dateTimePickerDOB = new DateTimePicker();
			comboBoxNationality = new ComboBox();
			button1 = new Button();
			SuspendLayout();
			// 
			// labelUsername
			// 
			labelUsername.AutoSize = true;
			labelUsername.Location = new Point(12, 9);
			labelUsername.Name = "labelUsername";
			labelUsername.Size = new Size(75, 20);
			labelUsername.TabIndex = 0;
			labelUsername.Text = "Username";
			// 
			// labelPassword
			// 
			labelPassword.AutoSize = true;
			labelPassword.Location = new Point(12, 62);
			labelPassword.Name = "labelPassword";
			labelPassword.Size = new Size(70, 20);
			labelPassword.TabIndex = 1;
			labelPassword.Text = "Password";
			// 
			// textBoxUsername
			// 
			textBoxUsername.Location = new Point(12, 32);
			textBoxUsername.Name = "textBoxUsername";
			textBoxUsername.Size = new Size(399, 27);
			textBoxUsername.TabIndex = 2;
			// 
			// textBoxPassword
			// 
			textBoxPassword.Location = new Point(12, 85);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.Size = new Size(399, 27);
			textBoxPassword.TabIndex = 3;
			// 
			// labelConfirmPassword
			// 
			labelConfirmPassword.AutoSize = true;
			labelConfirmPassword.Location = new Point(12, 115);
			labelConfirmPassword.Name = "labelConfirmPassword";
			labelConfirmPassword.Size = new Size(129, 20);
			labelConfirmPassword.TabIndex = 4;
			labelConfirmPassword.Text = "Confirm password";
			// 
			// textBoxConfirmPassword
			// 
			textBoxConfirmPassword.Location = new Point(12, 138);
			textBoxConfirmPassword.Name = "textBoxConfirmPassword";
			textBoxConfirmPassword.Size = new Size(399, 27);
			textBoxConfirmPassword.TabIndex = 5;
			// 
			// labelFirstName
			// 
			labelFirstName.AutoSize = true;
			labelFirstName.Location = new Point(12, 168);
			labelFirstName.Name = "labelFirstName";
			labelFirstName.Size = new Size(77, 20);
			labelFirstName.TabIndex = 6;
			labelFirstName.Text = "First name";
			// 
			// textBoxFirstName
			// 
			textBoxFirstName.Location = new Point(12, 191);
			textBoxFirstName.Name = "textBoxFirstName";
			textBoxFirstName.Size = new Size(399, 27);
			textBoxFirstName.TabIndex = 7;
			// 
			// labelSurname
			// 
			labelSurname.AutoSize = true;
			labelSurname.Location = new Point(12, 221);
			labelSurname.Name = "labelSurname";
			labelSurname.Size = new Size(67, 20);
			labelSurname.TabIndex = 8;
			labelSurname.Text = "Surname";
			// 
			// textBoxSurname
			// 
			textBoxSurname.Location = new Point(12, 244);
			textBoxSurname.Name = "textBoxSurname";
			textBoxSurname.Size = new Size(399, 27);
			textBoxSurname.TabIndex = 9;
			// 
			// labelDOB
			// 
			labelDOB.AutoSize = true;
			labelDOB.Location = new Point(12, 274);
			labelDOB.Name = "labelDOB";
			labelDOB.Size = new Size(94, 20);
			labelDOB.TabIndex = 10;
			labelDOB.Text = "Date of birth";
			// 
			// labelEmail
			// 
			labelEmail.AutoSize = true;
			labelEmail.Location = new Point(12, 327);
			labelEmail.Name = "labelEmail";
			labelEmail.Size = new Size(107, 20);
			labelEmail.TabIndex = 16;
			labelEmail.Text = "E-Mail address";
			// 
			// textBoxEmail
			// 
			textBoxEmail.Location = new Point(12, 350);
			textBoxEmail.Name = "textBoxEmail";
			textBoxEmail.Size = new Size(399, 27);
			textBoxEmail.TabIndex = 17;
			// 
			// labelNationality
			// 
			labelNationality.AutoSize = true;
			labelNationality.Location = new Point(12, 380);
			labelNationality.Name = "labelNationality";
			labelNationality.Size = new Size(82, 20);
			labelNationality.TabIndex = 18;
			labelNationality.Text = "Nationality";
			// 
			// dateTimePickerDOB
			// 
			dateTimePickerDOB.Location = new Point(12, 297);
			dateTimePickerDOB.MinDate = new DateTime(1930, 1, 1, 0, 0, 0, 0);
			dateTimePickerDOB.Name = "dateTimePickerDOB";
			dateTimePickerDOB.Size = new Size(399, 27);
			dateTimePickerDOB.TabIndex = 15;
			dateTimePickerDOB.Value = new DateTime(2025, 2, 14, 0, 0, 0, 0);
			// 
			// comboBoxNationality
			// 
			comboBoxNationality.FormattingEnabled = true;
			comboBoxNationality.Location = new Point(12, 403);
			comboBoxNationality.Name = "comboBoxNationality";
			comboBoxNationality.Size = new Size(399, 28);
			comboBoxNationality.TabIndex = 19;
			// 
			// button1
			// 
			button1.Location = new Point(12, 437);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 20;
			button1.Text = "Register";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// Register
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(423, 475);
			Controls.Add(button1);
			Controls.Add(comboBoxNationality);
			Controls.Add(dateTimePickerDOB);
			Controls.Add(labelNationality);
			Controls.Add(textBoxEmail);
			Controls.Add(labelEmail);
			Controls.Add(labelDOB);
			Controls.Add(textBoxSurname);
			Controls.Add(labelSurname);
			Controls.Add(textBoxFirstName);
			Controls.Add(labelFirstName);
			Controls.Add(textBoxConfirmPassword);
			Controls.Add(labelConfirmPassword);
			Controls.Add(textBoxPassword);
			Controls.Add(textBoxUsername);
			Controls.Add(labelPassword);
			Controls.Add(labelUsername);
			Name = "Register";
			Text = "Register";
			Load += Register_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelUsername;
		private Label labelPassword;
		private TextBox textBoxUsername;
		private TextBox textBoxPassword;
		private Label labelConfirmPassword;
		private TextBox textBoxConfirmPassword;
		private Label labelFirstName;
		private TextBox textBoxFirstName;
		private Label labelSurname;
		private TextBox textBoxSurname;
		private Label labelDOB;
		private Label labelEmail;
		private TextBox textBoxEmail;
		private Label labelNationality;
		private DateTimePicker dateTimePickerDOB;
		private ComboBox comboBoxNationality;
		private Button button1;
	}
}