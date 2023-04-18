//Create a function that takes a single string as argument and returns an ordered array containing the indices of all capital letters in the string.

//Examples

//IndexOfCapitals("eDaBiT") ➞ [1, 3, 5]

//IndexOfCapitals("eQuINoX") ➞ [1, 3, 4, 6]

//IndexOfCapitals("determine") ➞ []

//IndexOfCapitals("STRIKE") ➞ [0, 1, 2, 3, 4, 5]

//IndexOfCapitals("sUn") ➞ [1]

using System;

namespace CodingChallenges
{
    class Program
    {
        public static List<int> IndexOfCapitals(string s)
        {
            List<int> list = new List<int>();
            
            for(int i  = 0; i < s.Length; i++)
            {
                if (Char.IsUpper(s[i]))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list = IndexOfCapitals("eDaBiT");

            Console.Write("[");
            Console.Write(String.Join(", ", list));
            Console.WriteLine("]");

            list = IndexOfCapitals("eQuINoX");

            Console.Write("[");
            Console.Write(String.Join(", ", list));
            Console.WriteLine("]");

            list = IndexOfCapitals("determine");

            Console.Write("[");
            Console.Write(String.Join(", ", list));
            Console.WriteLine("]");

            list = IndexOfCapitals("STRIKE");

            Console.Write("[");
            Console.Write(String.Join(", ", list));
            Console.WriteLine("]");

            list = IndexOfCapitals("sUn");

            Console.Write("[");
            Console.Write(String.Join(", ", list));
            Console.WriteLine("]");


        }
    }
}