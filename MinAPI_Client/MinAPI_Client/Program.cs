using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Transactions;

namespace MinAPI_Client
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
            client.BaseAddress = new Uri("https://localhost:7180");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var customers = await GetAllCustomers();
                foreach(var cust in customers)
                {
                    ShowCustomer(cust);
                }

                Customer customer = new Customer
                {
                    CustomerId = 60,
                    CustomerFirstName = "Test",
                    CustomerLastName = "Test",
                    Email = "Test@test.com"
                };

                var url = await CreateCustomerAsync(customer);
                Console.WriteLine($"Created at {url}");

                customer = await GetCustomerAsync(url.ToString());
                ShowCustomer(customer);

                Console.WriteLine("Customer record created. Please check DB...");
                Console.WriteLine("Press <ENTER> to Update this record...");
                Console.ReadLine();

                Console.WriteLine("Updating Country...");
                customer.Email = "Demo@gmail.com";
                await UpdateCustomerAsync(customer);

                customer = await GetCustomerAsync(url.ToString());
                ShowCustomer(customer);

                Console.WriteLine("Customer record updated. Please check in DB...");
                Console.WriteLine("Press <ENTER> to Delete Update this record...");
                Console.ReadLine();

                var statusCode = await DeleteCustomerAsync(customer.CustomerId);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
                Console.WriteLine("Press <ENTER> to exit...");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static void ShowCustomer(Customer customer) {
            Console.WriteLine($"ID: {customer.CustomerId}\t First Name: {customer.CustomerFirstName}\t" +
                $"Last Name: {customer.CustomerLastName}\t Email: {customer.Email}\t");
        }

        static async Task<List<Customer>> GetAllCustomers() {
            List<Customer> customers = new List<Customer>();
            var path = "customers";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadAsAsync<List<Customer>>();
            }
            return customers;
        }

        static async Task<Uri> CreateCustomerAsync(Customer customer) {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "customers", customer);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        static async Task<Customer> GetCustomerAsync(string path) {
            Customer customer = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<Customer>();
            }
            return customer;
        }

        static async Task<Customer> UpdateCustomerAsync(Customer customer) {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"customer/{customer.CustomerId}", customer);
            response.EnsureSuccessStatusCode();

            customer = await response.Content.ReadAsAsync<Customer>();
            return customer;
        }

        static async Task<HttpStatusCode> DeleteCustomerAsync(long id) {
            HttpResponseMessage response = await client.DeleteAsync(
                $"customers/{id}");
            return response.StatusCode;
        }
    }
}

