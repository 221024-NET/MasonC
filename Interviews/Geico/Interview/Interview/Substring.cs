using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Substring
    {
        public Substring() { }
        public void findSubstrings(string s)
        {

            for(int i = 0 ; i < s.Length; i++)
            {
                List<char> chars = new List<char>(); 
                for(int j = i; j < s.Length; j++)
                {
                    chars.Add(s[j]);

                    for(int k = 0; k < chars.Count; k++)
                    {
                        Console.Write(chars[k]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
