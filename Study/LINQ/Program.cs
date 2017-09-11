using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Item
    {
        public int price { get; protected set; }
    }
    class Potato : Item
    {
        public Potato()
        {
            price = 100;
        }
    }

    class Hamburger : Item
    {
        public Hamburger()
        {
            price = 300;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> PurchaseList = new List<Item>();
            int money = 500;
            PurchaseList.Add(new Hamburger());
            Console.WriteLine("감자도 같이 사세요");

            if (money >= 400)
            {
                var potato = new Potato();
                PurchaseList.Add(potato);
            }
            Console.WriteLine("구입한 물건은 {0}개 입니다.", PurchaseList.Count());
            Console.WriteLine("총 금액은 {0}원 입니다.", PurchaseList.Select(c => c.price).Sum());

            if(PurchaseList.Any(c => c is Potato))
            {
                Console.WriteLine("감자를 산 손님께는 미소를 드립니다. 방긋");
            }

            Console.ReadLine();
        }
    }
}
