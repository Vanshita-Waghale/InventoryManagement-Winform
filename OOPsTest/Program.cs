using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPsTest.Vehicle;

namespace OOPsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle myV = new Vehicle();// In C#, every type implicitly inherits from the object class, whether it's a class, struct, enum, interface, or even a delegate. 
            myV.Equals(myV);
            Car myCar1 = new Car(eFuelType);
            myCar1.VehicleType = eVehicleType.Consumer;
            myCar1.NofWheels = 4;
            myCar1.eEngineType = eEngineType.FourStroke.ToString();
            myCar1.FuelType = eFuelType.Petrol.ToString();

            myCar1.Brand= "Maruti";
            myCar1.ModelNo = "Alto";
            myCar1.ModelYear = 2019;
            myCar1.Color = "WhiteSmoke";
            myCar1.SeatingCapacity = 5;
            //Console.WriteLine($"My Car 1 : {myCar1.Brand}, Model: {myCar1.ModelNo}, Year: {myCar1.ModelYear}, Color: {myCar1.Color}, Seating Capacity: {myCar1.SeatingCapacity}");
            Console.WriteLine(myCar1.GetCarDetails("My Car 1"));

            Car myCar2 = new Car(eFuelType);
            myCar2.Brand = "Mercedez";
            myCar2.ModelNo = "C200";
            myCar2.ModelYear = 2020;
            myCar2.Color = "Red";
            myCar2.SeatingCapacity = 5;
            //Console.WriteLine($"My Car 2 : {myCar2.Brand}, Model: {myCar2.ModelNo}, Year: {myCar2.ModelYear}, Color: {myCar2.Color}, Seating Capacity: {myCar2.SeatingCapacity}");
            Console.WriteLine(myCar2.GetCarDetails("My Car 2"));

            Car myCar3 = new Car(eFuelType);
            myCar3.Brand = "Chevrolet";
            myCar3.ModelNo = "Beetle";
            myCar3.ModelYear = 2016;
            myCar3.Color = "Yellow";
            myCar3.SeatingCapacity = 3;
            //Console.WriteLine($"My Car 3 : {myCar3.Brand}, Model: {myCar3.ModelNo}, Year: {myCar3.ModelYear}, Color: {myCar3.Color}, Seating Capacity: {myCar3.SeatingCapacity}");
            Console.WriteLine(myCar3.GetCarDetails("My Car 3"));
            Console.ReadKey();
        }
    }
}
