using System.Text;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;



namespace MinApi
{
    public class CustomerRepository
    {
        public List<Customer> GetAll(string connString)
        {
            var customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                StringBuilder qry = new StringBuilder();
                qry.Append("SELECT CustomerId, FirstName, LastName, Email FROM Customer;");

                SqlCommand cmd = new SqlCommand(qry.ToString(), connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer cust = new Customer();
                    cust.CustomerId = reader.GetInt32(0);
                    cust.CustomerFirstName = reader.GetString(1);
                    cust.CustomerLastName = reader.GetString(2);
                    cust.Email = reader.GetString(3);

                    customers.Add(cust);
                }
                reader.Close();
                cmd.Dispose();
                connection.Close();
            }

            return customers;
        }

        public Customer Get(string connString, int id)
        {
            var customer = new Customer();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                StringBuilder qry = new StringBuilder();
                qry.Append(" SELECT CustomerID, FirstName, LastName, Email FROM Customer");
                qry.Append($" WHERE CustomerID = {id}");

                SqlCommand cmd = new SqlCommand(qry.ToString(), connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer.CustomerId = reader.GetInt32(0);
                    customer.CustomerFirstName = reader["FirstName"].ToString();
                    customer.CustomerLastName = reader["LastName"].ToString();
                    customer.Email = reader["Email"].ToString();
                    break;
                }
                reader.Close();
                cmd.Dispose();
            }
            return customer;
        }
        public Customer Create(string connString, Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                StringBuilder qry = new StringBuilder();
                qry.Append(" INSERT INTO Customer");
                qry.Append(" (FirstName, LastName, Email)");
                qry.Append($" VALUES (");
                qry.Append($" '{customer.CustomerFirstName}',");
                qry.Append($" '{customer.CustomerLastName}',");
                qry.Append($" '{customer.Email}');");
                qry.Append($" SELECT @@IDENTITY;");
                Console.WriteLine(qry.ToString());

                SqlCommand cmd = new SqlCommand(qry.ToString(), connection);
                connection.Open();
                int newId = Convert.ToInt32(cmd.ExecuteScalar()); 
                customer.CustomerId = newId;
                cmd.Dispose();
            }
            return customer;
        }

        public void Update(string connString, int id, Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                StringBuilder qry = new StringBuilder();
                qry.Append(" UPDATE Customer");
                qry.Append($" SET FirstName = {customer.CustomerFirstName}',");
                qry.Append($" LastName = '{customer.CustomerLastName}'),");
                qry.Append($" Email = '{customer.Email}'");
                qry.Append($" WHERE CustomerId = '{id}';");
                Console.WriteLine(qry.ToString());

                SqlCommand cmd = new SqlCommand(qry.ToString(), connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return;
        }

        public void Delete(string connString, int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                StringBuilder qry = new StringBuilder();
                qry.Append(" DELETE FROM Customer");
                qry.Append($" WHERE CustomerId = '{id}';");
                Console.WriteLine(qry.ToString());

                SqlCommand cmd = new SqlCommand(qry.ToString(), connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return;
        }
    }

}
