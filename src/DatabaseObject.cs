using System.Text.Json.Serialization;

namespace MovieDatabase
{
	/// <summary>
	/// Instances of the database object class represent objects in the database.
	/// The instances of this class' subclasses have IDs that match their equivalent in the database.
	/// </summary>
	public abstract class DatabaseObject
	{
		[JsonIgnore]
		private int? id;

		[JsonIgnore]
		public int? ID { get => id; set => id = value; }
	}
}
