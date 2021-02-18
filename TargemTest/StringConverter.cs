using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalcRPN
{
    class StringConverter
    {
        public static Queue<string> StringToRPN(string expression)
        {
            string[] expressionTokens = StringToCorrectString(expression).Split("");
            var outputLine = new Queue<string>();
            var stack = new Stack<string>();
            foreach (var ch in expressionTokens)
            {
                double val;
                switch (ch)
                {
                    case "": break;
                    case String _ when double.TryParse(ch, out val):
                        outputLine.Enqueue(ch);
                        break;
                    case "+":
                    case "-":
                        if (stack.Count > 0)
                        {
                            while (stack.Peek() == "+" || stack.Peek() == "-" || stack.Peek() == "*" || stack.Peek() == "/")
                            {
                                outputLine.Enqueue(stack.Pop());
                            }
                        }
                        stack.Push(ch);
                        break;
                    case "*":
                    case "/":
                        while (stack.Count > 0)
                        {
                            if (stack.Peek() == "*" || stack.Peek() == "/")
                                outputLine.Enqueue(stack.Pop());
                            else break;
                        }
                        stack.Push(ch);
                        break;
                    case "(":
                        stack.Push(ch);
                        break;
                    case ")":
                        while (true)
                        {
                            var t = stack.Pop();
                            if (t == "(")
                                break;
                            outputLine.Enqueue(t);
                        }
                        break;
                    default:
                        Console.WriteLine($"\" {ch} \" <- is not a number or operator");
                        return null;
                }
            }
            while (stack.Count > 0)
                outputLine.Enqueue(stack.Pop());
            return outputLine;
        }
        private static string StringToCorrectString(string expression)
        {
            expression = expression.Replace(" ", "");
            expression = expression.Replace("+", " + ");
            expression = expression.Replace("-", " - ");
            expression = expression.Replace("*", " * ");
            expression = expression.Replace("/", " / ");
            expression = expression.Replace("(", " ( ");
            expression = expression.Replace(")", " ) ");
            return expression;
        }
    }
}
