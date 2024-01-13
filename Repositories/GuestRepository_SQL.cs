
using Microsoft.Data.Sqlite;
using ivanStojk_CRUD_API.Models;


namespace ivanStojk_CRUD_API.Repositories
{
    public class GuestRepository_SQL : IGuestRepository
    {
        private readonly string _connectionString = "Data Source=C:\\Users\\Ivan\\Desktop\\DISlabovi\\ivanStojk-hw-03\\ivanStojk-hw-03\\SQL\\database.db";
        //private readonly string _dbDatetimeFormat = "yyyy-MM-dd hh:mm:ss.fff";

        public bool CreateNewGuest(Guest guest)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO Guest (HotelId, FirstName, LastName, RoomNumber)
                VALUES ($hotelID, $firstname, $lastname, $roomnumber,)";

            command.Parameters.AddWithValue("$hotelID", guest.HotelId);
            command.Parameters.AddWithValue("$firstnamw", guest.FirstName);
            command.Parameters.AddWithValue("$lastname", guest.LastName);
            command.Parameters.AddWithValue("$roomnumber", guest.RoomNumber);
            // probaj dodat command.Parameters.AddWithValue("$timestamp", guest.Timestamp.ToString(_dbDatetimeFormat));

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException("Could not insert guest into database.");
                return false;
            }
            else return true;
        }

        public bool DeleteGuest(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    DELETE FROM Guest
                    WHERE ID == id";
            command.Parameters.AddWithValue("$id", id);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected < 1)
            {
                return false;

                throw new ArgumentException($"No guests with ID = {id}.");

            }
            else return true;
        }



        public List<Guest> GetAllGuest()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, HotelId, FirstName, LastName, RoomNumber FROM Guest";

            using var reader = command.ExecuteReader();

            var results = new List<Guest>();
            while (reader.Read())
            {

                var row = new Guest
                {
                    ID = reader.GetInt32(0),
                    HotelId = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    LastName = reader.GetString(3),
                    RoomNumber = reader.GetInt32(4),
                    //Timestamp = DateTime.ParseExact(reader.GetString(5), _dbDatetimeFormat, null)
                };

                results.Add(row);
            }

            return results;

        }

        public Guest? GetSingleGuest(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, HotelId, FirstName, LastName, RoomNumber FROM Guest WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            Guest result = null;

            if (reader.Read())
            {
                result = new Guest
                {
                    ID = reader.GetInt32(0),
                    HotelId = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    LastName = reader.GetString(3),
                    RoomNumber = reader.GetInt32(4),
                    //Timestamp = DateTime.ParseExact(reader.GetString(5), _dbDatetimeFormat, null)
                };

            }

            return result;
        }

        public Guest? GetGuestByRoomNumber(int roomnumber)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, HotelId, FirstName, LastName, RoomNumber FROM Guest WHERE RoomNumber == $roomnumber";

            command.Parameters.AddWithValue("$roomnumber", roomnumber);

            using var reader = command.ExecuteReader();

            Guest result = null;

            if (reader.Read())
            {
                result = new Guest
                {
                    ID = reader.GetInt32(0),
                    HotelId = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    LastName = reader.GetString(3),
                    RoomNumber = reader.GetInt32(4),
                    //Timestamp = DateTime.ParseExact(reader.GetString(5), _dbDatetimeFormat, null)
                };
            }

            return result;
        }

        public bool UpdateGuest(int id, Guest updatedGuest)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                UPDATE Guest
                SET
                    HotelId = $hotelid,
                    FirstName = $firstname,
                    LastName = $lastname,
                    RoomNumber = $roomnumber
                WHERE
                    ID == $id";

            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$hotelid", updatedGuest.HotelId);
            command.Parameters.AddWithValue("$firstname", updatedGuest.FirstName);
            command.Parameters.AddWithValue("$lastname", updatedGuest.LastName);
            command.Parameters.AddWithValue("$roomnumber", updatedGuest.RoomNumber);
            //command.Parameters.AddWithValue("$timestamp", updatedGuest.Timestamp.ToString(_dbDatetimeFormat));

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                return false;
                throw new ArgumentException($"Could not update email with ID = {id}.");
            }
            else return true;
        }
    }
}


    

