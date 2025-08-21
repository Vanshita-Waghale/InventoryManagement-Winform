using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppArrays
{
    internal class PropertyExample
    {
        //public static void PrintStaticDataFromProperty()
        //{
        //    Student s = new Student();
        //    s.Id = 1;
        //    s.Name = "Amar";
        //    s.Class = "5th";

        //    Student s1 = new Student();
        //    s1.Id = 2;
        //    s1.Name = "Nina";
        //    s1.Class = "6th";

        //    Console.Write("Id-{0} : Name-{1} : Class-{2}", s.Id, s.Name, s.Class);
        //    Console.Write("Id-{0} : Name-{1} : Class-{2}", s1.Id, s1.Name, s1.Class);
        //}


        //public static void PrintStaticDataFromClassList()
        //{
            
        //    Student s = new Student();
        //    s.Id = 1;
        //    s.Name = "Amar";
        //    s.Class = "5th";
        //    stud.Add(s);

        //    Student s1 = new Student();
        //    s1.Id = 2;
        //    s1.Name = "Nina";
        //    s1.Class = "6th";
        //    stud.Add(s1);

        //    foreach (Student sObj in stud)
        //    {
        //        Console.WriteLine(sObj.Id + ":" + sObj.Name + ":" + sObj.Class);
        //    }

        //}
        List<Student> stud = new List<Student>();
        public static void AddStudent()
        {
                Console.Clear();
                Student s = new Student();
                Console.WriteLine("Enter Rollno:");
                s.Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name:");
                s.Name = Console.ReadLine();

                Console.WriteLine("Enter Class:");
                s.Class = Console.ReadLine();

                stud.Add(s);
            }

        public static void GetAllStudents()
        {
            Console.WriteLine("\n Details of all Students: ");
            foreach (Student s in stud)
            {
                Console.WriteLine("ID:" + s.Id + ",Name:" + s.Name + ",Class:" + s.Class);
            }

        }


        public static void PrintDynamicDataFromClassList()
        {
            List<Student> stud = new List<Student>();
            Console.WriteLine("Enter Number of Students");
            int n  = Convert.ToInt32(Console.ReadLine());
             
            for (int i= 0; i<n; i++)
            {
                Student s = new Student();
                Console.WriteLine("Enter Rollno:");
                s.Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name:");
                s.Name = Console.ReadLine();

                Console.WriteLine("Enter Class:");
                s.Class = Console.ReadLine();

                stud.Add(s);
            }

            Console.WriteLine("\n Details of all Students: ");
            foreach (Student s in stud)
            {
                Console.WriteLine("ID:" + s.Id + ",Name:"+ s.Name + ",Class:"+ s.Class);            }

            }


    }
        public class Student
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string Class { get; set; }

        }
 }


