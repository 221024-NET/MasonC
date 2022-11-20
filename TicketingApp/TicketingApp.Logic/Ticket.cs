using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TicketingApp.Logic
{
    public class Ticket
    {
        public int userId { get; set; }
        public int ticketId { get; set; }
        public double amount { get; set; }
        public string status { get; set; }
        public string description { get; set; }

        public Ticket(int UserId, int TicketId, double Amount, string Status, string Des)
        {
            userId = UserId;
            ticketId = TicketId;
            amount = Amount;
            status = Status;
            description = Des;
        }

        public Ticket()
        {
            userId = 2;
            ticketId = 0;
            amount = 99999999.99;
            status = "Pending";
            description = "Test";
        }

        public Ticket(int TicketId, double Amount, string Status, string Des)
        {
            userId = 2;
            ticketId = TicketId;
            amount = Amount;
            status = Status;
            description = Des;
        }

        public Ticket(int UserId, int TicketId, double Amount, string Des)
        {
            userId = UserId;
            ticketId = TicketId;
            amount = Amount;
            status = "Pending";
            description = Des;
        }

    }
}