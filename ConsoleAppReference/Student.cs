using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppReference
{
    internal class Student
    {
        public Student()
            {
            Console.WriteLine("Constructor is called");
        }
        ~Student()
        {
            Console.WriteLine("Destructor is called");
        }
    }
}
