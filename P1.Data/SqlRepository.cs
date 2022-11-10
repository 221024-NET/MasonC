using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml;
using P1.Logic;
using System.Data.SqlClient;
using System;


namespace P1.Data
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
            string cmdText = @"SELECT * FROM TICKETS WHERE UserId = @userId;";
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
    }
}
