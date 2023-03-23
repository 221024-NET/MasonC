using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class LetterOccurance
    {
        public LetterOccurance() { }
        public void occurances(string s)
        {
            //Get string without spaces and exclamation

            s = s.Replace(" ", "");
            s = s.Replace("!", "");

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                } else
                {
                    map[c] = 1;
                }
            }

            foreach(KeyValuePair<char, int> pair in map) {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

        }
    }
}
