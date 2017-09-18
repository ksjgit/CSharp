using System;
using System.Linq;

namespace LINQ4_FirstOrDefault
{
    class Program
    {
        static void Main(string[] args)
        {
            for(;;)
            {
                var s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) return;
                //Console.WriteLine("이름의 첫 번째 글자는 {0}입니다.", s.First());
                //Console.WriteLine("이름의 첫 번째 글자는 {0}입니다.", s.First(c => char.IsNumber(c)));
                Console.WriteLine("첫 번째 숫자는 {0}입니다.", s.FirstOrDefault(c => char.IsNumber(c)));
            }
        }
    }
}
