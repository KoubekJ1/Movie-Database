using System.Configuration;

namespace MovieDatabase
{
	/// <summary>
	/// The form used for logging in
	/// </summary>
	public partial class Login : Form
	{
		private Register register = new Register();

		public Login()
		{
			InitializeComponent();
			textBoxPassword.KeyPress += new KeyPressEventHandler((object? sender, KeyPressEventArgs e) =>
			{
				if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
				{
					buttonLogin_Click(sender, e);
				}
			});
		}

		private void Login_Load(object sender, EventArgs e)
		{

		}

		private void buttonRegister_Click(object sender, EventArgs e)
		{
			if (register is not null) register.Close();
			register = new Register();
			register.Show();
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			UserDAO userDAO = MovieDatabaseManager.GetManager().UserDAO;
			try
			{
				userDAO.Login(textBoxUsername.Text, textBoxPassword.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
			if (userDAO.CurrentUser == null)
			{
				MessageBox.Show("Invalid login credentials", "Unable to log in");
			}
			else
			{
				if (checkBoxSavePassword.Checked)
				{
					try
					{
						var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
						configFile.AppSettings.Settings["Username"].Value = textBoxUsername.Text;
						configFile.AppSettings.Settings["User_Password"].Value = textBoxPassword.Text;
						configFile.Save(ConfigurationSaveMode.Modified);
						ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Unable to save credentials");
					}
				}
				this.Close();
			}
		}

		private void textBoxUsername_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
