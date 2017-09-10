using System;

namespace 포인터사용
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            for (int j = 0; j < 10000; j++)
            {
                //배열사용
                //var ar = new byte[100000];
                //ar[ar.Length - 1] = (byte)(j + 1);

                //for (int i = 0; i < ar.Length; i++)
                //{
                //    if (ar[i] != 0) Console.WriteLine("Found number is {0}", ar[i]);
                //}

                //포인터 사용 <-- 프로젝트 속성에서 어셈블리 코드실행 허용해야함.
                unsafe
                {
                    var ar = new byte[100000];
                    ar[ar.Length - 1] = (byte)(j + 1);

                    fixed (byte* ps = ar)
                    {
                        byte* p = ps;
                        for (int i = 0; i < ar.Length; i++)
                        {
                            if(*p != 0) Console.WriteLine("Found number is {0}", *p);
                            p++;
                        }
                    }
                }
            }

            Console.WriteLine(DateTime.Now - start);
            Console.ReadLine();
        }
    }
}
