namespace MovieDatabase
{

	/// <summary>
	/// Movie database manager is a class utilizing the singleton design pattern that contains a UserDAO instance and the current list of movies
	/// </summary>
	public class MovieDatabaseManager
	{
		private static MovieDatabaseManager manager;

		/// <summary>
		/// Returns the static MovieDatabaseManager instance
		/// The instance is constructed if it hasn't been constructed already
		/// </summary>
		/// <returns>Static MovieDatabaseManager instance</returns>
		public static MovieDatabaseManager GetManager()
		{
			if (manager == null) manager = new MovieDatabaseManager();
			return manager;
		}

		private UserDAO userDAO;
		private List<Movie> movies;

		private MovieDatabaseManager()
		{
			userDAO = new UserDAO();
			movies = new List<Movie>();
		}


		public UserDAO UserDAO { get => userDAO; }
		public List<Movie> Movies { get => movies; }
	}
}
