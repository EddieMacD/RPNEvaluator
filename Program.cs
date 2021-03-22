using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string expression = Console.ReadLine();
                Console.WriteLine(RPNEval(expression));
                Console.WriteLine();
            } while (true);
        }

        static double RPNEval (string input)
        {
            bool valid = true;
            double result = int.MinValue;
            Stack<double> stack = new Stack<double>();
            string expression = input + " ";

            while (expression != "" && valid)
            {
                string current = expression.Substring(0, expression.IndexOf(' '));
                double temp;

                try
                {
                    if (double.TryParse(current, out temp))
                    {
                        stack.Push(temp);
                    }
                    else
                    {
                        switch (current)
                        {
                            case "+":
                                double temp2 = stack.Pop();
                                double temp1 = stack.Pop();

                                stack.Push(temp1 + temp2);
                                break;

                            case "-":
                                temp2 = stack.Pop();
                                temp1 = stack.Pop();

                                stack.Push(temp1 - temp2);
                                break;

                            case "*":
                                temp2 = stack.Pop();
                                temp1 = stack.Pop();

                                stack.Push(temp1 * temp2);
                                break;

                            case "/":
                                temp2 = stack.Pop();
                                temp1 = stack.Pop();

                                stack.Push(temp1 / temp2);
                                break;

                            default:
                                valid = false;
                                break;
                        }
                    }

                    expression = expression.Remove(0, expression.IndexOf(' ') + 1);
                }
                catch (Exception e)
                {
                    valid = false;
                }
            }

            if(valid)
            {
                if (stack.Count == 1)
                {
                    result = stack.Pop();
                }
            }

            return result;
        }
    }
}
