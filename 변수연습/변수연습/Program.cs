using System;

namespace 변수연습
{
    class Program
    {
        static void Main()
        {
            //int a;
            //int b;
            //int c;
            int a, b, c;
            
            a = 1;
            b = 2;
            c = a + b;

            Console.WriteLine(c);



            char ch_a, ch_b;

            ch_a = '강';
            ch_b = '민';
            Console.WriteLine(ch_a);
            Console.WriteLine(ch_b);
            Console.Write(ch_a);
            Console.Write(ch_b);

            Console.WriteLine();

            

            string str_a, str_b, str_c;

            str_a = "강민";
            str_b = "준민";
            str_c = str_a + "    " + str_b;
            Console.WriteLine(str_c);

            Console.WriteLine("------------------");

            
            Console.ReadLine();

            



        }
        
    }
}
