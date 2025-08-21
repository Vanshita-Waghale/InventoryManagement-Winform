using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppArrays
{
    internal class ArrayClass
    {
        //public static void PrintUserinfo()
        //{
        //    int[] Ids = { 1, 2, 3 };
        //    string[] Names = { "Amar", "Ajay", "Kamal" };

        //    string firstUser = Ids[1] + ":" + Names[1];
        //    Console.WriteLine(firstUser);
        //    Console.WriteLine("{0} : {0} ", Ids[2], Names[2]);
        //}
        public static void PrintDynamicDataUserInfo()
        {
            int[] Ids = new int[3];
            string[] Names = new string[3];

            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine("Enter Rollno:");
                Ids[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name:");
                Names[i] = Console.ReadLine();

            }
            Console.WriteLine("=========user data ===================");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0} : {1} ", Ids[i], Names[i]);
            }
            Console.Read();

        }
    }
}
