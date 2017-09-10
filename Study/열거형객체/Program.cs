using System;
using System.Collections.Generic;
using System.Linq;


namespace 열거형객체
{
    class SimpleSum
    {
        public Func<int> GetSum;

        public SimpleSum(int max)
        {
            IEnumerable<int> enumAll = Enumerable.Range(0, max);
            GetSum = () =>
            {
                return enumAll.Sum();
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<SimpleSum>();
            for (int i = 0; i < 100000; i++)
            {
                list.Add(new SimpleSum(100000));
            }
        }
    }
}
