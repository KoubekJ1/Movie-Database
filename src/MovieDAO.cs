using Microsoft.Data.SqlClient;

namespace MovieDatabase
{

	/// <summary>
	/// MovieDAO instances serve as objects used for retrieving, creating, modifying and deleting Movie instances from the database
	/// </summary>
	public class MovieDAO : IDAO<Movie>
	{

		/// <summary>
		/// Deletes all entries from the intersect table connecting the movie with the given ID to its actors
		/// </summary>
		/// <param name="movieID">Movie ID</param>
		private void clearMovieActors(int movieID)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("delete from movie_actors where id_movie = @id", connection);
			cmd.Parameters.AddWithValue("id", movieID);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Deletes all entries from the intersect table connecting the movie with the given ID to its genres
		/// </summary>
		/// <param name="movieID">Movie ID</param>
		private void clearMovieGenres(int movieID)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("delete from movie_genres where id_movie = @id", connection);
			cmd.Parameters.AddWithValue("id", movieID);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Creates a new entry in the intersect table connecting the movie with the given ID to the actor with the given ID
		/// </summary>
		/// <param name="movie">Movie ID</param>
		/// <param name="actor">Actor ID</param>
		private void createMovieActorConnection(int movie, int actor)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("insert into movie_actors (id_movie, id_actor) values (@id_movie, @id_actor)", connection);
			cmd.Parameters.AddWithValue("id_movie", movie);
			cmd.Parameters.AddWithValue("id_actor", actor);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Creates a new entry in the intersect table connecting the movie with the given ID to the genre with the given ID
		/// </summary>
		/// <param name="movie">Movie ID</param>
		/// <param name="genre">Genre ID</param>
		private void createMovieGenreConnection(int movie, int genre)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("insert into movie_genres (id_movie, id_genre) values (@id_movie, @id_genre)", connection);
			cmd.Parameters.AddWithValue("id_movie", movie);
			cmd.Parameters.AddWithValue("id_genre", genre);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Returns all actors in the movie
		/// </summary>
		/// <param name="movie">Movie ID</param>
		/// <returns>All actors in the movie</returns>
		private IEnumerable<Actor> getMovieActors(int movie)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select id_actor from movie_actors where id_movie = @movie", connection);
			cmd.Parameters.AddWithValue("movie", movie);
			SqlDataReader reader = cmd.ExecuteReader();
			LinkedList<int> actorIDs = new LinkedList<int>();

			while (reader.Read())
			{
				actorIDs.AddLast(reader.GetInt32(0));
			}
			connection.Close();

			LinkedList<Actor> actors = new LinkedList<Actor>();
			ActorDAO actorDAO = new ActorDAO();
			foreach (int actorID in actorIDs)
			{
				Actor? actor = actorDAO.GetByID(actorID);
				if (actor != null) actors.AddLast(actor);
			}

			return actors;
		}

		/// <summary>
		/// Returns all genres in the movie
		/// </summary>
		/// <param name="movie">Movie ID</param>
		/// <returns>All genres in the movie</returns>
		private IEnumerable<Genre> getMovieGenres(int movie)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select id_genre from movie_genres where id_movie = @movie", connection);
			cmd.Parameters.AddWithValue("movie", movie);
			SqlDataReader reader = cmd.ExecuteReader();
			LinkedList<int> genreIDs = new LinkedList<int>();

			while (reader.Read())
			{
				genreIDs.AddLast(reader.GetInt32(0));
			}
			connection.Close();

