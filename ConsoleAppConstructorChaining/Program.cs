using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConstructorChaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student obj = new Student();
            Console.WriteLine("Friend Name : {0}", obj.FullName);
            Console.WriteLine("FLName: {0} ", obj.FLName);
            Console.WriteLine("Full Name: {0} {1} {2}", obj.FirstName, obj.MiddleName, obj.LastName);
            

            Student obj2;
            obj2 = obj;
            obj.FLName = "Amar Verma";

            Console.WriteLine("Object 2");
            Console.WriteLine("Name : {0} ", obj2.FLName);
            Console.WriteLine("Name : {0} ", obj.FLName);
            Console.ReadLine();

        }
    }
}
