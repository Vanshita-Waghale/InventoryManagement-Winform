using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2Inheritance
{
    internal class Student : BaseClass
    {
        public string Class { get; set; }
        public int Age { get; set; }

        public override void GetMessage()
        {
            Console.WriteLine("Derived class : Student");
        }
    }

    internal class Employee : BaseClass
    {
        public string Designation { get; set; } = "Manager";
        public int Age { get; set; } = 25;

        public String EmailID { get; set; }
    }
}