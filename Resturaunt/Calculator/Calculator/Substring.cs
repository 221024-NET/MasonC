using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Substring
    {
        public void getAllSubStrings(string s)
        {
            
            for(int i = 0; i < s.Length; i++)
            {
                char[] chars = new char[s.Length];
                for (int j = i; j < s.Length; j++)
                {
                    chars[j] = s[j];
                    string d = new string(chars);
                    Console.WriteLine(d);
                }
            }
        }
    }
}
