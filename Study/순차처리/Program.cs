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
            Task.Delay(1000).ContinueWith((dummy) =>
            {
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

            Console.WriteLine("엔터키를 누르면 종료합니다.");
            Console.ReadLine();
        }
    }
}