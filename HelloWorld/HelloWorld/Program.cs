namespace KIM
{
    class KM
    {
        static void Main()
        {
            /*
            System.Console.WriteLine("Hello World!!");
            string s1 = System.Console.ReadLine();
            string s2 = System.Console.ReadLine();
            string s3 = System.Console.ReadLine();

            string s = s1 + " " + s2 + " " + s3;

            System.Console.Write(s);
            System.Console.ReadLine();
            */

            System.Console.WriteLine("더하기 연습");
            System.Console.WriteLine("===============");
            
            string s1 = System.Console.ReadLine();
            string s2 = System.Console.ReadLine();

            int i1 = int.Parse(s1);
            int i2 = int.Parse(s2);
            int i = i1 + i2;

            System.Console.Write(i);
            System.Console.ReadLine();

        }
    }
}
