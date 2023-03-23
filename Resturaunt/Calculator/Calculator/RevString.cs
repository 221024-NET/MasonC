using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RevString
    {
        public RevString() { }

        public string reverse(string str)
        {
            string[] s = str.Split(' ');
            for(int i = 0; i < s.Length; i++)
            {
                char[] c = s[i].ToCharArray();
                Array.Reverse(c);
                s[i] = new string(c);
            }
            string s2 = "";
            foreach(string s1 in s)
            {
                s2 = s2 + s1 + " ";
            }
            return s2;
        }
    }
}
