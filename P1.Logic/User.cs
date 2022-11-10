using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace P1.Logic{
    public class User{
        string permLVL; //Permission level admin has admin privilage else it will be user
        public int id;
        public string Email { get; set; }
        public string Password {get; set;}

        public List<string> tickets = new List<string>();

        public User(){
            permLVL = "Admin";
            id = 999999;
            Email = "Admin@admin.com";
            Password = "admin";
            tickets.Add("999999");
        }

        public User(string permLVL, int id, string email, string password, string ticketID){
            this.permLVL = permLVL;
            this.id = id;
            Email = email;
            Password = password;
            tickets.Add(ticketID);
        }

        public User(int id, string Email, string password){
            permLVL = "User";
            this.id = id;
            this.Email = Email;
            Password = password;
        }
    
    }
}
