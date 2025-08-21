using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsTest
{
    public enum eFuelType
    {
        None = 0,
        Petrol = 1,
        Diesel = 2,
        CNG = 3,
        Electric = 5,
        BioDiesel = 6,
    }

    public enum eEngineType
    {
        None = 0,
        TwoStroke = 1,
        FourStroke = 2,
        VType = 3,
    }
    public enum eVehicleType
    {
        Consumer = 0,
        SemiCommercial = 1,
        Commercial = 2,

    }
    //Classes are made so that to we can reuse the code and make it more readable.
    public class Vehicle
    {
        // Properties , Also here public is Access modifier
        public int NofWheels { get; set; }
        public string eEngineType { get; set; }
        public string FuelType { get; set; }
        public int Speed { get; protected set; }
        public string VehicleType { get; private set; }

        public void EngineStart()
        {
            Speed = 0;
        }
        public void EngineStop()
        {
            Speed = 0;
        }

        public void Accelerate()
        //which return anything then it is function
        {
            Speed += 10;
        }

        public void Break()
        {
            Speed -= 10;
        }

        public class PassengerVehicle
        {
            public int SeatingCapacity { get; set; }
            public string VehicleType { get; set; }
        }

        //C# does not support multiple inheritance of classes
        // internal class Car : Vehicle, PassengerVehicle (Not Allowed)
        internal class Car : Vehicle//Inherit the poroperties from Vehicle class
        {
            //-A constructor is a special method inside a class that:
            //- Gets called automatically when you create(instantiate) an object.
            //- Initializes the object's data or performs setup tasks.
            //- No return type not to mention the constructor
            //- class name and constructor name should be same (case sensitive)

            public new eEngineType eEngineType { get; set; } // Added 'new' keyword to hide the base member  
            public new eFuelType FuelType { get; set; } // Added 'new' keyword to hide the base member  

            // Update the constructor in the Car class to assign enum values directly.  
            public Car()
            {
                base.NofWheels = 4;
                base.VehicleType = eVehicleType.Consumer.ToString();
                this.eEngineType = eEngineType.FourStroke; // Assigning to the current class property  
                this.FuelType = eFuelType.Petrol; // Assigning to the current class property  
            }


            // Constructor with only brand
            public Car(string brand) : this(brand, null, null, 2001, 4)
            {
            }

            // Constructor with brand and color
            public Car(string brand, string color) : this(brand, color, null, 2001, 4)
            {
            }

            // Constructor with brand, color, and modelNo
            public Car(string brand, string color, string modelNo) : this(brand, color, modelNo, 2001, 4)
            {
            }

            // Constructor with brand, color, modelNo, and modelYear
            public Car(string brand, string color, string modelNo, int modelYear) : this(brand, color, modelNo, modelYear, 4)
            {
            }

            public Car(string brand, string color, string modelNo, int modelYear, int SeatingCapacity) : this()//Constructor
            {
                this.Brand = brand;
                this.Color = color;
                this.ModelNo = modelNo;
                this.ModelYear = modelYear;
                this.SeatingCapacity = SeatingCapacity;

            }
            public string Brand { get; internal set; }
            public string ModelNo { get; internal set; }
            public int ModelYear { get; internal set; }
            public string Color { get; internal set; }
            public int SeatingCapacity { get; internal set; }
            public eVehicleType VehicleType { get; internal set; }

            //public void Break()
            ////which does not return anything then it is a method 
            //{

            //}

            //public decimal Accelerate()
            //    //which return anything then it is function
            //    {
            //        return 0;
            //    }

            public void GearShift(int NextGearNo)
            {

            }
            public string GetCarDetails(string CarTitle) //Make a property
            {
                return $"{CarTitle} : {Brand}, Model: {ModelNo}, Year: {ModelYear}, Color: {Color}, Seating Capacity: {SeatingCapacity}";
            }

        }
    }
}
