using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//startup project is set as bold in the solution explorer 
//and when we right click on solution explorer file and select set as solution explorer.

namespace ConsoleApp_DAY1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello world");//shortcut f5 to get output in terminal
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "How are you");
            Console.Read();

        }
    }
}