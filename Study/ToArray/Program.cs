using System;
using System.Linq;

namespace ToArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            //var ar = Enumerable.Range(0, 100000);
            var ar = Enumerable.Range(0, 100000).ToArray();
            int sum = 0;
            for (int i = 0; i < ar.Count(); i++)
            {
                sum = sum / 2 + ar.ElementAt(i);
            }

            Console.WriteLine(sum);
            Console.WriteLine(DateTime.Now - start);

            Console.ReadLine();
        }
    }
}
