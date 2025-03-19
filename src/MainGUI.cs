using Microsoft.VisualBasic;
using System.Configuration;
using System.Text.Json;

namespace MovieDatabase
{
	/// <summary>
	/// The main form of the program from which all operations are performed.
	/// </summary>
	public partial class MainGUI : Form
	{
		private Movie? selectedMovie;

		private void movieModified()
		{
			buttonSave.Enabled = true;
		}

		private void updateMovies()
		{
			listBoxMovies.Items.Clear();
			Movie[] movies = MovieDatabaseManager.GetManager().Movies.ToArray();
			Array.Sort(movies, delegate (Movie a, Movie b) { return a.Name.CompareTo(b.Name); });
			listBoxMovies.Items.AddRange(movies);
		}

		public MainGUI()
		{
			InitializeComponent();
			dateTimePickerRD.MaxDate = DateTime.Now;
			splitContainer1.Panel2.Enabled = false;
			buttonSave.Enabled = false;
		}

		private void MainGUI_Load(object sender, EventArgs e)
		{

		}

		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void trackBarRating_Scroll(object sender, EventArgs e)
		{
			labelRatingNumber.Text = Convert.ToString((double)trackBarRating.Value / 10);
			movieModified();
		}

		private void listBoxMovies_SelectedIndexChanged(object sender, EventArgs e)
		{
			listBoxGenres.Items.Clear();
			buttonRemoveGenre.Enabled = false;
			listBoxActors.Items.Clear();
			buttonRemoveActor.Enabled = false;
			Movie? movie = (Movie?)listBoxMovies.SelectedItem;
			selectedMovie = movie;
			checkBoxAddToList.CheckedChanged -= checkBoxAddToList_CheckedChanged;
			checkBoxAddToList.Checked = MovieDatabaseManager.GetManager().UserDAO.CurrentUser.MovieList.Any(s => s.Equals(selectedMovie));
			checkBoxAddToList.CheckedChanged += checkBoxAddToList_CheckedChanged;
			if (movie == null)
			{
				splitContainer1.Panel2.Enabled = false;
				return;
			}
			textBoxName.Text = movie.Name;
			textBoxDesc.Text = movie.Description;
			dateTimePickerRD.Value = new DateTime(movie.ReleaseDate, TimeOnly.MinValue);
			labelRatingNumber.Text = Convert.ToString(movie.Rating);
			trackBarRating.Value = (int)(movie.Rating * 10);

			foreach (Genre genre in movie.Genres)
			{
				listBoxGenres.Items.Add(genre);
			}
			foreach (Actor actor in movie.Actors)
			{
				listBoxActors.Items.Add(actor);
			}

			splitContainer1.Panel2.Enabled = true;
			buttonSave.Enabled = false;
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			new SearchForm().ShowDialog();
			updateMovies();
		}

		private void newMovieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new NewMovieForm().ShowDialog();
			updateMovies();
		}

		private void textBoxName_TextChanged(object sender, EventArgs e)
		{
			movieModified();
		}

		private void textBoxDesc_TextChanged(object sender, EventArgs e)
		{
			movieModified();
		}

		private void dateTimePickerRD_ValueChanged(object sender, EventArgs e)
		{
			movieModified();
		}

		private void buttonDelete_Click_1(object sender, EventArgs e)
		{
			if (selectedMovie == null) return;
			if (MessageBox.Show("Are you sure you want to delete " + selectedMovie + "?", "Delete movie", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					new MovieDAO().Delete((int)selectedMovie.ID);
					MovieDatabaseManager.GetManager().Movies.Remove(selectedMovie);
					MovieDatabaseManager.GetManager().UserDAO.CurrentUser.MovieList.Remove(selectedMovie);
					listBoxMovies.SelectedItem = null;
					updateMovies();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Unable to delete movie " + selectedMovie);
				}
			}
		}

		private void checkBoxAddToList_CheckedChanged(object sender, EventArgs e)
		{
			bool oldCheckboxState = !checkBoxAddToList.Checked;
			if (selectedMovie == null) return;
			User? user = MovieDatabaseManager.GetManager().UserDAO.CurrentUser;
			if (user == null)
			{
				MessageBox.Show("Invalid state: user not logged in!", "Error");
				Application.Exit();
			}
			bool containsMovie = user.MovieList.Contains(selectedMovie);
			if ((checkBoxAddToList.Checked && containsMovie) || (!checkBoxAddToList.Checked && !containsMovie))
			{
				return;
			}
			if (checkBoxAddToList.Checked) user.MovieList.AddLast(selectedMovie);
			else user.MovieList.Remove(selectedMovie);
			try
			{
				MovieDatabaseManager.GetManager().UserDAO.Upload(user);
			}
			catch (Exception ex)
			{
				if (oldCheckboxState) { user.MovieList.AddLast(selectedMovie); }
				else user.MovieList.RemoveLast();
				selectedMovie = null;
				checkBoxAddToList.Checked = oldCheckboxState;
				MessageBox.Show(ex.Message, "Unable to modify movie list");
			}
		}

