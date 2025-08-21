using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConstructorInheritance
{
    // Interface for Singer-specific properties and methods
    internal interface ISinger
    {
        string NumberOfAlbums { get; set; }
        string Vocalist { get; set; }
        void GetMessage(); // Method signature without implementation
    }

}
