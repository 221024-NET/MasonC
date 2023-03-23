using System;

namespace CodingChallenge
{
    class Program
    {
        public static int CircuitPower(int a, int b)
        {
            return a*b;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine("Testing 230 and 10: Expect 2300");
            Console.WriteLine(CircuitPower(230, 10));
            Console.WriteLine();

            Console.WriteLine("Testing 110 and 3: Expect 330");
            Console.WriteLine(CircuitPower(110, 3));
            Console.WriteLine();

            Console.WriteLine("Testing 480 and 20: Expect 9600");
            Console.WriteLine(CircuitPower(480, 20));
        }
    }
}