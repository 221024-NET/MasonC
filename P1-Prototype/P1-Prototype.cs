using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ticket;
public class P1{
    public static void Main(string[] args){
        Console.WriteLine("Please select the number of the option you would like.");
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Register");
        int num = 0;
        string entry = Console.ReadLine();
        bool loop = Int32.TryParse(entry, out num);
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
            s = Login();
        } else {
            s = Register();
        }

        if(!s){
            Console.WriteLine("Unable to Login/Register the User. Please contact Admin.");
        }

    }

    public static Boolean Login(){
        bool loop = true;
        while(loop){
            Console.WriteLine("Please enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter password: ");
            string password = Console.ReadLine();
            // Verify that the user has an account then check if password matches
            return true;
        }
        
        return false;
    }
    public static Boolean Register(){
        bool loop = true;
        while(loop){
            Console.WriteLine("Please enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter password: ");
            string password = Console.ReadLine();
            // Verify that the email hasnt been used

            // If not used add the record to database

            return true;
        }
        return false;
    }
}