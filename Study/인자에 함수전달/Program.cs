using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 인자에_함수전달
{
    class Product
    {
        private Func<int, int> exp;
        public int CalcPrice(int basePrice)
        {
            return exp(basePrice);
        }
        public Product(Func<int,int> exp)
        {
            this.exp = exp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new 인자에_함수전달.Product(n => n * 8 / 10);
            Console.WriteLine(p.CalcPrice(100));
            Console.ReadLine();
        }
    }
}
