using System;
using System.Security.Cryptography.X509Certificates;
using TicketingApp.Data;
using TicketingApp.Logic;


namespace TicketingApp.InOut
{
    public class IO
    {
        
        public IO()
        {

        }

        //Print invalid log/reg

        //Print Successful login/register

        //Print Login/Reg menu

        public int PrintLogRegMenu()
        {
            Console.WriteLine("Please select the number of the option you would like.");
            Console.WriteLine("1 - Login");
            Console.WriteLine("2 - Register");
            int num = 0;
            string entry = Console.ReadLine();
            bool loop = Int32.TryParse(entry, out num);
            // Console.WriteLine(use.Username + " " + users[use.Password]);
            while (!loop || num < 1 || num > 2)
            {
                Console.WriteLine("\nIncorrect Entry.\nPlease Try Again.\n");
                Console.WriteLine("Please select the number of the option you would like.");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Register");
                entry = Console.ReadLine();
                loop = Int32.TryParse(entry, out num);
            }
            return num;
        }

        //Print invalid log/reg

        public User TryLogin(SqlRepository repo)
        {
            User user = new User();
            bool loop = true;
            string username = "", password = "";
            while (loop)
            {
                Console.WriteLine("Please enter email: ");
                username = Console.ReadLine();
                username = username.Replace("\n", "").Replace("\r", "");
                // Console.WriteLine(email);
                Console.WriteLine("Please enter password: ");
                password = Console.ReadLine();
                password = password.Replace("\n", "").Replace("\r", "");
                //Console.WriteLine(password);

                // Query database for email get the user
                user = repo.Login(username, password);

                // If does not contain the user print error
                if(user.Email != "Sample@sample.com")
                {
                    PrintLogRegSuccess();
                    loop = false;
                    break;
                } 
                else
                {
                    PrintLogRegErr();
                }
            }

            return user;
        }

        public User TryReg(SqlRepository repo)
        {
            User user = new User();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Please enter email: ");
                string email = Console.ReadLine();
                email = email.Replace("\n", "").Replace("\r", "");
                Console.WriteLine("Please enter password: ");
                string password = Console.ReadLine();
                password = password.Replace("\n", "").Replace("\r", "");
                // Verify that the email hasnt been used
                // If not used add the record to database

                // Query database for the record
                user = repo.Login(email, password);

                if(user.Email != "Sample@sample.com")
                {
                    user = repo.Register(email, password);
                    PrintLogRegSuccess();
                    loop = false;
                    break;
                } 
                else
                {
                    PrintLogRegErr();
                }
                // If contains record then check passwords

                // if does not contain record loop

            }
            return user;
        }

        public void PrintLogRegErr()
        {
            Console.WriteLine("Unable to Login/Register the User.\n     Please contact Admin or try a different account.\n");
        }
        public void PrintLogRegSuccess()
        {
            Console.WriteLine("\nSuccessfully Logged in or Registered!\n");
        }

        public int PrintMainMenuUser()
        {
            string num;
            int i = 0;
            Console.WriteLine("1. View All Of My Tickets");
            Console.WriteLine("2. Submit New Ticket");

            while (true)
            {
                num = Console.ReadLine();
                int.TryParse(num, out i);
                if (i < 3 && i > 0)
                {
                    return i;
                }
                Console.WriteLine("1. View All Of My Tickets");
                Console.WriteLine("2. Submit New Ticket");
            }

        }

        public int PrintMainMenuManager()
        {
            string num;
            int i = 0;
            Console.WriteLine("1. View All Pending Tickets");
            Console.WriteLine("2. Change User Permission Level (Need User Email)");
            while (true)
            {
                num = Console.ReadLine();
                int.TryParse(num, out i);
                if(i < 3 && i > 0)
                {
                    return i;
                }
                Console.WriteLine("1. View All Pending Tickets");
                Console.WriteLine("2. Change User Permission Level (Need User Email)");
            }

        }

        public int PrintMainMenuAdmin()
        {
            string num;
            int i = 0;
            Console.WriteLine("1. View All Tickets");
            Console.WriteLine("2. Change User Permission Level (Need User Email)");
            while (true)
            {
                num = Console.ReadLine();
                int.TryParse(num, out i);
                if (i < 3 && i > 0)
                {
                    return i;
                }
                Console.WriteLine("1. View All Tickets");
                Console.WriteLine("2. Change User Permission Level (Need User Email)");
            }

        }

        public void PrintAllTickets(SqlRepository repo)
        {
            //List<Ticket> list = repo.GetAllTicketsPending();

            //Console.WriteLine("Ticket ID - User ID - Amount");
            //foreach (Ticket ticket in list)
            //{
                //Console.WriteLine(ticket.ticketId + " " + ticket.userId + " " + ticket.amount);
                //Console.WriteLine(ticket.description + "\n");
            //}
        }
    }
}