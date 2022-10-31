using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ticket{
        public class User{
            public string email {get; set;}
            public string password {get; set;}
            public List<string> tickets {get; set;}

    }
}
