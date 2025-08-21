using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("enter first number : ");
            //int a = Convert.ToInt32(Console.ReadLine());

            //Console.Write("enter first number : ");
            //int b = Convert.ToInt32(Console.ReadLine());

            //   int  c= a + b;
            //    Console.WriteLine("addition is :" + c);

           // Console.WriteLine("addition");
            Calculation.AddNumbers(3,5);

            //Calculation obj = new Calculation();   //if not static create an object



            // Console.WriteLine("multiplication");

            Calculation.MultiplyNumbers(3,5);
            Calculation.DivideNumbers(8, 4);
            Calculation.SubtractionNumbers(12, 4);



            Console.Read();

        }
        //public  static void AddNumbers()
        //{
        //    Console.Write("enter first number : ");
        //    int a = Convert.ToInt32(Console.ReadLine());

        //    Console.Write("enter first number : ");
        //    int b = Convert.ToInt32(Console.ReadLine());

        //    int c = a + b;
        //    Console.WriteLine("addition is :" + c);
        //}

    }
}
