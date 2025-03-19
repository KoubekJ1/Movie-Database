using Microsoft.Data.SqlClient;

namespace MovieDatabase
{
	/// <summary>
	/// UserDAO instances serve as objects used for retrieving, creating, modifying and deleting user instances from the database.
	/// UserDAO instances also contain one user that is currently logged in. Logging in can be performed by either using the login method or by uploading a new user.
	/// Most methods require the given user to be logged in to prevent users manipulating other users' accounts without having their login credentials.
	/// </summary>
	public class UserDAO : IDAO<User>
	{
		private User? currentUser;

		/// <summary>
		/// Cleares all entries in the user movie list intersect table.
		/// Requires the user to be logged in.
		/// </summary>
		/// <param name="id"></param>
		/// <exception cref="InvalidOperationException">If the user is not logged in</exception>
		private void clearMovieList(int id)
		{
			if (currentUser.ID != id) throw new InvalidOperationException("Invalid user ID: " + id + ". Current user ID: " + currentUser.ID);

			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("delete from list where id_user = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Creates an entry in the user movie list intersect table.
		/// Requires the user to be logged in.
		/// </summary>
		/// <param name="userID">User ID</param>
		/// <param name="movieID">Movie ID</param>
		/// <exception cref="InvalidOperationException">If the user is not logged in</exception>
		private void createMovieListConnection(int userID, int movieID)
		{
			if (currentUser.ID != userID) throw new InvalidOperationException("Invalid user ID: " + userID + ". Current user ID: " + currentUser.ID);

			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("insert into list (id_user, id_movie) values (@id_user, @id_movie)", connection);
			cmd.Parameters.AddWithValue("id_user", userID);
			cmd.Parameters.AddWithValue("id_movie", movieID);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Returns all movies in the user's movie list.
		/// Requires the user to be logged in.
		/// </summary>
		/// <param name="id">User ID</param>
		/// <returns>Movies in list</returns>
		/// <exception cref="InvalidOperationException">If the user is not logged in</exception>
		private IEnumerable<Movie> getMovieList(int id)
		{
			if (currentUser.ID != id) throw new InvalidOperationException("Invalid user ID: " + id + ". Current user ID: " + currentUser.ID);

			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select id_movie from list where id_user = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			SqlDataReader reader = cmd.ExecuteReader();
			LinkedList<int> movieIDs = new LinkedList<int>();

			while (reader.Read())
			{
				movieIDs.AddLast(reader.GetInt32(0));
			}
			connection.Close();

			LinkedList<Movie> movies = new LinkedList<Movie>();
			MovieDAO movieDAO = new MovieDAO();
			foreach (int movieID in movieIDs)
			{
				Movie? movie = movieDAO.GetByID(movieID);
				if (movie != null) movies.AddLast(movie);
			}

			return movies;
		}

		public User? CurrentUser { get => currentUser; }

		/// <summary>
		/// Retrieves a user from the database with the given login credentials and saves it in the CurrentUser property.
		/// If the login fails, this method returns false. Otherwise it returns true.
		/// </summary>
		/// <param name="username">Username</param>
		/// <param name="password">Password</param>
		/// <returns>If the login's been successful</returns>
		public bool Login(string username, string password)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from users where username = @username and password = @password", connection);
			cmd.Parameters.AddWithValue("username", username);
			cmd.Parameters.AddWithValue("password", password);
			SqlDataReader reader = cmd.ExecuteReader();

			User? obj = null;
			if (reader.Read())
			{
				string[] dateValues = Convert.ToString(reader[5]).Split(" ")[0].Split(".");
				DateOnly date = new DateOnly(Convert.ToInt32(dateValues[2]), Convert.ToInt32(dateValues[1]), Convert.ToInt32(dateValues[0]));
				obj = new User(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), date, reader.GetString(6), reader.GetString(7));
				obj.ID = reader.GetInt32(0);
			}

			connection.Close();
			currentUser = obj;

			if (obj != null)
			{
				foreach (Movie movie in getMovieList((int)obj.ID))
				{
					obj.MovieList.AddLast(movie);
				}
			}

			return CurrentUser is null;
		}

		/// <summary>
		/// Deletes the user from the database.
		/// Requires the user to be logged in.
		/// </summary>
		/// <param name="id"></param>
		/// <exception cref="InvalidOperationException">If the user is not logged in</exception>
		public void Delete(int id)
		{
			if (currentUser.ID != id) throw new InvalidOperationException("Invalid user ID: " + id + ". Current user ID: " + currentUser.ID);
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("delete from users where id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Throws an exception.
		/// This method cannot be called due to security reasons.
		/// </summary>
		/// <returns>Exception</returns>
		/// <exception cref="InvalidOperationException">Exception</exception>
		public IEnumerable<User> GetAll()
		{
			throw new InvalidOperationException("Unable to get all users!");
		}

		/// <summary>
		/// Throws an exception.
		/// This method cannot be called due to security reasons.
		/// </summary>
		/// <returns>Exception</returns>
		/// <exception cref="InvalidOperationException">Exception</exception>
		public User? GetByID(int id)
		{
			throw new InvalidOperationException("Unable to get user by ID!");
		}

		/// <summary>
		/// Uploads or modifies the user in the database.
		/// Creates entries in the user movie list intersect table for each movie in the user's movie list.
		/// </summary>
		/// <param name="obj">User</param>
		/// <exception cref="Exception">If the upload process fails</exception>
		public void Upload(User obj)
		{
			if (obj.ID != null) clearMovieList((int)obj.ID);

			SqlConnection connection = DatabaseConnection.GetConnection();

			connection.Open();
			SqlCommand cmd;

			if (obj.ID == null)
			{
				cmd = new SqlCommand("insert into users (username, password, first_name, last_name, date_of_birth, email, country) output inserted.id values (@username, @password, @first_name, @last_name, @date_of_birth, @email, @country)", connection);
				cmd.Parameters.AddWithValue("username", obj.Username);
				cmd.Parameters.AddWithValue("password", obj.Password);
				cmd.Parameters.AddWithValue("first_name", obj.Name);
				cmd.Parameters.AddWithValue("last_name", obj.Surname);
				cmd.Parameters.AddWithValue("date_of_birth", obj.DateOfBirth.ToString("yyyy-MM-dd"));
				cmd.Parameters.AddWithValue("email", obj.Email);
				cmd.Parameters.AddWithValue("country", obj.Country);
				obj.ID = (int?)cmd.ExecuteScalar();
				if (obj.ID == null)
				{
					throw new Exception("ID not assigned!");
				}
			}
			else
			{
				cmd = new SqlCommand("update users set username = @username, password = @password, first_name = @first_name, last_name = @last_name, date_of_birth = @date_of_birth, email = @email, country = @country", connection);
				cmd.Parameters.AddWithValue("username", obj.Username);
				cmd.Parameters.AddWithValue("password", obj.Password);
				cmd.Parameters.AddWithValue("first_name", obj.Name);
				cmd.Parameters.AddWithValue("last_name", obj.Surname);
				cmd.Parameters.AddWithValue("date_of_birth", obj.DateOfBirth.ToString("yyyy-MM-dd"));
				cmd.Parameters.AddWithValue("email", obj.Email);
				cmd.Parameters.AddWithValue("country", obj.Country);
				cmd.ExecuteNonQuery();
			}
			connection.Close();

			MovieDAO movieDAO = new MovieDAO();
			foreach (Movie movie in obj.MovieList)
			{
				createMovieListConnection((int)obj.ID, (int)movie.ID);
			}
			currentUser = obj;
		}
	}
}
