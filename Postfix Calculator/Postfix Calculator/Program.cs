using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postfix_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> values = new Stack<int>();

            foreach (string token in args)
            {
                int value;
                if (int.TryParse(token, out value))
                {
                    values.Push(value);
                }
                else
                {
                    int lhs = values.Pop();
                    int rhs = values.Pop();
                    switch (token)
                    {
                        case "+":
                            values.Push(lhs + rhs);
                            break;
                        case "-":
                            values.Push(lhs - rhs);
                            break;
                        case "*":
                            values.Push(lhs * rhs);
                            break;
                        case "/":
                            values.Push(lhs / rhs);
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unrecognized toke: {0}", token));
                    }

                }
            }
            Console.WriteLine(values.Pop());
            Console.ReadLine();
        }
    }
}
