using System;

namespace CodingChallenge
{
    class Program
    {
        public static bool CheckEquality(object a, object b)
        {
            return a.Equals(b);
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine("Testing 1 and 1: Expect true");
            Console.WriteLine(CheckEquality(1, 1));
            Console.WriteLine();

            Console.WriteLine("Testing 1 and \"1\": Expect false");
            Console.WriteLine(CheckEquality(1, "1"));
            Console.WriteLine();

            Console.WriteLine("Testing 1 and true: Expect false");
            Console.WriteLine(CheckEquality(1, true));
            Console.WriteLine();
        }
    }
}