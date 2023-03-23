using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowIntro
{
    internal class Calculator
    {
        public int ans;
        public Calculator() { }

        public void add2Nums(int num1, int num2)
        {
            ans = num1 + num2;
        }

    }
}
