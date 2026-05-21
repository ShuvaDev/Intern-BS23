namespace OOP_Assessment.Contracts
{
    public abstract class Vehicle
    {
        public string LicensePlate { get; init; }
        public decimal BaseFare { get; init; }

        public abstract decimal PerKmRate { get; }
        public abstract decimal PerMinuteRate { get; }

        protected Vehicle(string licensePlate, decimal baseFare)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("License plate must not be empty.", nameof(licensePlate));
            if (baseFare < 0)
                throw new ArgumentException("Base fare cannot be negative.", nameof(baseFare));

            LicensePlate = licensePlate;
            BaseFare = baseFare;
        }

        public virtual decimal AdditionalCharges => 0m;
    }
}
