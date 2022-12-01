using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;


namespace SHA256Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            SHA256 myHash = SHA256.Create();

            string password = Console.ReadLine().ToString();
            string salt = "wim";
            string combined = salt + password;

            byte[] bytes = new byte[combined.Length * sizeof(char)];
            System.Buffer.BlockCopy(combined.ToCharArray(), 0, bytes, 0, bytes.Length);

            byte[] hashvalue = myHash.ComputeHash(bytes);
            string hash = BitConverter.ToString(hashvalue).Replace("-", "");

            Console.WriteLine(hash);
        }
    }
}