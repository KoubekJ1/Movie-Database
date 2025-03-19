using System.Text.Json.Serialization;

namespace MovieDatabase
{
	/// <summary>
	/// Movie instances represent movies inside the database
	/// </summary>
	public class Movie : DatabaseObject
	{
		[JsonInclude]
		private string name, description;
		[JsonInclude]
		private DateOnly releaseDate;
		[JsonInclude]
		private float rating;
		[JsonInclude]
		private LinkedList<Actor> actors;
		[JsonInclude]
		private LinkedList<Genre> genres;

		[JsonConstructor]
		private Movie()
		{
		}

		public Movie(string name, string description, DateOnly releaseDate, float rating)
		{
			Name = name;
			Description = description;
			ReleaseDate = releaseDate;
			Rating = rating;
			actors = new LinkedList<Actor>();
			genres = new LinkedList<Genre>();
		}

		[JsonIgnore]
		public string Name { get => name; set => name = value; }
		[JsonIgnore]
		public string Description { get => description; set => description = value; }
		[JsonIgnore]
		public DateOnly ReleaseDate { get => releaseDate; set => releaseDate = value; }
		[JsonIgnore]
		public float Rating { get => rating; set => rating = value; }
		[JsonIgnore]
		public LinkedList<Actor> Actors { get => actors; }
		[JsonIgnore]
		public LinkedList<Genre> Genres { get => genres; }

		public override string? ToString()
		{
			return name;
		}

		/// <summary>
		/// Checks if two movies match by comparing all of their properties
		/// </summary>
		/// <param name="obj">Another object</param>
		/// <returns>Whether the two objects match</returns>
		public override bool Equals(object? obj)
		{
			if (obj == null) return false;
			//if (obj.GetType() != typeof(Movie)) return false;
			if (obj.GetType() != typeof(Movie)) return false;
			Movie other = (Movie)obj;
			//return other.Name == this.Name && other.Description == this.Description && other.ReleaseDate == this.ReleaseDate && other.Rating == this.Rating && other.actors.All(s => this.actors.Contains(s)) && other.genres.All(s => this.genres.Contains(s));
			return other.Name == this.Name && other.Description == this.Description && other.ReleaseDate == this.ReleaseDate && other.Rating == this.Rating;
		}
	}
}
