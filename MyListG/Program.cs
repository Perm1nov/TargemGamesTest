using System;

namespace MyList
{
    class Program
    {
        public static void Main(string[] args)
        {
            MyList<double> list = new MyList<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Console.WriteLine(list.Count);
            list.RemoveAt(5);
            list.RemoveAt(5);
            list.RemoveAt(5);
            list.RemoveAt(5);
            list.Insert(0, );
            Console.WriteLine(list.Contains(2.0));
            Console.WriteLine(list.Contains(1.0));
            Console.WriteLine(list.Contains(1.1));
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }
        }
    }
}