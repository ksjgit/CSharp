using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ7_긴쿼리
{
    class Program
    {
        private static void dump<T>(string label, IEnumerable<T> en)
        {
            Console.Write(label + ": ");
            foreach (var item in en) Console.Write(item);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            object[] ar = { 5,3,2,4,1, "Hello!" };

            //var ar2 = ar.OfType<int>().Where(c => c >= 2).OrderBy(c => c).Skip(1).Take(2).Select(c => c.ToString("C")).Reverse().ToArray();
            //foreach (var item in ar2)
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerable<int> q1 = ar.OfType<int>();
            //dump("q1", q1);
            //var q2 = q1.Where(c => c >= 2);
            //dump("q2", q2);
            //var q3 = q2.OrderBy(c => c);
            //dump("q3", q3);
            //var q4 = q3.Skip(1);
            //dump("q4", q4);
            //var q5 = q4.Take(2);
            //dump("q5", q5);
            //var q6 = q5.Select(c => c.ToString("C"));
            //dump("q6", q6);
            //var q7 = q6.Reverse();
            //dump("q7", q7);
            //var q8 = q7.ToArray();
            //foreach (var item in q8)
            //{
            //    Console.WriteLine(item);
            //}

            var ar2 = ar.OfType<int>()
                .Where(c => c >= 2)
                .OrderBy(c => c)
                .Skip(1)
                .Take(2)
                .Select(c => c.ToString("C"))
                .Reverse()
                .ToArray();
            foreach (var item in ar2)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
