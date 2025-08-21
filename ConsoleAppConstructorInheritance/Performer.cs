using System;


namespace ConsoleAppConstructorInheritance
{
    internal class Performer : Artist, ISinger, IDance
    {
        public string NumberOfAlbums { get; set; }
        public string Vocalist { get; set; }
        public string SongsPerformed { get; set; }
        public string Choreography { get; set; }
        public string NumberOfPerformances { get; set; }

        public Performer() : this("Diljit", "10 years", "50000", "Punjabi", "30", "Bhangra", "50", "100")
        {
            Name = "Diljit";
            Experience = "10 years";
            Income = "50000";
            Vocalist = "Punjabi";
            NumberOfAlbums = "30";
            Choreography = "Bhangra";
            SongsPerformed = "50";
            NumberOfPerformances = "100";
            Console.WriteLine("Performer Constructor Called");
        }

        public Performer(string name, string experience, string income, string vocalist, string numberOfAlbums,
            string choreography, string songsPerformed, string numberOfPerformances)
        {
            Name = name;
            Experience = experience;
            Income = income;
            Vocalist = vocalist;
            NumberOfAlbums = numberOfAlbums;
            Choreography = choreography;
            SongsPerformed = songsPerformed;
            NumberOfPerformances = numberOfPerformances;
            Console.WriteLine("Performer Constructor Called");
        }

        public override void GetMessage()
        {
            Console.WriteLine("Derived class Performer");
        }

        public void ShowDetails()
        {
            Console.WriteLine("Performer Details:");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Experience: " + Experience);
            Console.WriteLine("Income: " + Income);
            Console.WriteLine("Vocalist: " + Vocalist);
            Console.WriteLine("Number of Albums: " + NumberOfAlbums);
            Console.WriteLine("Choreography: " + Choreography);
            Console.WriteLine("Songs Performed: " + SongsPerformed);
            Console.WriteLine("Number of Performances: " + NumberOfPerformances);
        }
    }
}
