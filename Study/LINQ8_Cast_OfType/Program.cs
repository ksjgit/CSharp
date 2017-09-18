using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ8_Cast_OfType
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] ar = { 1, 2, 3, "ABC" };

            //Console.WriteLine(ar.Select(c => (int)c).Sum());

            //var q = ar.Cast<int>();
            //Console.WriteLine(q.Sum());

            var q = ar.OfType<int>();
            Console.WriteLine(q.Sum());

            Console.ReadLine();
        }
    }
}
