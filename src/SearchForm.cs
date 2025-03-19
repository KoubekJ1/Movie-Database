namespace MovieDatabase
{
	public partial class SearchForm : Form
	{
		public SearchForm()
		{
			InitializeComponent();
		}

		private void checkBoxName_CheckedChanged(object sender, EventArgs e)
		{
			textBoxName.Enabled = checkBoxName.Checked;
		}

		private void checkBoxRD_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePickerRD.Enabled = checkBoxRD.Checked;
		}

		private void trackBarRating_Scroll(object sender, EventArgs e)
		{
			labelRatingNumber.Text = Convert.ToString((double)trackBarRating.Value / 10);
		}

		private void checkBoxActor_CheckedChanged(object sender, EventArgs e)
		{
			textBoxActor.Enabled = checkBoxActor.Checked;
		}

		private void checkBoxGenre_CheckedChanged(object sender, EventArgs e)
		{
			textBoxGenre.Enabled = checkBoxGenre.Checked;
		}

		private void checkBoxRating_CheckedChanged(object sender, EventArgs e)
		{
			labelRatingNumber.Enabled = checkBoxRating.Checked;
			trackBarRating.Enabled = checkBoxRating.Checked;
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			MovieDAO dao = new MovieDAO();

			string? name = null, actor = null, genre = null;
			DateOnly? releaseDate = null;
			float? rating = null;

			if (checkBoxName.Checked) name = textBoxName.Text;
			if (checkBoxActor.Checked) actor = textBoxActor.Text;
			if (checkBoxGenre.Checked) genre = textBoxGenre.Text;
			if (checkBoxRD.Checked) releaseDate = new DateOnly(dateTimePickerRD.Value.Year, dateTimePickerRD.Value.Month, dateTimePickerRD.Value.Day);
			if (checkBoxRating.Checked) rating = (float?)(trackBarRating.Value / 10.0);

			MovieDatabaseManager.GetManager().Movies.Clear();
			IEnumerable<Movie> movies;
			try
			{
				movies = dao.Search(name, releaseDate, rating, actor, genre);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to search for movie");
				return;
			}
			foreach (Movie movie in movies)
			{
				MovieDatabaseManager.GetManager().Movies.Add(movie);
			}

			this.Close();
		}
	}
}
