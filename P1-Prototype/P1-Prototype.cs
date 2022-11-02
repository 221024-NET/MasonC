using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace TicketingSystem{
    public class P1{
        public static void Main(string[] args){
            Dictionary<string, User> users = new Dictionary<string, User>();
            User use = new User(1, "admin", "admin");
            users.Add("admin", use);

            Console.WriteLine("Please select the number of the option you would like.");
            Console.WriteLine("1 - Login");
            Console.WriteLine("2 - Register");
            int num = 0;
            string entry = Console.ReadLine();
            bool loop = Int32.TryParse(entry, out num);
            Console.WriteLine(use.email + " " + users[use.password]);
            while(!loop || num < 1 || num > 2){
                Console.WriteLine("\nIncorrect Entry.\nPlease Try Again.\n");
                Console.WriteLine("Please select the number of the option you would like.");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Register");
                entry = Console.ReadLine();
                loop = Int32.TryParse(entry, out num);
            }
            // Console.WriteLine(num); // Debug code line
            bool s = false;
            if(num == 1){
                s = Login(users);
            } else {
                s = Register(users);
            }

            if(s){
                Console.WriteLine("Unable to Login/Register the User. Please contact Admin.");
            } else Console.WriteLine("Successfully Logged in or Registered!");

        }

        public static Boolean Login(Dictionary<string, User> users){
            bool loop = true;
            while(loop){
                Console.WriteLine("Please enter email: ");
                string email = Console.ReadLine();
                email = email.Replace("\n", "").Replace("\r", "");
                // Console.WriteLine(email);
                Console.WriteLine("Please enter password: ");
                string password = Console.ReadLine();
                password = password.Replace("\n", "").Replace("\r", "");
                //Console.WriteLine(password);
                // Verify that the user has an account then check if password matches
                if (email == null) return false;
                else return users[email].Equals(password);
            }
            
            return false;
        }
        public static Boolean Register(Dictionary<string, User> users)
        {
            bool loop = true;
            while(loop){
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
                    return true;
                }
                else return false;
            }
            return false;
        }
    }
}