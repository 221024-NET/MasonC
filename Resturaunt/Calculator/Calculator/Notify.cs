using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Notify
    {
        public Notify() { }

        public void notify()
        {
            Console.WriteLine("Please enter an email or phone number:");
            string s = Console.ReadLine();
            if(s == string.Empty || s == " ")
            {
                Console.WriteLine("Invalid input. Please try again. Cannot be null or only a space.");
                Console.WriteLine("Please enter an email or phone number:");
                s = Console.ReadLine();
            }

            Console.WriteLine("Please enter a message to send:");
            string s1 = Console.ReadLine();
            if (s1 == string.Empty || s1 == " ")
            {
                Console.WriteLine("Invalid input. Please try again. Cannot be null or only a space.");
                Console.WriteLine("Please enter a message to send:");
                s1 = Console.ReadLine();
            }

            Console.WriteLine($"Sent to {s} - Message: {s1}");
        }
    }
}
