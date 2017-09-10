using System;

namespace 배열연습
{
    class Program
    {
        static void Main()
        {
            int a,b,c,d,e,f,g,h,i,j;
            int sum;
            
            a = 1;
            b = 2;
            c = 3;
            d = 4;
            e = 5;
            f = 6;
            g = 7;
            h = 8;
            i = 9;
            j = 10;

            sum = a + b + c + d + e + f + g + h + i + j;
            
            Console.WriteLine(sum);



            int[] v = new int[100];
            int hap = 0;
            
            for (int k = 0; k < v.Length; k++)
            {
                v[k] = k + 1;
                hap = hap + v[k];
            }

            Console.WriteLine(hap);




            Console.ReadLine();
        }
    }
}
