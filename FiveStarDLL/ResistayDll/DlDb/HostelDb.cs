using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HostelDll.Bl;
namespace HostelDll.DlDb
{
    public class HostelDb 
    {
        private static string query;

        public static bool InsertHostel(Hostel hostel, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string query = string.Format("INSERT INTO Hostel (HostelName, HostelType, HostelStatus) VALUES ('{0}', '{1}', '{2}')",
                                            hostel.GetHostelName(), hostel.GetHostelType(), hostel.GetHostelStatus());

            SqlCommand command = new SqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool DeleteHostelByHostelName(string hostelName, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int rowsAffected = 0;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            string query = string.Format("DELETE FROM Hostel WHERE HostelName = '{0}'", hostelName);
            SqlCommand command = new SqlCommand(query, connection);
            rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected > 0;
        }
        public static  List<Hostel> GetAllHostels(string connectionString)
        {
            List<Hostel> hostels = new List<Hostel>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "SELECT * FROM Hostel";

            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string hostelName = reader.GetString(reader.GetOrdinal("HostelName"));
                    string hostelType = reader.GetString(reader.GetOrdinal("HostelType"));
                    string hostelStatus = reader.GetString(reader.GetOrdinal("HostelStatus"));

                    Hostel hostel = new Hostel(hostelName, hostelType, hostelStatus);
                    hostels.Add(hostel);
                }
            }



            return hostels;
        }

        public static List<string> GetHostelNames(string connectionString)
        {
            List<string> Hostels = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = ""; 

            query = "SELECT HostelName FROM Hostel ";



            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string hostel = Convert.ToString(reader["HostelName"]);
                Hostels.Add(hostel);
            }

            reader.Close();
            connection.Close();

            return Hostels;
        }

        public static List<string> GetHostelNamesByGender(string gender, string connectionString)
        {
            List<string> AvailableHostels = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = ""; // Declare the query variable here

            if (gender == "male")
            {
                query = "SELECT HostelName FROM Hostel where HostelType = 'boys'";
            }
            else
            {
                query = "SELECT HostelName FROM Hostel where HostelType = 'girls'";
            }

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string hostel = Convert.ToString(reader["HostelName"]);
                AvailableHostels.Add(hostel);
            }

            reader.Close();
            connection.Close();

            return AvailableHostels;
        }
        public static Hostel GetHostelByName(string hostelName, string connectionString)
        {
            Hostel hostel = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = string.Format("SELECT * FROM Hostel WHERE HostelName = '{0}'", hostelName);
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string name = Convert.ToString(reader["HostelName"]);
                string type = Convert.ToString(reader["HostelType"]);
                string status = Convert.ToString(reader["HostelStatus"]);
               

                hostel = new Hostel(name, type, status);
            }

            reader.Close();
            connection.Close();

            return hostel;
        }
        public static List<string> GetHostelBySelecteddltRoom(int room, string connectionString)
        {
            List<string> Hostels = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = ""; // Declare the query variable here

            query = string.Format("SELECT HostelName FROM Room where RoomNumber = '{0}' ", room);



            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string hostel = Convert.ToString(reader["HostelName"]);
                Hostels.Add(hostel);
            }

            reader.Close();
            connection.Close();

            return Hostels;

        }

        public static bool IsDuplicateHostel(string hostelName, string connectionString)
        {
            string hostel = null;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = string.Format("SELECT HostelName FROM Hostel WHERE HostelName = '{0}'", hostelName);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                hostel = reader.GetString(0);
            }
            reader.Close();
            connection.Close();

            return hostel == null;
        }

        public static bool UpdateHostelStatusUnchecked(string hostelName, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("UPDATE Hostel SET HostelStatus = 'Unchecked' WHERE HostelName = '{0}'", hostelName);
            SqlCommand command = new SqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected > 0;
        }
        public static bool UpdateHostelStatusChecked(string hostelName, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("UPDATE Hostel SET HostelStatus = 'Checked' WHERE HostelName = '{0}'", hostelName);
            SqlCommand command = new SqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected > 0;
        }
    }
}
