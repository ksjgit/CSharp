using System;
using System.Runtime.InteropServices;

namespace WinAPI호출
{
    class Program
    {
        [DllImport("kernel32.dll")]
        extern static bool Beep(uint dwFreq, uint dwDuration);
        static void Main(string[] args)
        {
            Beep(1000, 1000);
        }
    }
}
