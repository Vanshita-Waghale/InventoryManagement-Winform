using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConstructorInheritance
{
    internal interface IDance
    { 
        string SongsPerformed { get; set; } 
        string Choreography { get; set; } 
        void GetMessage(); }
}
