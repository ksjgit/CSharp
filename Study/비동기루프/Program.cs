using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 비동기루프
{
    class Program
    {
        private static async Task countDown()
        {
            for (int i = 9; i >= 0; i--)
            {
                Console.WriteLine(i);
                await Task.Delay(1000);
            }
        }

        static void Main(string[] args)
        {
            var a = countDown();
            var b = countDown();
            Task.WaitAll(a, b);
        }
    }
}
