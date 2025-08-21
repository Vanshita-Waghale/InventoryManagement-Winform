using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ConsoleAppConstructorInheritance
{
    internal class Dance : Artist, IDance
    {
        public string SongsPerformed { get; set; }
        public string Choreography { get; set; }

        public Dance() : this("Diljit", "10 years", "50000", "Bhangra", "50")
        {
            Name = "Diljit";
            Experience = "10 years";
            Income = "50000";
            Choreography = "Bhangra";
            SongsPerformed = "50";
            Console.WriteLine("Dance Constructor Called");
        }

        public Dance(string name, string experience, string income, string choreography, string songsPerformed)
        {
            Name = name;
            Experience = experience;
            Income = income;
            Choreography = choreography;
            SongsPerformed = songsPerformed;
            Console.WriteLine("Dance Constructor Called");
        }

        public override void GetMessage()
        {
            Console.WriteLine("Derived class Dance");
        }
    }
}