			LinkedList<Genre> genres = new LinkedList<Genre>();
			GenreDAO genreDAO = new GenreDAO();
			foreach (int genreID in genreIDs)
			{
				Genre? genre = genreDAO.GetByID(genreID);
				if (genre != null) genres.AddLast(genre);
			}
			return genres;
		}

		/// <summary>
		/// Deletes a movie from the database
		/// </summary>
		/// <param name="id">Movie ID</param>
		public void Delete(int id)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("delete from movies where id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Returns all movies in the database
		/// </summary>
		/// <returns>All movies</returns>
		public IEnumerable<Movie> GetAll()
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from movies", connection);
			SqlDataReader reader = cmd.ExecuteReader();

			LinkedList<Movie> movies = new LinkedList<Movie>();
			while (reader.Read())
			{
				string[] dateValues = Convert.ToString(reader[3]).Split(" ")[0].Split(".");
				DateOnly date = new DateOnly(Convert.ToInt32(dateValues[2]), Convert.ToInt32(dateValues[1]), Convert.ToInt32(dateValues[0]));
				Movie obj = new Movie(reader.GetString(1), reader.GetString(2), date, (float)reader.GetDouble(4));
				obj.ID = reader.GetInt32(0);
				movies.AddLast(obj);
			}
			connection.Close();
			foreach (Movie obj in movies)
			{
				foreach (Actor ac in getMovieActors((int)obj.ID)) obj.Actors.AddLast(ac);
				foreach (Genre ge in getMovieGenres((int)obj.ID)) obj.Genres.AddLast(ge);
			}

			return movies;
		}

		/// <summary>
		/// Returns a movie with the given ID from the database
		/// </summary>
		/// <param name="id">Movie ID</param>
		/// <returns>Movie</returns>
		public Movie? GetByID(int id)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from movies where id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			SqlDataReader reader = cmd.ExecuteReader();

			Movie? obj = null;
			if (reader.Read())
			{
				string[] dateValues = Convert.ToString(reader[3]).Split(" ")[0].Split(".");
				DateOnly date = new DateOnly(Convert.ToInt32(dateValues[2]), Convert.ToInt32(dateValues[1]), Convert.ToInt32(dateValues[0]));
				obj = new Movie(reader.GetString(1), reader.GetString(2), date, (float)reader.GetDouble(4));
				obj.ID = reader.GetInt32(0);
			}

			connection.Close();

			if (obj != null)
			{
				foreach (Actor actor in getMovieActors((int)obj.ID)) obj.Actors.AddLast(actor);
				foreach (Genre genre in getMovieGenres((int)obj.ID)) obj.Genres.AddLast(genre);
			}

			return obj;
		}

		/// <summary>
		/// Returns all movies from the database that match the given paramaters
		/// The paramaters that are null are not compared
		/// </summary>
		/// <param name="name">Movie name</param>
		/// <param name="releaseDate">Release date</param>
		/// <param name="rating">Rating</param>
		/// <param name="actor">Actor</param>
		/// <param name="genre">Genre</param>
		/// <returns></returns>
		public IEnumerable<Movie> Search(string? name, DateOnly? releaseDate, float? rating, string? actor, string? genre)
		{
			if (name is null && releaseDate is null && rating is null && actor is null && genre is null) return GetAll();
			LinkedList<Movie> movies = new LinkedList<Movie>();
			SqlConnection connection = DatabaseConnection.GetConnection();

			SqlCommand cmd = new SqlCommand();
			string cmdString = "select m.id, movie_name, movie_description, release_date, rating from movies m ";
			bool addAnd = false;

			if (actor is not null)
			{
				ActorDAO actorDAO = new ActorDAO();
				string[] actorNameArray = actor.Split(' ');
				Actor? requestedActor = actorDAO.GetByName(actorNameArray[0], actorNameArray[1]);
				if (requestedActor is null) return movies;
				cmdString += "inner join movie_actors a on m.id = a.id_movie and a.id_actor = @id_actor ";
				cmd.Parameters.AddWithValue("id_actor", requestedActor.ID);
			}
			if (genre is not null)
			{
				GenreDAO genreDAO = new GenreDAO();
				Genre? requestedGenre = genreDAO.GetByName(genre);
				if (requestedGenre is null) return movies;
				cmdString += "inner join movie_genres g on m.id = g.id_movie and g.id_genre = @id_genre ";
				cmd.Parameters.AddWithValue("id_genre", requestedGenre.ID);
			}
			if (name is not null)
			{
				if (!addAnd) cmdString += "where ";
				cmdString += "movie_name = @name ";
				cmd.Parameters.AddWithValue("name", name);
				addAnd = true;
			}
			if (releaseDate is not null)
			{
				if (addAnd) { cmdString += "and "; }
				else cmdString += "where ";
				cmdString += "release_date = @rd ";
				cmd.Parameters.AddWithValue("rd", ((DateOnly)releaseDate).ToString("yyyy-MM-dd"));
				addAnd = true;
			}
			if (rating is not null)
			{
				if (addAnd) { cmdString += "and "; }
				else cmdString += "where ";
				cmdString += "rating = @rating ";
				cmd.Parameters.AddWithValue("rating", rating);
				addAnd = true;
			}

			cmd.CommandText = cmdString;
			connection.Open();
			cmd.Connection = connection;
			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				string[] dateValues = Convert.ToString(reader[3]).Split(" ")[0].Split(".");
				DateOnly date = new DateOnly(Convert.ToInt32(dateValues[2]), Convert.ToInt32(dateValues[1]), Convert.ToInt32(dateValues[0]));
				Movie obj = new Movie(reader.GetString(1), reader.GetString(2), date, (float)reader.GetDouble(4));
				obj.ID = reader.GetInt32(0);
				movies.AddLast(obj);
			}
			connection.Close();
			foreach (Movie obj in movies)
			{
				foreach (Actor ac in getMovieActors((int)obj.ID)) obj.Actors.AddLast(ac);
				foreach (Genre ge in getMovieGenres((int)obj.ID)) obj.Genres.AddLast(ge);
			}
			return movies;
		}

		/// <summary>
		/// Uploads or modifies a movie in the database
		/// If the actors and genres are not in the database, they get uploaded as well. If they only lack IDs, they get assigned their IDs from the database
		/// </summary>
		/// <param name="obj">Movie</param>
		/// <exception cref="Exception">If the upload process fails</exception>
		public void Upload(Movie obj)
		{
			if (obj.ID != null)
			{
				clearMovieActors((int)obj.ID);
				clearMovieGenres((int)obj.ID);
			}

			SqlConnection connection = DatabaseConnection.GetConnection();

			connection.Open();
			SqlCommand cmd;

			if (obj.ID == null)
			{
				cmd = new SqlCommand("insert into movies (movie_name, movie_description, release_date, rating) output inserted.id values (@name, @desc, @date, @rating)", connection);
				cmd.Parameters.AddWithValue("name", obj.Name);
				cmd.Parameters.AddWithValue("desc", obj.Description);
				cmd.Parameters.AddWithValue("date", obj.ReleaseDate.ToString("yyyy-MM-dd"));
				cmd.Parameters.AddWithValue("rating", obj.Rating);
				obj.ID = (int?)cmd.ExecuteScalar();
				if (obj.ID == null)
				{
					throw new Exception("ID not assigned!");
				}
			}
			else
			{
				cmd = new SqlCommand("update movies set movie_name = @name, movie_description = @desc, release_date = @date, rating = @rating where id = @id", connection);
				cmd.Parameters.AddWithValue("id", obj.ID);
				cmd.Parameters.AddWithValue("name", obj.Name);
				cmd.Parameters.AddWithValue("desc", obj.Description);
				cmd.Parameters.AddWithValue("date", obj.ReleaseDate.ToString("yyyy-MM-dd"));
				cmd.Parameters.AddWithValue("rating", obj.Rating);
				cmd.ExecuteNonQuery();
			}
			connection.Close();

			GenreDAO genreDAO = new GenreDAO();
			ActorDAO actorDAO = new ActorDAO();
			foreach (Genre genre in obj.Genres)
			{
				genreDAO.Upload(genre);
				createMovieGenreConnection((int)obj.ID, (int)genre.ID);
			}
			foreach (Actor actor in obj.Actors)
			{
				actorDAO.Upload(actor);
				createMovieActorConnection((int)obj.ID, (int)actor.ID);
			}
		}
	}
}
