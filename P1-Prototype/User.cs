using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ticket{
        public class User{
            string permLVL; //Permission level admin has admin privilage else it will be user
            int id;
            public string email {get; set;}
            public string password {get; set;}
            public List<string> tickets = new List<string>();

            public User(){
                permLVL = "User";
                id = 999999;
                email = "admin@P1";
                password = "admin";
                tickets.Add("999999");
            }

            public User(string permLVL, int id, string email, string password, string ticketID){
                this.permLVL = permLVL;
                this.id = id;
                this.email = email;
                this.password = password;
                tickets.Add(ticketID);
            }

            public User(int id, string email, string password, string ticketID){
                permLVL = "User";
                this.id = id;
                this.email = email;
                this.password = password;
                tickets.Add(ticketID);
            }
    }
}
