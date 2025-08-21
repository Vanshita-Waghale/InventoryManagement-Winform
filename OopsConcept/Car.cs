using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcept
{
    public class Car
    {
        //Proprties
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public string Color { get; set; }
        public string SeatingCapacity { get; set; }

        public void Break() 
        //which does not return anything then it is a method 
        {

        }

        public decimal Accelerate()
        //which return anything then it is function
        {
            return 0;
        }
         public void GearShift(int NextGearNo)
        {

        }

    }

    //function

}
