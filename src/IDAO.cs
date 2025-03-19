namespace MovieDatabase
{
	/// <summary>
	/// Instances of IDAO subclasses are objects used for retrieving, creating, modifying and deleting entries from the database
	/// </summary>
	/// <typeparam name="T">Object class</typeparam>
	public interface IDAO<T> where T : DatabaseObject
	{
		/// <summary>
		/// Returns an entry with the matching ID
		/// </summary>
		/// <param name="id">Entry ID</param>
		/// <returns>Entry</returns>
		public T? GetByID(int id);

		/// <summary>
		/// Returns all entries of the given type from the database
		/// </summary>
		/// <returns>All entries</returns>
		public IEnumerable<T> GetAll();

		/// <summary>
		/// Uploads or modifies an object in the database
		/// </summary>
		/// <param name="obj">Object</param>
		public void Upload(T obj);

		/// <summary>
		/// Deletes the entry with the matching ID from the database
		/// </summary>
		/// <param name="id">Entry ID</param>
		public void Delete(int id);
	}
}
