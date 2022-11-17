using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml;
using System.Data.SqlClient;
using System;
using System.Net.Sockets;
using TicketingApp.Logic;
using System.Text;

namespace TicketingApp.Data
{
    public class SqlRepository : IRepository
    {
        string? ConnectionString = null;

        public SqlRepository() { }

        public List<Ticket> GetAllTickets(string connValue)
        {
            ConnectionString = connValue;
            var tickets = new List<Ticket>();
            StringBuilder qry = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                qry.Append(@"SELECT * FROM Tickets;");

                using SqlCommand cmd = new SqlCommand(qry.ToString(), connection);

                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // TicketId    Status   Amount   Description   UserId
                    int userId = Int32.Parse(reader["UserId"].ToString());
                    int ticketId = Int32.Parse(reader["TicketId"].ToString());
                    double amount = double.Parse(reader["Amount"].ToString());
                    string status = reader["Status"].ToString();
                    string description = reader["Description"].ToString();
                    if(status == null) status = "Empty";
                    if(description == null) description = "Empty";
                    Ticket tick = new Ticket(userId, ticketId, amount, status, description);
                    // Debug writeline
                    // Console.WriteLine(userId + " " + ticketId + " " + amount + " " + status + " " + description);
                    tickets.Add(tick);
                }
                reader.Close();
                cmd.Dispose();
                connection.Close();
            }
            return tickets;
        }

        public List<Ticket> GetAllTicketsPending(string connValue)
        {
            ConnectionString = connValue;
            List<Ticket> tickets = new List<Ticket>();
            Ticket tick;
            using SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string cmdText = "SELECT * FROM Tickets WHERE Status = 'Pending';";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // TicketId    Status   Amount   Description   UserId
                int userId = reader.GetInt32(4);
                int ticketId = reader.GetInt32(0);
                double amount = reader.GetDouble(2);
                string status = reader.GetString(1);
                string description = reader.GetString(3);
                tick = new Ticket(userId, ticketId, amount, status, description);
                tickets.Add(tick);
            }
            reader.Close();
            cmd.Dispose();
            connection.Close();
            return tickets;
        }

        public List<Ticket> GetAllTicketsFromUser(string connValue, int userId)
        {
            ConnectionString = connValue;  
            List<Ticket> tickets = new List<Ticket>();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string cmdText = @"SELECT * FROM Tickets WHERE UserId = @userId;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // TicketId    Status   Amount   Description   UserId
                int ticketId = reader.GetInt32(0);
                double amount = reader.GetDouble(2);
                string status = reader.GetString(1);
                string description = reader.GetString(3);
                int userID = reader.GetInt32(4);
                Ticket tick = new Ticket(userID, ticketId, amount, status, description);
                tickets.Add(tick);
            }
            reader.Close();
            cmd.Dispose();
            connection.Close();
            return tickets;
        }

        public Dictionary<string, User> GetAllUsers(string connValue)
        {
            ConnectionString = connValue;
            Dictionary<string, User> users = new Dictionary<string, User>();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string cmdText = @"SELECT * FROM Users;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // UserId   Email   Password
                int userId = reader.GetInt32(0);
                string email = reader.GetString(1);
                users.Add(email, new User(userId, email, "False"));
            }
            reader.Close();
            cmd.Dispose();
            connection.Close();

            return users;
        }

        public User GetUser(string connValue, int id)
        {
            ConnectionString = connValue;
            User user = new User();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string cmdText = @"SELECT * FROM Users WHERE UserId = @id;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // UserId   Email   Password
                int userId = reader.GetInt32(0);
                string email = reader.GetString(1);
                user = new User(userId, email, "False");
            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return user;
        }

        public User Login(string connValue, string e, string p)
        {
            ConnectionString = connValue;
            User user = new User();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string cmdText = @"SELECT * FROM Users WHERE Email = @e AND Password = @p;";

            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@p", p);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                user.id = reader.GetInt32(0);
                user.Email = reader.GetString(1);
                user.Password = reader.GetString(2);
                user.permLVL = reader.GetString(3);

            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return user;
        }

        public User Register(string connValue, string e, string p)
        {
            ConnectionString = connValue;
            string use = "User";
            User user;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string cmdText = @"INSERT INTO Users (Email, Password, Permission) VALUES(@e, @p, @use);";

            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@p", p);
            cmd.Parameters.AddWithValue("@use", use);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();

            user = Login(ConnectionString, e, p);

            return user;
        }

        public Ticket NewTicket(string connValue, int userId, double amount, string status, string des)
        {
            ConnectionString = connValue;
            int ticketId = 0;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string cmdText = @"INSERT INTO Tickets (Status, Amount, Description, UserId) VALUES(@status, @amount, @des, @userId);"
                            + "SELECT @@IDENTITY FROM Tickets;";

            
            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@des", des);
            cmd.Parameters.AddWithValue("@userId", userId);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ticketId = Int32.Parse(reader["TicketId"].ToString());
            }

            Ticket ticket = new Ticket(userId, ticketId, amount, status, des);

            connection.Close();
            cmd.Dispose();
            connection.Close();

            return ticket;
        }
    }
}
