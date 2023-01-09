using System;

namespace ReverseString
{
    public class ReverseString
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string to be reversed: ");
            string str = Console.ReadLine();
            char[] c = str.ToCharArray();
            Array.Reverse(c);
            Console.WriteLine(c);
        }
    }
}