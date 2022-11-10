using P1.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Data
{
    public interface IRepository
    {
        public List<Ticket> GetAllTickets();
        public List<Ticket> GetAllTicketsFromUser(int userId);
    }
}
