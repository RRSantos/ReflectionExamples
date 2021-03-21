
namespace ModelValidation
{
    class Vehicle : BaseModel
    {
        public byte Wheels { get; private set; }
        public string Model { get; private set; }

        [IntegerValidatorAttibute(MinValue: 1900)]
        public int Year { get; private set; }

        public Vehicle(byte wheels, string model, int year)
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
