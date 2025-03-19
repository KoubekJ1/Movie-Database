using System.Text.Json.Serialization;

namespace MovieDatabase
{
	/// <summary>
	/// Instances of the Genre class represent genres in the database
	/// </summary>
	public class Genre : DatabaseObject
	{
		[JsonInclude]
		private string name;

		[JsonConstructor]
		private Genre()
		{
		}

		public Genre(string name)
		{
			this.Name = name;
		}

		[JsonIgnore]
		public string Name { get => name; set => name = value; }

		public override string? ToString()
		{
			return name;
		}

		public override bool Equals(object? obj)
		{
			if (obj == null) return false;
			if (obj.GetType() != typeof(Genre)) return false;
			return ((Genre)obj).Name == this.Name;
		}
	}
}
