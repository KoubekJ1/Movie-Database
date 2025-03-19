using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDatabase
{
	/// <summary>
	/// The form used to create new movies
	/// </summary>
	public partial class NewMovieForm : Form
	{
		public NewMovieForm()
		{
			InitializeComponent();
			dateTimePickerRD.MaxDate = DateTime.Now;
		}

		private void trackBarRating_Scroll(object sender, EventArgs e)
		{
			labelRatingNumber.Text = Convert.ToString(trackBarRating.Value / 10.0);
		}

		private void listBoxGenres_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonRemoveGenre.Enabled = listBoxGenres.SelectedItem != null;
		}

		private void buttonGenre_Click(object sender, EventArgs e)
		{
			string genreName = Interaction.InputBox("Enter genre name", "Add genre");
			if (genreName == null || genreName == "") return;
			Genre genre = new Genre(genreName);
			if (!listBoxGenres.Items.Contains(genre)) listBoxGenres.Items.Add(genre);
		}

		private void buttonRemoveGenre_Click(object sender, EventArgs e)
		{
			if (listBoxGenres.SelectedItem != null) listBoxGenres.Items.Remove(listBoxGenres.SelectedItem);
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
		}

		private void buttonRemoveActor_Click(object sender, EventArgs e)
		{
			if (listBoxActors.SelectedItem != null) listBoxActors.Items.Remove(listBoxActors.SelectedItem);
		}

		private void listBoxActors_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonRemoveActor.Enabled = listBoxActors.SelectedItem != null;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Movie movie = new Movie(textBoxName.Text, textBoxDesc.Text, new DateOnly(dateTimePickerRD.Value.Year, dateTimePickerRD.Value.Month, dateTimePickerRD.Value.Day), trackBarRating.Value/10.0f);
			foreach (var actor in listBoxActors.Items)
			{
				movie.Actors.AddLast((Actor)actor);
			}
			foreach (var genre in listBoxGenres.Items)
			{
				movie.Genres.AddLast((Genre)genre);
			}
			MovieDAO dao = new MovieDAO();
			try
			{
				dao.Upload(movie);
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to create new movie!");
			}
		}
	}
}
