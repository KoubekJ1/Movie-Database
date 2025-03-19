namespace MovieDatabase
{
	/// <summary>
	/// Instances of the user class represent users in the database
	/// </summary>
	public class User : DatabaseObject
	{
		private string username, password, name, surname, email, country;
		private DateOnly dateOfBirth;
		private LinkedList<Movie> movieList;

		public User(string username, string password, string name, string surname, DateOnly dateOfBirth, string email, string country)
		{
			Username = username;
			Password = password;
			Name = name;
			Surname = surname;
			Email = email;
			Country = country;
			DateOfBirth = dateOfBirth;
			movieList = new LinkedList<Movie>();
		}

		public string Username { get => username; set => username = value; }
		public string Password { get => password; set => password = value; }
		public string Name { get => name; set => name = value; }
		public string Surname { get => surname; set => surname = value; }
		public string Email { get => email; set => email = value; }
		public string Country { get => country; set => country = value; }
		public DateOnly DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
		public LinkedList<Movie> MovieList { get => movieList; }

		public override string? ToString()
		{
			return "User " + ID + " " + username + ", " + name + " " + surname;
		}
	}
}
