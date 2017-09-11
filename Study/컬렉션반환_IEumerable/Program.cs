using System;
using System.Collections.Generic;
using System.Linq;

namespace 컬렉션반환_IEumerable
{
    class Program
    {
        //private static List<int> searchItems(Func<int, bool> checkCondition)
        private static IEnumerable<int> searchItems(Func<int, bool> checkCondition)
        {
            int[] array = { 1, 2, 3 };
            var list = new List<int>();

            foreach (var item in array)
            {
                if (checkCondition(item)) list.Add(item);
            }

            return list;
        }
        static void Main(string[] args)
        {
            var r = searchItems((n) => n >= 2);
            //r.RemoveAt(1);
            Console.WriteLine("결과는 {0}개 입니다.", r.Count<int>());
            Console.ReadLine();
        }
    }
}
