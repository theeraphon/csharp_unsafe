using System;

namespace Unsafe_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            string a, b = "";
            a = "Test";
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            unsafe
            {
                fixed (char* sPnt = a, dPnt = b)
                {
                    Copy(sPnt, dPnt);
                    b = new string(dPnt);
                }
            }
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
        }

        private static unsafe void Copy(char* src, char* dest)
        {
            char* t = dest;
            while (*src != 0)
            {
                *t = *src;
                src++;
                t++;
            }

        }
    }
}
