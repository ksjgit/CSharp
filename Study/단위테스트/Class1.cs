namespace ClassLibrary1
{
    public class TempValue
    {
        public static int N = 0;
    }

    public class Class1
    {
        public int Met1() { return TempValue.N++; }
        public int Met2() { return TempValue.N++; }
        public int Met3() { return TempValue.N++; }
    }
}
