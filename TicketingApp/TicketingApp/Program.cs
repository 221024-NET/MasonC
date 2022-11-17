using TicketingApp.Data;
using TicketingApp.InOut;
using TicketingApp.Logic;

namespace TicketingApp.App
{
    public class TicketingApp
    {
        public static void Main(string[] args)
        {
            User user, user2;
            IO io = new IO();
            string[] ConnectionString = System.IO.File.ReadAllLines(@"C:\Users\mpcat\RevatureTraining\ConnectionStrings\TestConnStr.txt");
            SqlRepository repo = new (ConnectionString[0]);

            // Console.WriteLine(ConnectionString[0]);

            // Since we now have a database get the row where Username = Username in the database
            // then check to see if the password matches. Don't get the password back from the 
            // database or else it will be vulnerable.

            int num = io.PrintLogRegMenu();
            // Console.WriteLine(num); // Debug code line
            bool s = false;
            if (num == 1)
            {
                user = io.TryLogin(repo);
                //SQL query to check if user exists and password matches
            }
            else
            {
                user = io.TryReg(repo);
                // SQL query to see if it exists and if it doesn't then create the user
            }


            List<Ticket> list;
            //------- Check Permission Level --------
            // If Manager get all tickets into a List so they may be approved or declined.
            // Cannot be edited again.

            if(user.permLVL == "Manager")
                list = repo.GetAllTicketsPending();
            else 
                list = repo.GetAllTicketsFromUser(user.id);

            int enter = 0;

            // Now that the person has been logged in or registered
            // Need to make a menu so that the user can decide what to do
            if(user.permLVL == "Manager")
            {
                enter = io.PrintMainMenuManager();
            }
            else if(user.permLVL == "Admin")
            {
                enter = io.PrintMainMenuAdmin();
            }
            else
            {
                enter = io.PrintMainMenuUser();
            }

            
            if(enter == 1)
            {
                io.PrintAllTickets(repo);
            }

            // After printing the menu get user input for the selection.

            // Do what the user has decided to do.



        }

        // Make methods to view all of the previous tickets

        public static bool Register(string emailStr, Dictionary<string, User> users)
        {
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
                if (!users.ContainsKey(email))
                {
                    users.Add(email, new User((users.Count + 1), email, password));

                    // Create user here and add to database




                    emailStr = email;
                    return true;
                }
                else return false;

            }
            return false;
        }
    }
}