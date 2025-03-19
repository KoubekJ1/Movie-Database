using Microsoft.Data.SqlClient;
using System.Configuration;

namespace MovieDatabase
{
	public static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.

			try
			{
				SqlConnection connection = DatabaseConnection.GetConnection();
				connection.Open();
				connection.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to connect to the database");
				return;
			}

			ApplicationConfiguration.Initialize();

			string? username = ConfigurationManager.AppSettings["Username"];
			string? password = ConfigurationManager.AppSettings["User_Password"];

			UserDAO userDAO = MovieDatabaseManager.GetManager().UserDAO;
			if (username is not null && username.Length > 0 && password is not null && password.Length > 0)
			{
				userDAO.Login(username, password);
				if (userDAO.CurrentUser == null)
				{
					MessageBox.Show("Incorrect saved credentials!", "Unable to log in");
					try
					{
						var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
						configFile.AppSettings.Settings["Username"].Value = "";
						configFile.AppSettings.Settings["User_Password"].Value = "";
						configFile.Save(ConfigurationSaveMode.Modified);
						ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Unable to save credentials");
					}
				}
			}

			if (userDAO.CurrentUser == null)
			{
				Application.Run(new Login());
			}

			if (userDAO.CurrentUser != null)
			{
				Application.Run(new MainGUI());
			}
		}
	}
}