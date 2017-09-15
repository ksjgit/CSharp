using System;
using System.Threading.Tasks;

namespace 병렬처리
{
    class Program
    {
        private static void work(int n, int wait)
        {
            Task.Delay(1000 * wait).Wait();
            Console.WriteLine("Task{0} Done", n);
        }
        static void Main(string[] args)
        {
            //var t1 = Task.Run(() => { work(1, 2); });
            //var t2 = Task.Run(() => { work(2, 3); });
            //var t3 = Task.Run(() => { work(3, 5); });
            //var t4 = Task.Run(() => { work(4, 1); });

            //for(;;)
            //{
            //    if (t1.IsCompleted && t2.IsCompleted && t3.IsCompleted && t4.IsCompleted) break;
            //    Task.Delay(100).Wait();
            //    Console.WriteLine("Waiting...");
            //}

            //Task.WaitAny(t1);
            //Task.WaitAll(t1, t2, t3, t4);

            Parallel.Invoke(
                () => { work(1, 2); },
                () => { work(2, 3); },
                () => { work(3, 5); },
                () => { work(4, 1); }
                );

            Console.WriteLine("All Done");
            Console.ReadLine();
        }
    }
}
