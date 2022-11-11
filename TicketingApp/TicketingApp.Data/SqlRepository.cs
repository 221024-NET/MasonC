using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml;
using System.Data.SqlClient;
using System;
using System.Net.Sockets;

using TicketingApp.Logic;


namespace TicketingApp.Data
{
    public class SqlRepository : IRepository
    {
        string ConnectionString;

        public SqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<Ticket> GetAllTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            using SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string cmdText = "SELECT * FROM TICKETS;";

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
                tickets.Add(new Ticket(userId, ticketId, amount, status, description));
            }

            return tickets;
        }

        public List<Ticket> GetAllTicketsFromUser(int userId)
        {
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
                tickets.Add(new Ticket(userId, ticketId, amount, status, description));
            }

            return tickets;
        }

        public Dictionary<string, User> GetAllUsers()
        {
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


            return users;
        }

        public User GetUser(string e)
        {
            User user = new User();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string cmdText = @"SELECT * FROM Users WHERE Email = @e;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@e", e);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // UserId   Email   Password
                int userId = reader.GetInt32(0);
                string email = reader.GetString(1);
                user = new User(userId, email, "False");
            }

            return user;
        }
    }
}
