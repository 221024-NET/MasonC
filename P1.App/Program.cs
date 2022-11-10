using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1.Data;
using P1.Logic;

namespace P1.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] ConnectionString = System.IO.File.ReadAllLines("C:\\Users\\mpcat\\RevatureTraining\\ConnectionStrings\\TestConnStr.txt");
            string emailStr = "";
            Dictionary<string, User> users = new Dictionary<string, User>();
            emailStr = "";

            // Console.WriteLine(ConnectionString[0]);

            // Since we now have a database get the row where Username = Username in the database
            // then check to see if the password matches. Don't get the password back from the 
            // database or else it will be vulnerable.

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
            // Console.WriteLine(num); // Debug code line
            bool s = false;
            if (num == 1)
            {
                s = Login(emailStr, users);
            }
            else
            {
                s = Register(emailStr, users);
            }

            if (s)
            {
                Console.WriteLine("Unable to Login/Register the User. Please contact Admin.");
            }
            else
            {
                Console.WriteLine("Successfully Logged in or Registered!");
                //Console.WriteLine($"----------{Int32.TryParse(users[])}----------");
            }

            // Now that the person has been logged in or registered
            // Need to make a menu so that the user can decide what to do



            // After printing the menu get user input for the selection.

            // Do what the user has decided to do.



        }

        // Make methods to view all of the previous tickets

        public static Boolean Login(string emailStr, Dictionary<string, User> users)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Please enter email: ");
                string username = Console.ReadLine();
                username = username.Replace("\n", "").Replace("\r", "");
                // Console.WriteLine(email);
                Console.WriteLine("Please enter password: ");
                string password = Console.ReadLine();
                password = password.Replace("\n", "").Replace("\r", "");
                //Console.WriteLine(password);
                //Verify that the user has an account then check if password matches

                // @"SELECT * FROM Users WHERE Email = @username AND Password = @password;";


                if (username == null) return false;
                else return users[username].Equals(password);
                emailStr = username;
            }

            return false;
        }

        public static Boolean Register(string emailStr, Dictionary<string, User> users)
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
