using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TicketingApp.Logic
{
    public class Ticket
    {
        public int userId;
        public int ticketId;
        public double amount;
        public string status = "";
        public string description = "";

        public Ticket(int UserId, int TicketId, double Amount, string Status, string Des)
        {
            userId = UserId;
            ticketId = TicketId;
            amount = Amount;
            status = Status;
            description = Des;
        }

    }
}