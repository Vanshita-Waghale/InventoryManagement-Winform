using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppListandConstructor
{
    internal class StudentFunctions
    {

        public StudentFunctions()       //constructor
        {
            DefaultStudentData();    //comment to not show what is been running in the parameterized 
            GetAllStudents();

        }

        public StudentFunctions(int id, string name, string classname)
        {
            students.Add(new Student()
            {
                Id = id,
                Name = name,
                Class = classname
            });
        }


        public StudentFunctions(Student sobj)
        {
            students.Add(sobj);
        }


        public static List<Student> students = new List<Student>();

        public static void DefaultStudentData()
        {
            Student s = new Student();
            s.Id = 1;
            s.Name = "Aditi";
            s.Class = "10th";
            //  students.Add(s);            //both are same   //students.Add(new Student { Id =1 , Name = "Rahul" , Class="5th"}  );



            students.Add(new Student { Id = 1, Name = "Rahul", Class = "5th" });   // both are same as students.Add(s);   
            students.Add(new Student { Id = 2, Name = "Bulbul", Class = "10th" });
        }
        public static void GetAllStudents()
        {
            Console.Clear();
            foreach (Student sobj in students)

            {
                Console.WriteLine(sobj.Id + " : " + sobj.Name + " : " + sobj.Class);

            }


        }









    }

}