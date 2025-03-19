namespace MovieDatabase
{
	partial class Login
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
			textBoxUsername = new TextBox();
			labelUsername = new Label();
			labelPassword = new Label();
			textBoxPassword = new TextBox();
			buttonLogin = new Button();
			buttonRegister = new Button();
			checkBoxSavePassword = new CheckBox();
			SuspendLayout();
			// 
			// textBoxUsername
			// 
			textBoxUsername.Location = new Point(12, 32);
			textBoxUsername.Name = "textBoxUsername";
			textBoxUsername.Size = new Size(399, 27);
			textBoxUsername.TabIndex = 0;
			textBoxUsername.TextChanged += textBoxUsername_TextChanged;
			// 
			// labelUsername
			// 
			labelUsername.AutoSize = true;
			labelUsername.Location = new Point(12, 9);
			labelUsername.Name = "labelUsername";
			labelUsername.Size = new Size(75, 20);
			labelUsername.TabIndex = 1;
			labelUsername.Text = "Username";
			// 
			// labelPassword
			// 
			labelPassword.AutoSize = true;
			labelPassword.Location = new Point(12, 62);
			labelPassword.Name = "labelPassword";
			labelPassword.Size = new Size(70, 20);
			labelPassword.TabIndex = 2;
			labelPassword.Text = "Password";
			// 
			// textBoxPassword
			// 
			textBoxPassword.Location = new Point(12, 85);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.Size = new Size(399, 27);
			textBoxPassword.TabIndex = 3;
			// 
			// buttonLogin
			// 
			buttonLogin.Location = new Point(12, 118);
			buttonLogin.Name = "buttonLogin";
			buttonLogin.Size = new Size(94, 29);
			buttonLogin.TabIndex = 4;
			buttonLogin.Text = "Log in";
			buttonLogin.UseVisualStyleBackColor = true;
			buttonLogin.Click += buttonLogin_Click;
			// 
			// buttonRegister
			// 
			buttonRegister.Location = new Point(112, 118);
			buttonRegister.Name = "buttonRegister";
			buttonRegister.Size = new Size(94, 29);
			buttonRegister.TabIndex = 5;
			buttonRegister.Text = "Register";
			buttonRegister.UseVisualStyleBackColor = true;
			buttonRegister.Click += buttonRegister_Click;
			// 
			// checkBoxSavePassword
			// 
			checkBoxSavePassword.AutoSize = true;
			checkBoxSavePassword.Location = new Point(212, 121);
			checkBoxSavePassword.Name = "checkBoxSavePassword";
			checkBoxSavePassword.Size = new Size(129, 24);
			checkBoxSavePassword.TabIndex = 6;
			checkBoxSavePassword.Text = "Save password";
			checkBoxSavePassword.UseVisualStyleBackColor = true;
			// 
			// Login
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(423, 160);
			Controls.Add(checkBoxSavePassword);
			Controls.Add(buttonRegister);
			Controls.Add(buttonLogin);
			Controls.Add(textBoxPassword);
			Controls.Add(labelPassword);
			Controls.Add(labelUsername);
			Controls.Add(textBoxUsername);
			Name = "Login";
			Text = "Login";
			Load += Login_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBoxUsername;
		private Label labelUsername;
		private Label labelPassword;
		private TextBox textBoxPassword;
		private Button buttonLogin;
		private Button buttonRegister;
		private CheckBox checkBoxSavePassword;
	}
}