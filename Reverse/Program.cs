using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse
{
    internal class Program
    {
        static void Main()
        {
            string sstr, revstr = "";
            Console.WriteLine("Enter a string to reverse: ");
            sstr = Console.ReadLine();
            for (int i = sstr.Length - 1; i >= 0; i--)
            {
                revstr += sstr[i];
            }
            Console.WriteLine("Reversed string is: " + revstr);
        }
    }
}
