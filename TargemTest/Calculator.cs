using StringCalcRPN;
using System.Collections.Generic;
using System.Globalization;

namespace StringCalc
{
    class Calculator
    {
        public double? Calculate(string expression)
        {

            var expressionAsRPN = StringConverter.StringToRPN(expression);
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
                    default: calcStack.Push(double.Parse(t, CultureInfo.InvariantCulture)); break;
                }
            }
            if (calcStack.TryPop(out double x))
                return x;
            return null;
        }


    }
}
