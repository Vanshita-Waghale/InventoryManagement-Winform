using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConstructorChaining
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public string FLName { get; set; }

        public string MiddleName { get; set; }

        public Student() : this("Kapil","Sharma")
        {
            FirstName = "Ram";
            LastName = "Sharma";
        }

        public Student(string fn, string ln): this("kapil","vitthal","Sharma")
        {
            FLName = fn + " " + ln;
        }

        public Student(string fn, string md ,string ln)
        {
            FullName = fn + " " + md + " " + ln;
        }
    }
}
