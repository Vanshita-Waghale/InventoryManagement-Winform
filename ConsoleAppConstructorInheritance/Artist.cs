using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConstructorInheritance
{
    internal class Artist
    {
        public string Name { get; set; }
        public string Experience { get; set; }
        public string Income { get; set; }

        public Artist() { }

        public Artist(string name, string experience, string income)
        {
            Name = name;
            Experience = experience;
            Income = income;
            Console.WriteLine("Artist Constructor Called");
        }

        public virtual void GetMessage()
        {
            Console.WriteLine("Base class Artist");
        }
    }
}
