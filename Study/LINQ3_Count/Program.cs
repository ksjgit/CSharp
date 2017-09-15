using System;
using System.Linq;

namespace LINQ3_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] winners = { 2, 1, 5, 3, 5 };
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("등번호 {0}번", i);
                if (winners.Contains(i))
                    Console.WriteLine("우승했기 때문에 상금 {0}원 수여", winners.Count(c => c == i) * 1000000);
                else
                    Console.WriteLine("상금 없음");
            }
             
            Console.ReadLine();
        }
    }
}
