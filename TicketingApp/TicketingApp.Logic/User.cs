using System;
using System.IO;

namespace TicketingApp.Logic
{
    public class User
    {
        public string permLVL { get; set; } //Permission level admin has admin privilage else it will be user
        public int id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<string> tickets = new List<string>();

        public User()
        {
            permLVL = "User";
            id = 999999;
            Email = "Sample@sample.com";
            Password = "Sample";
        }

        public User(string email, string pass)
        {
            permLVL = "User";
            Email = email;
            Password = pass;
        }

        public User(string permLVL, int id, string email, string password)
        {
            this.permLVL = permLVL;
            this.id = id;
            Email = email;
            Password = password;
        }

        public User(int id, string Email, string password)
        {
            permLVL = "User";
            this.id = id;
            this.Email = Email;
            Password = password;
        }

    }
}
