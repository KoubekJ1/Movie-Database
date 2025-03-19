using Microsoft.Data.SqlClient;

namespace MovieDatabase
{
	/// <summary>
	/// ActorDAO instances serve as objects used for retrieving, creating, modifying and deleting genre instances from the database
	/// </summary>
	public class GenreDAO : IDAO<Genre>
	{
		/// <summary>
		/// Deletes a genre from the database
		/// </summary>
		/// <param name="id">Genre ID</param>
		public void Delete(int id)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("delete from genres where id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Retrieves all genres from the database
		/// </summary>
		/// <returns>All genres</returns>
		public IEnumerable<Genre> GetAll()
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from genres", connection);
			SqlDataReader reader = cmd.ExecuteReader();

			LinkedList<Genre> genres = new LinkedList<Genre>();
			while (reader.Read())
			{
				Genre obj = new Genre(reader.GetString(1));
				obj.ID = reader.GetInt32(0);
				genres.AddLast(obj);
			}

			connection.Close();
			return genres;
		}

		/// <summary>
		/// Returns a genre from the database with the matching ID
		/// </summary>
		/// <param name="id">Genre ID</param>
		/// <returns>Genre</returns>
		public Genre? GetByID(int id)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from genres where id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			SqlDataReader reader = cmd.ExecuteReader();

			Genre? obj = null;
			if (reader.Read())
			{
				obj = new Genre(reader.GetString(1));
				obj.ID = reader.GetInt32(0);
			}

			connection.Close();
			return obj;
		}

		/// <summary>
		/// Returns a genre from the database with the matching name
		/// </summary>
		/// <param name="name">Genre name</param>
		/// <returns>Genre</returns>
		public Genre? GetByName(string name)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from genres where genre_name = @name", connection);
			cmd.Parameters.AddWithValue("name", name);
			SqlDataReader reader = cmd.ExecuteReader();

			Genre? obj = null;
			if (reader.Read())
			{
				obj = new Genre(reader.GetString(1));
				obj.ID = reader.GetInt32(0);
			}

			connection.Close();
			return obj;
		}

		/// <summary>
		/// Uploads or modifies a genre
		/// If the genre matches a genre that is already present in the database, it gets assigned the same ID
		/// </summary>
		/// <param name="obj"></param>
		/// <exception cref="Exception"></exception>
		public void Upload(Genre obj)
		{
			// In case the genre name matches an already existing genre, the ID gets assigned
			if (obj.ID == null)
			{
				Genre? existingGenre = GetByName(obj.Name);
				if (existingGenre != null)
				{
					obj.ID = existingGenre.ID;
				}
			}
			else // In case the genre name is changed to an already existing genre, the ID is changed
			{
				Genre? existingGenre = GetByName(obj.Name);
				if (existingGenre != null)
				{
					obj.ID = existingGenre.ID;
				}
			}

			SqlConnection connection = DatabaseConnection.GetConnection();

			connection.Open();
			SqlCommand cmd;

			if (obj.ID == null)
			{
				cmd = new SqlCommand("insert into genres (genre_name) output inserted.id values (@name)", connection);
				cmd.Parameters.AddWithValue("name", obj.Name);
				obj.ID = (int?)cmd.ExecuteScalar();
				if (obj.ID == null)
				{
					throw new Exception("ID not assigned!");
				}
			}
			else
			{
				cmd = new SqlCommand("update genres set genre_name = @name where id = @id", connection);
				cmd.Parameters.AddWithValue("id", obj.ID);
				cmd.Parameters.AddWithValue("name", obj.Name);
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}
	}
}
