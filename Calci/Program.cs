using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator:");
            Console.WriteLine("Enter first argument /number:");
            string Arg1 = Console.ReadLine();
            Console.WriteLine("Enter second argument /number:");
            string Arg2 = Console.ReadLine();

            int intArg1= int.Parse(Arg1);
            int intArg2 = int.Parse(Arg2);

            int Add = intArg1 + intArg2;
            int Sub = intArg1 - intArg2;
            int Mul = intArg1 * intArg2;
            int Div = intArg1 / intArg2;



            Console.WriteLine("The result of addition is: " + Add);
            Console.WriteLine($"Result of Substraction is {Sub}");
            Console.WriteLine($"Result of Multiplication is {Mul}");
            Console.WriteLine($"Result of Division is {Div}");
            Console.Read();

        }
    }
}
