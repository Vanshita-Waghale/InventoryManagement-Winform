using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalciIfElse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your choice: 1-Add ,2-Subtract, 3-Multiply, 4-Division");
            string strChoice = Console.ReadLine();

            Console.Write("Arg 1: ");
            string strArg1 = Console.ReadLine();

            Console.Write("Arg 2: ");
            string strArg2 = Console.ReadLine();

            int intArg1 = int.Parse(strArg1);
            int intArg2 = int.Parse(strArg2);
            int intResult = 0;

            if (strChoice == "1")
            {
                intResult = intArg1 + intArg2;
            }
            if (strChoice == "2")
            {
                intResult = intArg1 - intArg2;
            }
            if (strChoice == "3")
            {
                intResult = intArg1 * intArg2;
            }
            if (strChoice == "4")
            {
                if (intArg2 != 0)
                {
                    intResult = intArg1 / intArg2;
                }
                else
                {
                    Console.WriteLine("Division by zero is not allowed.");
                    return; // Exit the program if division by zero is attempted
                }
            }

            if(strChoice != "1" && strChoice != "2" && strChoice != "3" && strChoice != "4")
            {
                Console.WriteLine("Invalid choice. Please select a valid operation.");
            }
            else
            {
                Console.WriteLine($"The result is: {intResult}");
            }

            Console.ReadLine(); // Keep the console window open until a key is pressed
        }
    }
}
