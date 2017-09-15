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
            File.Delete("sample.text");
            Task.Run(() =>
            {
                try
                {
                    Task.Delay(1000);
                    Console.WriteLine(File.ReadAllText("sample.text"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
            Thread.Sleep(500);
            File.WriteAllText("sample.text", "Hello!");

            Console.WriteLine("엔터키를 누르면 종료합니다.");
            Console.ReadLine();
        }
    }
}