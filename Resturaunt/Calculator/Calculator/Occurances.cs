using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Occurances
    {
        public void letterOccurances(string s)
        {
            s = s.Replace(" ", "");
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic[c] = 1;
                }
            }
            foreach (KeyValuePair<char, int> pair in dic)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }

        public void numOccurances(List<int> list)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (dic.ContainsKey(list[i]))
                {
                    dic[list[i]]++;
                }
                else
                {
                    dic[list[i]] = 1;
                }
            }
            foreach (KeyValuePair<int, int> pair in dic)
            {
                if (pair.Value > 1)
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value}");
                }
                //Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
