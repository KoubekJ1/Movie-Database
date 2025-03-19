using System.Text.Json.Serialization;

namespace MovieDatabase
{
	/// <summary>
	/// Instances of the actor class represent an actor in the database
	/// </summary>
	public class Actor : DatabaseObject
	{
		[JsonInclude]
		private string name, surname;

		[JsonConstructor]
		private Actor()
		{
		}

		public Actor(string name, string surname)
		{
			Name = name;
			Surname = surname;
		}


		[JsonIgnore]
		public string Name { get => name; set => name = value; }
		[JsonIgnore]
		public string Surname { get => surname; set => surname = value; }

		public override string? ToString()
		{
			return name + " " + surname;
		}

		/// <summary>
		/// Compares two actors based on their names
		/// </summary>
		/// <param name="obj">Another object</param>
		/// <returns>Whether the 2 objects match</returns>
		public override bool Equals(object? obj)
		{
			if (obj == null) return false;
			if (obj.GetType() != typeof(Actor)) return false;
			return ((Actor)obj).Name == this.Name && ((Actor)obj).Surname == this.Surname;
		}
	}
}
