using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //ArrayClass.PrintUserinfo();
            //ArrayClass.PrintDynamicDataUserInfo();

            //PropertyExample.PrintStaticDataFromProperty();
            //PropertyExample.PrintStaticDataFromClassList();
            //PropertyExample.PrintDynamicDataFromClassList();

            Console.WriteLine("1. Add number");
            Console.WriteLine("2. Get All students");
            Console.WriteLine("3. Exit");

            Console.Write("Enter Selection: ")
                int ch = Convert.ToInt32(Console.ReadLine());
            Console.Write("");
            switch (ch)
            {
                case 1:
                    PropertyExample.AddStudent();
                    break;

                case 2:
                    PropertyExample.GetAllStudents();  
                    break;
                case 3:
                    break;
                    default:
                    Console.WriteLine("wrong selection");
                    break;
            }

            Console.WriteLine("Enter the option");

            Console.Read();
        }

    }
}
