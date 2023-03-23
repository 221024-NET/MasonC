using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Calculator
    {
        public int doCalculation(string str)
        {
            int ans = 0;
            int num1 = 0;
            //int num2 = 0;
            char op = ' ';
            bool b = true;
            string[] s = new String[str.Length];
            b = Int32.TryParse(str[0].ToString(), out num1);
            if (!b) return -404;
            ans = num1;
            num1 = 0;
            for (int i = 1; i < str.Length; i++)
            {
                b = Int32.TryParse(str[i].ToString(), out num1);
                if (!b)
                {
                    op = str[i];
                }
                switch (op)
                {
                    case '+':
                        {
                            ans = ans + num1;
                            break;
                        }
                    case '-':
                        {
                            ans = ans - num1;
                            break;
                        }


                }
            }
            return ans;
        }
    }
}
