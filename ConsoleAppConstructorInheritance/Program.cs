using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConstructorInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Artist aObj = new Artist("Diljit", "10 years", "50000");
            Console.WriteLine("Artist Data");
            Console.WriteLine(aObj.Name);
            Console.WriteLine(aObj.Experience);
            Console.WriteLine(aObj.Income);
            aObj.GetMessage();

            
            Console.WriteLine("\nSinger Data");
            Singer sObj = new Singer("Diljit", "10 years", "50000", "Punjabi", "30");
            Console.WriteLine(sObj.Name);
            Console.WriteLine(sObj.Experience);
            Console.WriteLine(sObj.Income);
            Console.WriteLine(sObj.NumberOfAlbums);
            Console.WriteLine(sObj.Vocalist);
            sObj.GetMessage();

            
            Console.WriteLine("\nDance Data");
            Dance dObj = new Dance("Diljit", "10 years", "50000", "Bhangra", "50");
            Console.WriteLine(dObj.Name);
            Console.WriteLine(dObj.Experience);
            Console.WriteLine(dObj.Income);
            Console.WriteLine(dObj.SongsPerformed);
            Console.WriteLine(dObj.Choreography);
            dObj.GetMessage();

            
            Console.WriteLine("\nPerformer Data");
            Performer pObj = new Performer("Diljit", "10 years", "50000", "Punjabi", "30", "Bhangra", "50", "100");
            pObj.ShowDetails();
            pObj.GetMessage();
        }
    }
}
