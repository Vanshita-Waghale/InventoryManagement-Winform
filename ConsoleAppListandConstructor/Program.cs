using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppListandConstructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StudentFunctions cObj = new StudentFunctions(); //if this at the top then call the display function to ret the output

            //staic constructor with staic data
            StudentFunctions cObj1 = new StudentFunctions(1, "Bhumika", "21st");

            Student s = new Student();
            s.Id = 1;
            s.Name = "Amar";
            s.Class = "5th";
            //parametrize constructor call by passing class object
            StudentFunctions Obj = new StudentFunctions(s);
            StudentFunctions cObj = new StudentFunctions(); //default constructor calling
            //StudentFunctions.GetAllStudents();

            Console.Read();
        }
    }
}
