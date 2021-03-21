using System;

namespace Logging
{
    class Vehicle
    {
        public byte Wheels { get; private set; }
        public string Model { get; private set; }
        public UInt16 Year { get; private set; }

        public Vehicle(byte wheels, string model, UInt16 year)
        {
            Wheels = wheels;
            Model = model;
            Year = year;
        }

        public string Start()
        {
            return "Vruummm! Vruuummmm!";
        }


    }
}
