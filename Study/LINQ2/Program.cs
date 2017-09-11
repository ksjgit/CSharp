using System;
using System.Linq;

namespace LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ar = { 5, 2, -1, 1, 4 };
            int[] arWithoutMinus = ar.Where(c => c >= 0).ToArray();

            //Console.WriteLine("결과 : {0}", arWithoutMinus.Sum());

            Console.WriteLine("결과 : {0}", arWithoutMinus.Select((n, i) => new Tuple<int, int>(n, i)).Aggregate((sum, next) =>
               {
                   var r = sum.Item1 + next.Item1;
                   Console.WriteLine("{0}번째 처리. 현재 합계 {1}", next.Item2, r);
                   return new Tuple<int, int>(r, next.Item2);
               }).Item1);
            
            Console.ReadLine();
        }
    }
}
