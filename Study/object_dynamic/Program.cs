using System;

namespace object_dynamic
{
    class A
    {
        public void SayIt()
        {
            Console.WriteLine("Hello!");
        }
    }

    class B
    {
        public void SayIt()
        {
            Console.WriteLine("Welcome!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //object[] ar = { new A(), new B() };
            //foreach (object item in ar)
            //{
            //    if (item is A) ((A)item).SayIt();
            //    else if (item is B) ((B)item).SayIt();
            //    else throw new NotSupportedException();
            //}


            dynamic[] ar = { new A(), new B() };
            foreach (dynamic item in ar)
            {
                item.SayIt();
            }

            Console.ReadLine();
        }
    }
}
