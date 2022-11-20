using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Reflection.Metadata;
using TicketingApp.Logic;

namespace P1_Client
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7243/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Ticket? tick = null;
                User? user = null;
                IO io = new IO();
                List<Ticket> tickets;
                List<User> users;
                int num = io.LogRegMenu();
                if (num == 1)
                {
                    //Login here
                    user = await LoginAsync();
                    if (user.Email == "default")
                    {
                        //Failed to successfully login
                        Console.WriteLine("Unable to Log the user in at this time.\n Please try again later.");

                        Environment.Exit(0);
                    }
                    Console.WriteLine("User has logged in successfully!");
                } 
                else
                {
                    //register here
                    user = await RegisterAsync();
                    if (user.Email == "default")
                    {
                        //Failed to successfully login
                        Console.WriteLine("Unable to Register a new user at this time.\n Please try again later.");

                        Environment.Exit(0);
                    }
                    Console.WriteLine("User has logged in successfully!");

                }

                //If here then user has successfully logged/registered.



                while(true)
                {
                    ShowUser(user);
                    if (user.permLVL == "Manager")
                    {
                        //Give manager menu
                        num = io.PrintMainMenuManager();

                        // switch(num):
                        // case 1: 
                        // default: 


                        if (num == 1)
                        {
                            // View Pending tickets
                            var path = "/tickets/Pending";
                            tickets = await GetTicketsPendingAsync(path);
                            foreach (Ticket t in tickets)
                            {
                                ShowTicket(t);
                            }
                        }
                        else if (num == 2)
                        {
                            //change user permission
                            users = await GetAllUsers("/Users");
                            List<int> uId = new List<int>();
                            foreach (User u in users)
                            {
                                ShowUser(u);
                                uId.Add(u.id);
                            }

                            int numId = io.GetUserIdPermChange(uId);
                            User use = users.Find(x => x.id == numId);
                            use = await UpdateUserPerm(numId, use);

                            Console.WriteLine("User has been Updated.\n");
                            //ShowUser(use);


                        }
                        else if (num == 3)
                        {
                            //Accept/decline ticket
                            //Show all pending tickets here
                            tickets = await GetPendingTicketsAsync("/tickets/Pending");
                            List<int> tId = new List<int>();
                            //Get Id of ticket to accept/decline
                            foreach (Ticket t in tickets)
                            {
                                ShowTicket(t);
                                tId.Add(t.ticketId);
                            }

                            //Accpet or decline 
                            int tickID = io.GetTicketId(tId);

                            Ticket index = tickets.Find(x => x.ticketId == tickID);

                            string ad = io.AcceptDecline();

                            if (ad == "Accept")
                            {
                                tick = await UpdateAcceptTicket(tickID, index);
                                ShowTicket(tick);
                            }
                            else
                            {
                                tick = await UpdateDeclineTicket(tickID, index);
                                ShowTicket(tick);
                            }
                            
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        //Give user menu
                        num = io.PrintMainMenuUser();
                        if (num == 1)
                        {
                            // View All User tickets
                            var path = "/tickets/" + user.id;
                            tickets = await GetTicketsUserAsync(path);
                            foreach (Ticket t in tickets)
                            {
                                ShowTicket(t);
                            }
                        }
                        else if (num == 2)
                        {
                            //Submit New Ticket
                            Console.WriteLine("Amount: ");
                            double amount = double.Parse(Console.ReadLine().ToString());
                            Console.WriteLine("Description: ");
                            string d = Console.ReadLine();

                            var url = await CreateNewTicketAsync(new Ticket(user.id, 0, amount, "Pending", d));
                            Console.WriteLine($"Created at {url}");
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static async Task<List<string>> GetEmailsAsync()
        {
            List<User> users = new List<User>();
            List<string> emails = new List<string>();
            HttpResponseMessage response = await client.GetAsync("/Users");
            if(response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            foreach (User user in users)
            {
                emails.Add(user.Email);
            }

            return emails;
        }

        static async Task<List<Ticket>> GetTicketsPendingAsync(string path)
        {
            List<Ticket> tickets;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                tickets = await response.Content.ReadAsAsync<List<Ticket>>();
            } else
            {
                tickets = new List<Ticket>();
                Console.WriteLine("\nNo pending tickets at this time.\n");
            }
            return tickets;
        }

        static async Task<Uri> CreateNewTicketAsync(Ticket t)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/tickets", t);
            return response.Headers.Location;
        }

        static void ShowUser(User u)
        {
            Console.WriteLine($"User ID: {u.id}\t Email: {u.Email}\t Permission Level: {u.permLVL}\t\n");
        }

        static void ShowTicket(Ticket t)
        {
            if(t != null)
            {
                Console.WriteLine($"Ticket ID: {t.ticketId}\t User ID: {t.userId}\t Amount: {t.amount}\t" +
                $" Status: {t.status}\t Description: {t.description}\t\n");
            }
            
        }

        static async Task<User> LoginAsync()
        {
            User u = new User();
            User user;
            string? username = "", password = "";

            //Get the email and password here
            Console.WriteLine("Please enter email: ");
            username = Console.ReadLine();
            // Console.WriteLine(email);
            Console.WriteLine("Please enter password: ");
            password = Console.ReadLine();
            //Console.WriteLine(password);
            if (username == null || password == null)
            {
                Console.WriteLine("One of the entries was invalid.\n Please try again.");
                Environment.Exit(1);
            }

            u.Email = username;
            u.Password = password;

            HttpResponseMessage response = await client.PostAsJsonAsync("Login", u);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            else
            {
                user = new User();
            }
            return user;
        }

        static async Task<User> RegisterAsync()
        {
            User user;
            User u = new User();
            string? username = "", password = "";


            //Get the email and password here
            Console.WriteLine("Please enter email: ");
            username = Console.ReadLine();
            // Console.WriteLine(email);
            Console.WriteLine("Please enter password: ");
            password = Console.ReadLine();
            //Console.WriteLine(password);

            List<string> list = await GetEmailsAsync();
            if(list.Contains(username))
            {
                Console.WriteLine("That Username is unavailable.\n Please try again.");
                Environment.Exit(1);
            }

            if (username == null || password == null)
            {
                Console.WriteLine("One of the entries was invalid.\n Please try again.");
                Environment.Exit(1);
            }

            u.Email = username;
            u.Password = password;

            

            HttpResponseMessage response = await client.PostAsJsonAsync("Register", u);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            else
            {
                user = new User();
            }


            return user;
        }

        //Get all tickets for user
        static async Task<List<Ticket>> GetTicketsUserAsync(string path)
        {
            List<Ticket> tickets = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                tickets = await response.Content.ReadAsAsync<List<Ticket>>();
            } else
            {
                tickets = new List<Ticket>();
                Console.WriteLine("\nThe User has NO tickets at this time.\n");
            }

            return tickets;
        }

        //Get all tickets pending for entire database
        static async Task<List<Ticket>> GetPendingTicketsAsync(string path)
        {
            List<Ticket> tickets = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                tickets = await response.Content.ReadAsAsync<List<Ticket>>();
            }
            return tickets;
        }
        //Get user emailS and user id
        static async Task<List<User>> GetAllUsers(string path)
        {
            List<User> users = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            return users;
        }

        static async Task<User> UpdateUserPerm(int userID, User user)
        {
            User u = null;
            string path = "Permission/" + userID.ToString();
            HttpResponseMessage response;
            if (user.permLVL == "User")
            {
                response = await client.PutAsJsonAsync($"PermissionM/{userID}", user);
                response.EnsureSuccessStatusCode();
                u = await response.Content.ReadAsAsync<User>();
            }
            else
            {
                response = await client.PutAsJsonAsync($"PermissionU/{userID}", user);
                response.EnsureSuccessStatusCode();
                u = await response.Content.ReadAsAsync<User>();
            }
            return u;
        }

        //Accept Ticket
        static async Task<Ticket> UpdateAcceptTicket(int ticketId, Ticket t)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"ticket/Accpet/{ticketId}", t);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Ticket>();
        }


        //Decline Ticket
        static async Task<Ticket> UpdateDeclineTicket(int ticketId, Ticket t)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"ticket/Decline/{ticketId}", t);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Ticket>();
        }
    }
}