using Microsoft.Data.SqlClient;

namespace MovieDatabase
{
	/// <summary>
	/// ActorDAO instances serve as objects used for retrieving, creating, modifying and deleting actor instances from the database
	/// </summary>
	public class ActorDAO : IDAO<Actor>
	{
		/// <summary>
		/// Deletes an actor from the database
		/// </summary>
		/// <param name="id">Actor ID</param>
		public void Delete(int id)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("delete from actors where id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			cmd.ExecuteNonQuery();

			connection.Close();
		}

		/// <summary>
		/// Returns all actors in the database
		/// </summary>
		/// <returns>All actors</returns>
		public IEnumerable<Actor> GetAll()
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from actors", connection);
			SqlDataReader reader = cmd.ExecuteReader();

			LinkedList<Actor> actors = new LinkedList<Actor>();
			while (reader.Read())
			{
				Actor obj = new Actor(reader.GetString(1), reader.GetString(2));
				obj.ID = reader.GetInt32(0);
				actors.AddLast(obj);
			}

			connection.Close();
			return actors;
		}

		/// <summary>
		/// Retrieves an actor based on an ID
		/// </summary>
		/// <param name="id">Actor ID</param>
		/// <returns>Actor</returns>
		public Actor? GetByID(int id)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from actors where id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);
			SqlDataReader reader = cmd.ExecuteReader();

			Actor? obj = null;
			if (reader.Read())
			{
				obj = new Actor(reader.GetString(1), reader.GetString(2));
				obj.ID = reader.GetInt32(0);
			}

			connection.Close();
			return obj;
		}

		/// <summary>
		/// Retrieves an actor from the database based on its name and surname
		/// </summary>
		/// <param name="name">Actor name</param>
		/// <param name="surname">Actor surname</param>
		/// <returns></returns>
		public Actor? GetByName(string name, string surname)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("select * from actors where actor_name = @name and actor_surname = @surname", connection);
			cmd.Parameters.AddWithValue("name", name);
			cmd.Parameters.AddWithValue("surname", surname);
			SqlDataReader reader = cmd.ExecuteReader();

			Actor? obj = null;
			if (reader.Read())
			{
				obj = new Actor(reader.GetString(1), reader.GetString(2));
				obj.ID = reader.GetInt32(0);
			}

			connection.Close();
			return obj;
		}

		/// <summary>
		/// Uploads or modifies an actor
		/// If the actor matches an actor that is already present in the database, it gets assigned the same ID
		/// </summary>
		/// <param name="obj">Actor</param>
		/// <exception cref="Exception">If the upload process fails</exception>
		public void Upload(Actor obj)
		{
			// In case the actor name matches an already existing actor, the ID gets assigned
			if (obj.ID == null)
			{
				Actor? existingActor = GetByName(obj.Name, obj.Surname);
				if (existingActor != null)
				{
					obj.ID = existingActor.ID;
				}
			}
			else // In case the actor name is changed to an already existing actor, the ID is changed
			{
				Actor? existingActor = GetByName(obj.Name, obj.Surname);
				if (existingActor != null)
				{
					obj.ID = existingActor.ID;
				}
			}

			SqlConnection connection = DatabaseConnection.GetConnection();

			connection.Open();
			SqlCommand cmd;

			if (obj.ID == null)
			{
				cmd = new SqlCommand("insert into actors (actor_name, actor_surname) output inserted.id values (@name, @surname)", connection);
				cmd.Parameters.AddWithValue("name", obj.Name);
				cmd.Parameters.AddWithValue("surname", obj.Surname);
				obj.ID = (int?)cmd.ExecuteScalar();
				if (obj.ID == null)
				{
					throw new Exception("ID not assigned!");
				}
			}
			else
			{
				cmd = new SqlCommand("update actors set actor_name = @name, actor_surname = @surname where id = @id", connection);
				cmd.Parameters.AddWithValue("id", obj.ID);
				cmd.Parameters.AddWithValue("name", obj.Name);
				cmd.Parameters.AddWithValue("surname", obj.Surname);
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}
	}
}
