using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2Inheritance
{
    internal class BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }

        public string Status { get; set; } = "New";

        public virtual void GetMessage()
        {
            Console.WriteLine(" Base class ");
        }

    }
}
