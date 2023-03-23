using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CheckAnagram
    {
        public bool isAnagram(string s1, string s2)
        {
            if(s1.Length != s2.Length) return false;
            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();

            Dictionary<char, int> dic1 = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                char c = s1[i];
                if (dic1.ContainsKey(c))
                {
                    dic1[c]++;
                }
                else
                {
                    dic1[c] = 1;
                }
            }

            Dictionary<char, int> dic2 = new Dictionary<char, int>();
            for (int i = 0; i < s2.Length; i++)
            {
                char c = s2[i];
                if (dic2.ContainsKey(c))
                {
                    dic2[c]++;
                }
                else
                {
                    dic2[c] = 1;
                }
            }

            

            return dic1.SequenceEqual(dic2);
        }
    }
}
