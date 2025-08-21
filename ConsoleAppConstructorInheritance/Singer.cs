using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConstructorInheritance
{
    internal class Singer : Artist, ISinger
    {
        public string NumberOfAlbums { get; set; }
        public string Vocalist { get; set; }

        public Singer() : this("Diljit", "10 years", "50000", "Punjabi", "30")
        {
            Name = "Diljit";
            Experience = "10 years";
            Income = "50000";
            Vocalist = "Punjabi";
            NumberOfAlbums = "30";
            Console.WriteLine("Singer Constructor Called");
        }

        public Singer(string name, string experience, string income, string vocalist, string numberOfAlbums)
        {
            Name = name;
            Experience = experience;
            Income = income;
            Vocalist = vocalist;
            NumberOfAlbums = numberOfAlbums;
            Console.WriteLine("Singer Constructor Called");
        }

        public override void GetMessage()
        {
            Console.WriteLine("Derived class Singer");
        }
    }
}
