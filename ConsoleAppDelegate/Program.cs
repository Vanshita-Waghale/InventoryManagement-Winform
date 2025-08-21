using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDelegate
{
    // here we have made a delegate using delegate 
    //internal class Program
    //{
    //    delegate void DemoDelegate(string name);
    //    public static void ShowMessage(string name)
    //    {
    //        Console.WriteLine(name + " : Delegate function called");
    //    }


    //    delegate int AddNumberDelegate(int a, int b);

    //    public static int AddNumber(int a, int b)
    //    {
    //        return a + b;
    //    }


    //    static void Main(string[] args)

    //    {
    //        DemoDelegate d1 = new DemoDelegate(ShowMessage);
    //        d1("CDAC");

    //        AddNumberDelegate d2 = new AddNumberDelegate(AddNumber);
    //        int result = (d2(2, 5));
    //        Console.WriteLine(result);
    //        Console.Read();
    //    }

    //C# given generic delegates 
    //public static int AddNumber(int a, int b)
    //{
    //    return a + b;
    //}
    //static void Main(string[] args)
    //{

    // Func<int, int, int> fD = AddNumber;
    //    Console.WriteLine("First Number : ");
    //    int a= Convert.ToInt32(Console.ReadLine());

    //    Console.WriteLine("Second Number : ");
    //    int b = Convert.ToInt32(Console.ReadLine());

    //    int result = fD(a, b);
    //    Console.WriteLine(result);
    //    Console.Read();

    //Action Delegate
    internal class Program
    {
        //public static void AddNumber(int a, int b)
        //{
        //    Console.WriteLine(a + b);

        //}
        //static void Main(string[] args)
        //{
        //    Func<int, int> fD = AddNumber;
        //    Console.WriteLine("First Number : ");
        //    int a = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Second Number : ");
        //    int b = Convert.ToInt32(Console.ReadLine());
        //    fD(a, b);
        //    Console.Read();
        //}

        //Predicate delegate returns boolean type 
        public static bool IsAdmin(string username)
        {
            if (username == "admin" || username == "Admin")
                return true;
            else 
                return false;

        }
        static void Main(string[] args)
        {
            Predicate<string> pD = IsAdmin;
            Console.WriteLine("Enter name : ");
            string name = Console.ReadLine();
            Console.WriteLine(pD(name));
        }

    }
}
