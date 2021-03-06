﻿using System;
using System.Collections.Generic;

namespace StringCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            while (true)
            {
                Console.Write("Enter expression : ");
                var inpuLine = Console.ReadLine();

                double? result;
                try
                {
                    result = calculator.Calculate(inpuLine);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Expression is incorrect");
                    /* Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);*/
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    /*Console.WriteLine(e.StackTrace);*/
                    continue;
                }

                if (result is null)
                {
                    Console.WriteLine("Expression is incorrect");
                    continue;
                }
                Console.WriteLine(result == double.PositiveInfinity ? "infinty" : result);
            }
        }
    }
}
