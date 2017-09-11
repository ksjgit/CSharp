using System;
using System.Linq;

namespace 형변환
{
    class Base
    {
    }

    class Extended : Base
    {
        public void SayIt()
        {
            Console.WriteLine("I am Extended!!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Base[] array = { new Base(), new Extended()};


            //1차
            //foreach (var item in array)
            //{
            //    if (item is Extended)
            //    {
            //        ((Extended)item).SayIt();
            //        Console.ReadLine();
            //    }
            //}

            //2차
            //foreach (var item in array)
            //{
            //    var extended = item as Extended;
            //    if (extended != null)
            //    {
            //        extended.SayIt();
            //        Console.ReadLine();
            //    }
            //}

            foreach (var item in array.OfType<Extended>())
            {
                item.SayIt();
                Console.ReadLine();
            }
        }
    }
}
