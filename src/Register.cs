using System.Text.RegularExpressions;

namespace MovieDatabase
{
	/// <summary>
	/// The form used for creating a new user in the database.
	/// </summary>
	public partial class Register : Form
	{
		private UserDAO userDAO;
		public Register()
		{
			InitializeComponent();
			string[] countries = {
				"Czech Republic",
				"United States",
				"United Kingdom",
				"Germany",
				"Italy",
				"Hungary",
				"Romania",
				"Russia",
				"Mexico",
				"Brazil",
				"Belgium",
				"Netherlands"
			};
			Array.Sort(countries);
			comboBoxNationality.DataSource = countries;
			dateTimePickerDOB.MaxDate = DateTime.Now;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			userDAO = new UserDAO();
			if (textBoxUsername.Text.Length < 1 || textBoxPassword.Text.Length > 30)
			{
				MessageBox.Show("Username must be between 1 and 30 characters long!", "Unable to register user");
				return;
			}
			if (textBoxPassword.Text.Length <= 8 || textBoxPassword.Text.Length > 50)
			{
				MessageBox.Show("Password must be between 9 and 50 characters long!", "Unable to register user");
				return;
			}
			if (textBoxFirstName.Text.Length < 1 || textBoxFirstName.Text.Length > 30)
			{
				MessageBox.Show("First name must be between 1 and 30 characters long!", "Unable to register user");
				return;
			}
			if (textBoxSurname.Text.Length < 1 || textBoxSurname.Text.Length > 30)
			{
				MessageBox.Show("Surname must be between 1 and 30 characters long!", "Unable to register user");
				return;
			}
			if (textBoxPassword.Text != textBoxConfirmPassword.Text)
			{
				MessageBox.Show("Both passwords must match!");
				return;
			}
			DateOnly date = new DateOnly(dateTimePickerDOB.Value.Year, dateTimePickerDOB.Value.Month, dateTimePickerDOB.Value.Day);
			if (dateTimePickerDOB.Value > DateTime.Now)
			{
				MessageBox.Show("Date of birth must not be in the future!", "Unable to register user");
				return;
			}
			if (textBoxEmail.Text.Length > 320)
			{
				MessageBox.Show("E-Mail address must not be longer than 320 characters!", "Unable to register user");
				return;
			}
			if (!Regex.Match(textBoxEmail.Text, ".*@.*\\..*").Success)
			{
				MessageBox.Show("E-Mail address is not the correct format!");
				return;
			}
			User user = new User(textBoxUsername.Text, textBoxPassword.Text, textBoxFirstName.Text, textBoxSurname.Text, date, textBoxEmail.Text, comboBoxNationality.Text);
			try
			{
				userDAO.Upload(user);
				MessageBox.Show("Successfully registered " + user);
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to register user");
			}
		}

		private void Register_Load(object sender, EventArgs e)
		{

		}
	}
}
