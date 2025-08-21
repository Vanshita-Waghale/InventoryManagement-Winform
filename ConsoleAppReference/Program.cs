using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppReference
{
    internal class Program
    {
        ////Reference Keyword example
        //public static void GetCubeValue(ref int num)
        //{
        //    num = num * num * num;
        //}
        //static void Main(string[] args) 
        //{
        //    int a = 3;
        //    GetCubeValue(ref a);
        //    Console.WriteLine("Answer is: {0}", a);
        //    Console.Read();
        //}


        //public static void FindAreaAndPerimeter(int l,int w,out int area,out int peri)
        //{
        //    area = l * w;
        //    peri = 2 * ( l + w);
        //}
        //static void Main(string[] args)
        //{
        //    int area, peri;
        //    FindAreaAndPerimeter(4, 5, out area, out peri);
        //    Console.WriteLine("Area:{0} And Perimeter: {1}", area, peri);
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    //int peri;
        //    //int area = FindAreaAndPerimeter(4, 5, out peri);
        //    //Console.WriteLine(area + " " + peri);

        //    Student obj = new Student();
        //    obj = null;
        //    GC.Collect();
        //    Console.ReadLine() ;

        //}

        public static int FindAreaAndPerimeter(ref int l,ref int w, out int peri)
        {
            peri = 2 * ( l+ w );
            return l * w;
            
        }
        static void Main(string[] args)
        {
            int l ,w , peri;
            Console.WriteLine("Enter length : ");
            l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter width : ");
            w = Convert.ToInt32(Console.ReadLine());
            int area = FindAreaAndPerimeter(ref l , ref w ,out peri);
            Console.WriteLine( area + " " + peri);
            Console.ReadLine();
          
        }


    }
}