		private void checkBoxList_CheckedChanged(object sender, EventArgs e)
		{
			buttonSearch.Enabled = !checkBoxList.Checked;
			listBoxMovies.Items.Clear();
			IEnumerable<Movie> movies;
			movies = checkBoxList.Checked ? MovieDatabaseManager.GetManager().UserDAO.CurrentUser.MovieList : MovieDatabaseManager.GetManager().Movies;
			foreach (Movie movie in movies)
			{
				listBoxMovies.Items.Add(movie);
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (selectedMovie == null) return;
			try
			{
				Movie movie = new Movie(textBoxName.Text, textBoxDesc.Text, new DateOnly(dateTimePickerRD.Value.Year, dateTimePickerRD.Value.Month, dateTimePickerRD.Value.Day), trackBarRating.Value / 10.0f);
				foreach (Genre genre in listBoxGenres.Items)
				{
					movie.Genres.AddLast(genre);
				}
				foreach (Actor actor in listBoxActors.Items)
				{
					movie.Actors.AddLast(actor);
				}
				movie.ID = selectedMovie.ID;
				new MovieDAO().Upload(movie);
				selectedMovie.Name = movie.Name;
				selectedMovie.Description = movie.Description;
				selectedMovie.ReleaseDate = movie.ReleaseDate;
				selectedMovie.Rating = movie.Rating;

				selectedMovie.Genres.Clear();
				foreach (Genre genre in movie.Genres)
				{
					selectedMovie.Genres.AddLast(genre);
				}
				selectedMovie.Actors.Clear();
				foreach (Actor actor in movie.Actors)
				{
					selectedMovie.Actors.AddLast(actor);
				}
				buttonSave.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to save changes");
			}

		}

		private void buttonGenre_Click(object sender, EventArgs e)
		{
			string genreName = Interaction.InputBox("Enter genre name", "Add genre");
			if (genreName == null || genreName == "") return;
			Genre genre = new Genre(genreName);
			if (!listBoxGenres.Items.Contains(genre)) listBoxGenres.Items.Add(genre);
			buttonSave.Enabled = true;
		}

		private void buttonRemoveGenre_Click(object sender, EventArgs e)
		{
			if (listBoxGenres.SelectedItem != null) listBoxGenres.Items.Remove(listBoxGenres.SelectedItem);
			buttonSave.Enabled = true;
		}

		private void buttonActor_Click(object sender, EventArgs e)
		{
			string actorName = Interaction.InputBox("Enter actor name", "Add actor");
			if (actorName == null || actorName == "") return;
			string[] actorNameArray = actorName.Split(" ");
			if (actorNameArray.Length != 2)
			{
				MessageBox.Show("Actor name must contain a name and a surname!", "Unable to add actor");
				return;
			}
			Actor actor = new Actor(actorNameArray[0], actorNameArray[1]);
			if (!listBoxActors.Items.Contains(actor)) listBoxActors.Items.Add(actor);
			buttonSave.Enabled = true;
		}

		private void buttonRemoveActor_Click(object sender, EventArgs e)
		{
			if (listBoxActors.SelectedItem != null) listBoxActors.Items.Remove(listBoxActors.SelectedItem);
			buttonSave.Enabled = true;
		}

		private void listBoxGenres_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonRemoveGenre.Enabled = listBoxGenres.SelectedItem != null;
		}

		private void listBoxActors_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonRemoveActor.Enabled = listBoxActors.SelectedItem != null;
		}

		private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				configFile.AppSettings.Settings["Username"].Value = "";
				configFile.AppSettings.Settings["User_Password"].Value = "";
				configFile.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
				Application.Restart();
				Environment.Exit(0);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to remove saved credentials");
			}
		}

		private void importJSONToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "JavaScript Object Notation file (*.json)|*.json|All files(*.*)|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string jsonString = File.ReadAllText(openFileDialog.FileName);

				IEnumerable<Movie>? movies;
				try
				{
					movies = JsonSerializer.Deserialize<IEnumerable<Movie>>(jsonString);
					if (movies != null)
					{
						MovieDAO movieDAO = new MovieDAO();
						foreach (Movie movie in movies)
						{
							movieDAO.Upload(movie);
						}
					}
					MessageBox.Show("Successfully imported JSON file\n" + openFileDialog.FileName, "Import JSON");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Unable to import JSON file");
				}
			}
		}

		private void exportJSONToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IEnumerable<Movie> movies;
			try
			{
				movies = new MovieDAO().GetAll();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to export movies");
				return;
			}
			string jsonString = JsonSerializer.Serialize(movies, new JsonSerializerOptions
			{
				WriteIndented = true
			});
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "JavaScript Object Notation file (*.json)|*.json";
			saveFileDialog.AddExtension = true;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName);
					outputFile.Write(jsonString);
					outputFile.Close();
					MessageBox.Show("Successfully exported JSON file to:\n" + saveFileDialog.FileName, "Export JSON");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Unable to save file to path");
				}
			}
		}
	}
}
