using System;
using System.IO;
// http://hungryfox.tistory.com/entry/C-IDisposable-%EC%9D%B8%ED%84%B0%ED%8E%98%EC%9D%B4%EC%8A%A4%EC%99%80-using-%ED%82%A4%EC%9B%8C%EB%93%9C 참조
namespace using_IDisposable
{
    class CWC : IDisposable
    {
        private TextWriter writer = null;
        public void Create()
        {
            writer = File.CreateText("sample.txt");
        }
        public void Close()
        {
            Dispose();
        }
        public void Write()
        {
            throw new ApplicationException("Sample Exception");
        }
        public void Dispose()
        {
            if (writer != null) writer.Close();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var cwc = new CWC()) //using 나오면 자동으로 Dispose 호출함..
                {
                    cwc.Create();
                    cwc.Write();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
