using OOP_Assessment.Contracts;

namespace OOP_Assessment.Cars
{
    public class StandardCar : Vehicle
    {
        public override decimal PerKmRate => 0.90m;
        public override decimal PerMinuteRate => 0.15m;

        public StandardCar(string licensePlate)
            : base(licensePlate, baseFare: 3.00m) { }
    }
}
