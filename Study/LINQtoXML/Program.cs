using System;
using System.Linq;
using System.Xml.Linq;

namespace LINQtoXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "<root><a/><a/><a/><b/><a/><c/></root>";
            var doc = XDocument.Parse(s);
            var elements = doc.Descendants("a");

            Console.WriteLine("a요소는 {0}개 입니다.", elements.Count());
            Console.ReadLine();
        }
    }
}
