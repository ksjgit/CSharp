using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace 순차처리
{
    class Program
    {
        static void Main(string[] args)
        {
            var evt = new AutoResetEvent(false);
            File.Delete("sample.text");
            Task.Run(() =>
            {
                evt.WaitOne(); //WaitHandle 이 신호를 받을때까지 현재 스레드 차단
                try
                {
                    Console.WriteLine(File.ReadAllText("sample.text"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
            Task.Delay(500).Wait();
            File.WriteAllText("sample.text", "Hello!");
            evt.Set();

            Console.WriteLine("엔터키를 누르면 종료합니다.");
            Console.ReadLine();
        }
    }
}