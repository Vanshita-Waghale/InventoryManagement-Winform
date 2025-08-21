using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalciSwitchCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result;
            Console.WriteLine("Enter the First Number:");

            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
            }
            while (true)
            {
                Console.WriteLine("\nChoose operation:");
                Console.WriteLine("1-Add | 2-Subtract | 3-Multiply | 4-Division | 5-Exit");
                string Choice = Console.ReadLine();
                if (Choice == "5")// checking for exit condition
                {
                    Console.WriteLine("Exiting Calculator. Final result: " + result);
                    break;
                }
                if (!(Choice =="1" || Choice =="2" || Choice =="3" || Choice =="4" || Choice=="5"))
                    //check for valid operation before asking for next number.
                {
                    Console.WriteLine("Invalid Choice .Please enter a number between 1 to 5");
                    continue;
                }
                int nextNum;
                Console.Write("Enter next number: ");
                // inputvalidation for the next number
                while(!int.TryParse(Console.ReadLine(), out nextNum))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }
                //nextNum = int.Parse(Console.ReadLine());
                
                switch (Choice)
                {
                    case "1":
                        result += nextNum;
                        break;
                    case "2":
                        result -= nextNum;
                        break;

                    case "3":
                        result *= nextNum;
                        break;
                    case "4":
                        //Division by zero handling
                        if (nextNum != 0)
                            result /= nextNum;
                        else
                        {
                            Console.WriteLine("Cannot divide by zero");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid operation.");
                        continue;
                }
                Console.WriteLine($"Current result :{result}");


                }
            Console.ReadLine();// keeps console window open


        }
    }
}
