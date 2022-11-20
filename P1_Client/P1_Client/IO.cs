using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Logic;

namespace P1_Client
{
    class IO
    {
        public IO() { }

        public int LogRegMenu()
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

        public int PrintMainMenuManager()
        {
            string num;
            int i = 0;
            Console.WriteLine("1. View All Pending Tickets");
            Console.WriteLine("2. Change User Permission Level (Need User ID)");
            Console.WriteLine("3. Accept/Decline Ticket");
            Console.WriteLine("4. Quit");
            while (true)
            {
                num = Console.ReadLine();
                i = Int32.Parse(num);
                if (i < 5 && i > 0)
                {
                    return i;
                }
                Console.WriteLine("1. View All Pending Tickets");
                Console.WriteLine("2. Change User Permission Level (Need User ID)");
                Console.WriteLine("3. Accept/Decline Ticket");
                Console.WriteLine("4. Quit");
            }

        }

        public int PrintMainMenuUser()
        {
            string num;
            int i = 0;
            Console.WriteLine("1. View All Of My Tickets");
            Console.WriteLine("2. Submit New Ticket");
            Console.WriteLine("3. Quit");

            while (true)
            {
                num = Console.ReadLine();
                i = Int32.Parse(num);
                if (i < 4 && i > 0)
                {
                    return i;
                }
                Console.WriteLine("1. View All Of My Tickets");
                Console.WriteLine("2. Submit New Ticket");
                Console.WriteLine("3. Quit");
            }

        }

        public Ticket MakeTicket()
        {
            Ticket t;
            Console.WriteLine("Amount: ");
            double amount = Double.Parse(Console.ReadLine());
            Console.WriteLine("Description: ");
            string d = Console.ReadLine().ToString();
            return new Ticket(0, 0, amount, "Pending", d);
        }

        public int GetUserIdPermChange(List<int> uids)
        {
            int num = 0;
            Console.WriteLine("Please enter the UserId that you would like to chnage the permission to manager of.\n");
            num = Int32.Parse(Console.ReadLine());
            while(!uids.Contains(num))
            {
                Console.WriteLine("Incorrect Entry please try again.\n");
                Console.WriteLine("Please enter the UserId that you would like to change the permission to manager of.\n");
                num = Int32.Parse(Console.ReadLine());
            }
            return num;
        }

        public int GetTicketId(List<int> tIDs)
        {
            int id;
            Console.WriteLine("Please enter the ID number of trhe ticke that you would like to accept or decline.\n");
            id = Int32.Parse(Console.ReadLine());
            while(!tIDs.Contains(id))
            {
                Console.WriteLine("Invalid entry. Please try again.\n");
                Console.WriteLine("Please enter the ID number of trhe ticke that you would like to accept or decline.\n");
                id = Int32.Parse(Console.ReadLine());
            }
            return id;
        }

        public string AcceptDecline()
        {
            Console.WriteLine("1.Accpet");
            Console.WriteLine("2.Decline");
            int entry = Int32.Parse(Console.ReadLine());
            if(entry == 1)
            {
                return "Accept";
            } else
            {
                return "Decline";
            }
        }
    }
}
