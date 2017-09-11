using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 생성자_Create
{
    class Animal
    {
        public static Animal Create()
        {
            return new Animal();
        }
        public void SitDown()
        {
            Console.WriteLine("멍멍!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dog = Animal.Create();
            dog.SitDown();

            Console.ReadLine();
        }
    }
}
