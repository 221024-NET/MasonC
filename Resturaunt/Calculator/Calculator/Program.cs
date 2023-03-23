using Calculator;
using System;

namespace Calc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            Occurances occurances = new Occurances();
            Substring sub = new Substring();
            BubbleSort bub = new BubbleSort();
            RevString rev = new RevString();
            Notify n = new Notify();
            CheckAnagram ana = new CheckAnagram();
            int[] a = { 10000, 5000,3, 53765, 8934, 20, 569, 892, 77774, 9999 };
            int[] b = new int[a.Length];
            //Console.Write("[ ");
            //foreach (int i in a)
            //{
            //    Console.Write(i + ", ");
            //}
            //Console.WriteLine("]");
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine(c.doCalculation("3+5-9+4"));
            //occurances.letterOccurances("Hello World!");
            //sub.getAllSubStrings("Hello World");
            //bub.bubbleSort(a, out b);
            //Console.Write("[ ");
            //foreach (int i in b)
            //{
            //    Console.Write(i + ", ");
            //}
            //Console.WriteLine("]");

            //Console.WriteLine(rev.reverse("Hello World"));

            //n.notify();

            //List<int> l = new List<int>();
            //l.Add(9);
            //l.Add(9);
            //l.Add(4);
            //l.Add(1);
            //l.Add(1);
            //l.Add(4);
            //l.Add(2);
            //l.Add(2);
            //l.Add(6);
            //l.Add(9);
            //l.Add(8);
            //l.Add(7); 
            //l.Add(8);
            //l.Add(8); 
            //l.Add(10);
            //l.Add(11);
            //occurances.numOccurances(l);

            bool torf = ana.isAnagram("racecar", "racecar");
            if (torf)
            {
                Console.WriteLine("True");
            }

        }
    }
}
