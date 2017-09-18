using System;
using System.Linq;

namespace LINQ6_OrderBy_Sort
{
    class Program
    {
        private static void sortAndOutput(int[] ar)
        {
            //Array.Sort(ar);
            //foreach (var item in ar) Console.WriteLine(item);

            //foreach (var item in ar.OrderBy(c=>c)) Console.WriteLine(item);

            //var q = ar.OrderBy(c => c);
            //foreach (var item in q) Console.WriteLine(item);
            //Console.WriteLine();
            //Console.WriteLine("{0}개 항목이 있습니다.", q.Count());

            Array.Sort(ar);
            foreach (var item in ar) Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("{0}개 항목이 있습니다.", ar.Count());
        }
        static void Main(string[] args)
        {
            int[] ar = { 3,5,1,2,4 };
            sortAndOutput(ar);

            Console.ReadLine();
        }
    }
}
