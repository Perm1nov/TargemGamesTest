using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StringCalcRPN
{
    class StringConverter
    {
        /// <summary>
        /// Приводит строку к Обратной польской записи
        /// </summary>
        public static Queue<string> StringToRPN(string expression)
        {
            string[] expressionTokens = StringToCorrectString(expression).Split(" ");
            if (!IsCorrectBrackets(expression))
                throw new Exception("Opening and closing brackets doesn't match");
            var outputLine = new Queue<string>();
            var operatorsStack = new Stack<string>();
            foreach (var ch in expressionTokens)
            {
                switch (ch)
                {
                    case "": break;
                    case string _ when double.TryParse(ch, out double val):
                        outputLine.Enqueue(ch);
                        break;
                    case "+":
                    case "-":
                        while (operatorsStack.Count > 0)
                        {
                            if (operatorsStack.Peek() == "+" || operatorsStack.Peek() == "-" || operatorsStack.Peek() == "*" || operatorsStack.Peek() == "/")
                            {
                                outputLine.Enqueue(operatorsStack.Pop());
                            }
                        }
                        operatorsStack.Push(ch);
                        break;
                    case "*":
                    case "/":
                        while (operatorsStack.Count > 0)
                        {
                            if (operatorsStack.Peek() == "*" || operatorsStack.Peek() == "/")
                                outputLine.Enqueue(operatorsStack.Pop());
                            else break;
                        }
                        operatorsStack.Push(ch);
                        break;
                    case "(":
                        operatorsStack.Push(ch);
                        break;
                    case ")":
                        while (true)
                        {
                            var t = operatorsStack.Pop();
                            if (t == "(")
                                break;
                            outputLine.Enqueue(t);
                        }
                        break;
                    default:
                        throw new Exception($"\" {ch} \" <- is not a number or operator");
                }
            }
            while (operatorsStack.Count > 0)
                outputLine.Enqueue(operatorsStack.Pop());
            return outputLine;
        }
        private static string StringToCorrectString(string expression)
        {
            expression = expression.Replace(" ", "");
            expression = expression.Replace("-", " - ");
            for (int i = expression.IndexOf('-'); i < expression.Length; i++)
            {
                if (i > 1)
                {
                    if (expression[i] == '-' && !"1234567890".Any(x => expression[i - 2] == x))
                    {
                        expression = expression.Remove(i + 1, 1);
                    }
                }
                else if (i >= 0)
                    expression = expression.Remove(i + 1, 1);
                else break;
            }
            expression = expression.Replace("+", " + ");
            expression = expression.Replace("*", " * ");
            expression = expression.Replace("/", " / ");
            expression = expression.Replace("(", " ( ");
            expression = expression.Replace(")", " ) ");
            return expression;
        }
        private static bool IsCorrectBrackets(string expression)
        {
            int count = 0;
            foreach (var c in expression)
            {
                if (c == '(')
                {
                    count++;
                    continue;
                }
                if (c == ')')
                {
                    count--;
                    continue;
                }
            }
            return count == 0;
        }
    }
}
