using StringCalcRPN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalc
{
    class Calculator
    {
        public string ErrorMessage { get; set; }
        public double? Calculate(string expression)
        {
            var expressionAsRPN = StringConverter.StringToRPN(expression);
            if (expressionAsRPN == null)
                throw new Exception("Check correctness of expression");
            var calcStack = new Stack<double>();
            while (expressionAsRPN.Count > 0)
            {
                var t = expressionAsRPN.Dequeue();
                switch (t)
                {
                    case "+": calcStack.Push(calcStack.Pop() + calcStack.Pop()); break;
                    case "-":
                        var b = calcStack.Pop();
                        var a = calcStack.Pop();
                        calcStack.Push(a - b); break;
                    case "*": calcStack.Push(calcStack.Pop() * calcStack.Pop()); break;
                    case "/":
                        var b1 = calcStack.Pop();
                        var a1 = calcStack.Pop();
                        calcStack.Push(a1 / b1); break;
                    default: calcStack.Push(double.Parse(t)); break;
                }
            }
            if (calcStack.TryPop(out double x))
            return x;
            return null;          
        }

        
    }
}
