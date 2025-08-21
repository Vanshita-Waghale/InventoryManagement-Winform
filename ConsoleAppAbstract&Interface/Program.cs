


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAbstractAndInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DerivedClass oDerived = new DerivedClass();
            int ad = oDerived.Add(4, 10);   //14
            Console.WriteLine("Addition  is: " + ad);


            Console.WriteLine("Multiplication is: " + oDerived.Multiply(4, 10));     //4

            //CustomAbstractClass custom = new CustomAbstractClass(); ;
            //object cannot be made of abstract


            //ICalculator oCal = new ICalculator();
            // cannot create an object

            Console.WriteLine("Substraction  is: " + oDerived.Substract(4, 10));
            Console.WriteLine("Division is: " + oDerived.Divide(10, 2));



            Console.Read();
        }
    }
}