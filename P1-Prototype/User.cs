using System;
using System.IO;

namespace TicketingSystem{
    public class User{
        string permLVL; //Permission level admin has admin privilage else it will be user
        int id;
        public string email { get; set; }
        public string Password {get; set;}
        public List<string> tickets = new List<string>();

        public User(){
            permLVL = "Admin";
            id = 999999;
            email = "admin";
            Password = "admin";
            tickets.Add("999999");
        }

        public User(string permLVL, int id, string email, string password, string ticketID){
            this.permLVL = permLVL;
            this.id = id;
            this.email = email;
            Password = password;
            tickets.Add(ticketID);
        }

        public User(int id, string email, string password){
            permLVL = "User";
            this.id = id;
            this.email = email;
            Password = password;
        }
    
    }
}
