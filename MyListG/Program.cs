using System;
using System.Collections.Generic;

namespace MyList
{
    class Program
    {
        public static void Main(string[] args)
        {
            var list = new MyList<double>() { 1, 2, 3, 4, 5, 6 };
            list.Add(1);
            Console.WriteLine(list.Count);
            list.Add(2);
            var array = new double[10];
            //list.RemoveAt(0);
            list.CopyTo(array, 2);
            Console.WriteLine(list.Contains(2.0));
            Console.WriteLine(list.Contains(1.0));
            Console.WriteLine(list.Contains(1.1));
            Console.WriteLine(Convert.ToInt32("100*2-5"));
            Console.WriteLine;
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }
        }
    }
}