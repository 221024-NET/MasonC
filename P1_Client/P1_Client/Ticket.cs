﻿using System;
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

    }
}