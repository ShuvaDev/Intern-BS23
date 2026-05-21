using OOP_Assessment.Contracts;

namespace OOP_Assessment.Cars
{
    public class LuxurySedan : Vehicle
    {
        public decimal LuxuryTax { get; }

        public override decimal PerKmRate => 2.00m;
        public override decimal PerMinuteRate => 0.50m;
        public override decimal AdditionalCharges => LuxuryTax;

        public LuxurySedan(string licensePlate, decimal luxuryTax = 5.00m)
            : base(licensePlate, baseFare: 8.00m)
        {
            if (luxuryTax < 0)
                throw new ArgumentException("Luxury tax cannot be negative.", nameof(luxuryTax));
            LuxuryTax = luxuryTax;
        }

    }
}
