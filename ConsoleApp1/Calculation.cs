using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Calculation
    {
        //new custom fn to add 2 numbers
        //addition function
         public static void AddNumbers(int a, int b)
        {
            //Console.Write("enter first number : ");
            //int a = Convert.ToInt32(Console.ReadLine());

            //Console.Write("enter first number : ");
            //int b = Convert.ToInt32(Console.ReadLine());

            int c = a + b;
            Console.WriteLine("addition is :" + c);
        }

        //multiplication   function
        public static void MultiplyNumbers(int a, int b)
        {
            //Console.Write("enter first number : ");
            //int a = Convert.ToInt32(Console.ReadLine());

            //Console.Write("enter first number : ");
            //int b = Convert.ToInt32(Console.ReadLine());

            int c = a * b;
            Console.WriteLine("multiplication is :" + c);
        }

        public static void DivideNumbers(int a, int b)
        {
            int c = a / b;
            Console.WriteLine("divide is :" + c);
        }

        public static void SubtractionNumbers(int a, int b)
        {
            int c = a - b;
            Console.WriteLine("Subtraction is :" + c);
        }

    }
}


