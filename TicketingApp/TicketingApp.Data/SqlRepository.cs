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
                    float amount = float.Parse(reader["Amount"].ToString());
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

        public List<User> GetAllUsers(string connValue)
        {
            ConnectionString = connValue;
            List<User> users = new List<User>();
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string cmdText = @"SELECT UserId, Email, Permission FROM Users;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // UserId   Email   Password
                int userId = Int32.Parse(reader["UserId"].ToString());
                string email = reader["Email"].ToString();
                string perm = reader["Permission"].ToString();
                users.Add(new User(perm, userId, email, "False"));
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

        public bool EmailALreadyUsed(string connValue, string e)
        {
            ConnectionString = connValue;
            List<string> list = new List<string>();
            User user = new User();
            bool contains = false;

            using SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string newE = "%" + e + "%";

            string cmdText = @"SELECT * FROM Users WHERE Email LIKE @e;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@e", newE);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                user.Email = reader.GetString(1);
                list.Add(user.Email);
            }

            if (list.Contains(e))
            {
                contains = true;
            }

            return contains;
        }

        public User Register(string connValue, string e, string p)
        {
            ConnectionString = connValue;
            string use = "User";
            User user;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            bool emailUsed = EmailALreadyUsed(connValue, e);

            if(!emailUsed)
            {
                string cmdText = @"INSERT INTO Users (Email, Password, Permission) VALUES(@e, @p, @use);";

                SqlCommand cmd = new SqlCommand(cmdText, connection);

                cmd.Parameters.AddWithValue("@e", e);
                cmd.Parameters.AddWithValue("@p", p);
                cmd.Parameters.AddWithValue("@use", use);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();

                user = Login(ConnectionString, e, p);
            }
            else
            {
                user = new User();
            }

            return user;
        }

        public Ticket NewTicket(string connValue, string status, double amount, string des, int userId)
        {
            ConnectionString = connValue;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            // Try to separate out the ints and doubles
            var cmdText = @"INSERT INTO Tickets (Status, Amount, Description, UserId) " +
                            "VALUES(@s, @a, @d, @u); SELECT @@IDENTITY FROM Tickets;";
            //@"SELECT IDENT_CURRENT('Tickets');";


            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@a", amount);
            cmd.Parameters.AddWithValue("@d", des);
            cmd.Parameters.AddWithValue("@u", userId);

            int id = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            cmd.Dispose();
            connection.Close();

            //Console.WriteLine("Inside NewTicket() method");

            //using (SqlConnection connection = new SqlConnection(connValue))
            //{
            //    StringBuilder qry = new StringBuilder();
            //    qry.Append("INSERT INTO Tickets");
            //    qry.Append(" (Status, Amount, Description, UserId)");
            //    qry.Append($" VALUES (");
            //    qry.Append($" '{t.status}',");
            //    qry.Append($" {t.amount},");
            //    qry.Append($" '{t.description}',");
            //    qry.Append($" {t.userId});");
            //    qry.Append($" SELECT @@IDENTITY;");
            //    Console.WriteLine(qry.ToString());

            //    SqlCommand cmd = new SqlCommand(qry.ToString(), connection);
            //    connection.Open();
            //    int newId = Convert.ToInt32(cmd.ExecuteScalar());
            //    t.ticketId = newId;
            //    cmd.Dispose();
            //}

            return new Ticket(userId, id, amount, status, des);
        }

        //Update user privaleges from User to Manager.

        //Update ticket so that status will be accepted or denied.

        public Ticket AccpetTicket(string conn, int id)
        {
            Ticket? tick = null;
            ConnectionString = conn;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string cmdText = @"UPDATE Tickets SET Status = 'Accepted' WHERE TicketId = @id;SELECT * FROM Tickets WHERE TicketId = @id;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // TicketId    Status   Amount   Description   UserId
                int ticketId = reader.GetInt32(0);
                double amount = reader.GetDouble(2);
                string status = reader.GetString(1);
                string description = reader.GetString(3);
                int userID = reader.GetInt32(4);
                tick = new Ticket(userID, ticketId, amount, status, description);
            }

            cmd.Dispose();
            connection.Close();

            return tick;
        }

        public Ticket DeclineTicket(string conn, int id)
        {
            Ticket? tick = null;
            ConnectionString = conn;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string cmdText = @"UPDATE Tickets SET Status = 'Declined' WHERE TicketId = @id;SELECT * FROM Tickets WHERE TicketId = @id;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // TicketId    Status   Amount   Description   UserId
                int ticketId = reader.GetInt32(0);
                double amount = reader.GetDouble(2);
                string status = reader.GetString(1);
                string description = reader.GetString(3);
                int userID = reader.GetInt32(4);
                tick = new Ticket(userID, ticketId, amount, status, description);
            }

            cmd.Dispose();
            connection.Close();

            return tick;
        }

        public void ChangeUserPermM(string conn, int id)
        {
            ConnectionString = conn;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string cmdText = @"UPDATE Users SET Permission = 'Manager' WHERE UserId = @id;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }

        public void ChangeUserPermU(string conn, int id)
        {
            ConnectionString = conn;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string cmdText = @"UPDATE Users SET Permission = 'User' WHERE UserId = @id;";
            SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }
    }
}
