using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse
{
    internal class Swap
    {
        static void Main()
        {
            int a = 5, b = 10;

            a += b;  // same as a = a + b
            b = a - b;
            a -= b;  // same as a = a - b

            Console.WriteLine("After swapping: a = " + a + ", b = " + b);
        }
    }
}