using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryMathCalculation
{
    public class Calculation
    {
        public void Addition()
        {
            Console.WriteLine("Addition Program");
            Console.WriteLine("Enter First number: ");
            // Below line is used to read the number from command prompt ,&then convert 
            int fn = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int sn= Convert.ToInt32(Console.ReadLine());

            int r = fn + sn;
            Console.WriteLine("Result:" + r);       
        }
    }
}
