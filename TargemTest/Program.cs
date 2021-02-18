using System;
using System.Collections.Generic;

namespace StringCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            while (true)
            {
                Console.Write("Enter expression : ");
                var inpuStr = Console.ReadLine();
/*                if (String.IsNullOrEmpty(inpuStr))
                {
                    Console.WriteLine("String is null or empty");
                    continue;
                }*/
                double? result = null;
                try
                {
                    result = calc.Calculate(inpuStr);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Expression is incorrect");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    continue;
                }

                if(result == null)
                    continue;
                Console.WriteLine(result == double.PositiveInfinity ? "infinty": result);
            }
        }
    }
}
