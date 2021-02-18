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
            var calculationStack = new Stack<double>();
            while (expressionAsRPN.Count > 0)
            {
                var operatorOrNumber = expressionAsRPN.Dequeue();
                switch (operatorOrNumber)
                {
                    case "+": calculationStack.Push(calculationStack.Pop() + calculationStack.Pop()); break;
                    case "-":
                        var b = calculationStack.Pop();
                        var a = calculationStack.Pop();
                        calculationStack.Push(a - b); break;
                    case "*": calculationStack.Push(calculationStack.Pop() * calculationStack.Pop()); break;
                    case "/":
                        var b1 = calculationStack.Pop();
                        var a1 = calculationStack.Pop();
                        calculationStack.Push(a1 / b1); break;
                    default: calculationStack.Push(double.Parse(operatorOrNumber, CultureInfo.InvariantCulture)); break;
                }
            }
            if(calculationStack.Count>1)
                return null;
            if (calculationStack.TryPop(out double x))
                return x;
            return null;
        }


    }
}
