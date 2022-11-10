using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Logic{
    public class Ticket {
        public int userId;
        public int ticketId;
        public double amount;
        public string status = "";
        public string description = "";

        public Ticket()
        {
            int userId = 0;
            int ticketId = 0;
            double amount = 0;
            string status = "NULL";
            string description = "NOT REAL";
        }

        public Ticket(int userId, int ticketId, double amount, string status, string description)
        {
            this.userId = userId;
            this.ticketId = ticketId;
            this.amount = amount;
            this.status = status;
            this.description = description;
        }

    }
}