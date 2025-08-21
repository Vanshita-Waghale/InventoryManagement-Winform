using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUserinfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter Name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine("Enter Roll-No :");
            //int rollNo= Convert.ToInt32(Console.ReadLine());
            //Console.Clear();
            //Console.WriteLine("Welcome :" + name);
            //Console.WriteLine("Your Roll no. is :" + rollNo);
            ////// Display text without indexing
            //// Console.WriteLine("Welcome!" + name +". Your roll number is: " + rollNo);

            ////// Display text with indexing
            //Console.WriteLine("Welcome! {0}. Your roll number is {1}", name, rollNo);
            //Console.ReadLine();





            ////Switch Case
            SwitchCaseProgram:
            Console.WriteLine("Options to Choose");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide1");
            Console.WriteLine("5. Exit/End Program");

            Console.WriteLine("Enter your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());

            //if (choice == 5)
            //{
            //    Console.Clear();
            //    Console.Read();

            //}

            int a = 0;
            int b = 0;
            if (choice <=4)
            { 

                Console.WriteLine("Enter First No :");
             a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ente Second No :");
             b = Convert.ToInt32(Console.ReadLine());

            }

            int result = 0;
            switch (choice)
            {
                case 1:
                    result = a + b;
                    break;
                case 2:
                    result = a - b;
                    break;
                case 3:
                    result = a * b;
                    break;
                case 4:
                    result = a / b;
                    break;
                //case 5:

                //    Console.Clear();
                //    Console.Read();
                //    break;

                default:
                    Console.WriteLine("Invalid Selection..");
                    break;
            }
           
        if(choice <= 4)
            {
            Console.WriteLine("Result is : " +result);
            }

            goto SwitchCaseProgram;
            Console.ReadLine(); // to  hold the screen
        }
    }
}
