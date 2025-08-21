using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryMathCalculation;

namespace ConsoleAppLibraryUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation obj = new Calculation();
            obj.Addition();
            Console.Read();
        }
    }
}
