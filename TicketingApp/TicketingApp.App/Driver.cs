using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Data;


namespace TicketingApp.App
{
    public class Driver
    {
        IRepository repo;

        public Driver(IRepository repo)
        {
            this.repo = repo;
        }

    }
}
