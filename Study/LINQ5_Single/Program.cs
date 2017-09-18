using System;
using System.Linq;

namespace LINQ5_Single
{
    class Person
    {
        internal int Id;
        internal string Name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person[] ar =
            {
                new Person() {Id=1, Name="철수" },
                new Person() {Id=2, Name="영희" },
                new Person() {Id=3, Name="동희" },
                new Person() {Id=3, Name="숙자" }
            };
            int 당선자Id = 3;
            //Console.WriteLine("{0} 당선입니다.", ar.First(c => c.Id == 당선자Id).Name); //동희 당선, 숙자 무시
            Console.WriteLine("{0} 당선입니다.", ar.Single(c => c.Id == 당선자Id).Name); //예외발생 3번이 두명(동희, 숙자)

            Console.ReadLine();
        }
    }
}
