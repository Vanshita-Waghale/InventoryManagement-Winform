using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student sObj = new Student();    
            Console.WriteLine("Student Default Data");
            Console.WriteLine(sObj.Id);
            Console.WriteLine(sObj.Status);
            Console.WriteLine(sObj.Age);
            sObj.GetMessage();

            Console.WriteLine(" Default Data");
            Employee eObj = new Employee();
            Console.WriteLine(eObj.Id);
            Console.WriteLine(eObj.Status);
            Console.WriteLine(eObj.Designation);
            Console.WriteLine(eObj.Age);
            eObj.GetMessage();



        }
    }
}
