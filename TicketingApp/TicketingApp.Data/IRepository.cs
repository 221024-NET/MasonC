using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Logic;

namespace TicketingApp.Data
{
    public interface IRepository
    {
        public List<Ticket> GetAllTickets();
        public List<Ticket> GetAllTicketsFromUser(int userId);
        public Dictionary<string, User> GetAllUsers();
        public User GetUser(string email);
    }
}
