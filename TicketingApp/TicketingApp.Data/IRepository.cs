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
        public List<Ticket> GetAllTickets(string connValue);
        public List<Ticket> GetAllTicketsFromUser(string connValue, int userId);
        public Dictionary<string, User> GetAllUsers(string connValue);
        public User GetUser(string connValue, int id);
    }
}
