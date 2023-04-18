using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Calculator
    {
        public Calculator() { }

        public void calculation()
        {
            int a = 0;
            int b = 0;
            Console.WriteLine("Please enter a number: ");
            string num1 = Console.ReadLine();
            bool isNum1 = Int32.TryParse(num1, out a);
            while (!isNum1) {
                Console.WriteLine("Error Not a number");
                Console.WriteLine("Please enter a number: ");
                num1 = Console.ReadLine();
                isNum1 = Int32.TryParse(num1, out a);
            }

            Console.WriteLine("Please enter another number: ");
            string num2 = Console.ReadLine();
            bool isNum2 = Int32.TryParse(num2, out b);
            while (!isNum2)
            {
                Console.WriteLine("Error Not a number");
                Console.WriteLine("Please enter another number: ");
                num2 = Console.ReadLine();
                isNum2 = Int32.TryParse(num2, out b);
            }


            Console.WriteLine("Please enter one of the following operands (+, -, /, *): ");
            string operand = Console.ReadLine();
            switch(operand)
            {
                case "+":
                    Console.Write($"Answer for {a} + {b} = ");
                    Console.WriteLine(a + b);
                    break;
                case "-":
                    Console.Write($"Answer for {a} - {b} = ");
                    Console.WriteLine(a - b);
                    break;
                case "*":
                    Console.Write($"Answer for {a} * {b} = ");
                    Console.WriteLine(a * b);
                    break;
                case "/":
                    Console.Write($"Answer for {a} / {b} = ");
                    Console.WriteLine(a / b);
                    break;
            }
        }
    }
}
