using System;
using System.Linq;

namespace 병렬처리
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ar = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            ar.AsParallel().ForAll(c => { Console.WriteLine(c); });
            Console.ReadLine();
        }
    }
}
