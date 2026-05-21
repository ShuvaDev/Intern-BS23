using FareEngineAssessment;
using OOP_Assessment.Constants;
using OOP_Assessment.Contracts;
using OOP_Assessment.Exceptions;

namespace OOP_Assessment
{
    public class Trip
    {
        public Guid TripId { get; } = Guid.NewGuid();
        public TripStatus Status { get; private set; } = TripStatus.Pending;

        public Vehicle Vehicle { get; }
        public Passenger Passenger { get; }

        public decimal DistanceKms { get; }
        public decimal DurationMinutes { get; }

        public IPromotion? Promotion { get; }

        public Trip(Vehicle vehicle, Passenger passenger,
                    decimal distanceKms, decimal durationMinutes,
                    IPromotion? promotion = null)
        {
            if (vehicle is null)
                throw new InvalidTripException("A trip must be assigned a vehicle.");
            if (passenger is null)
                throw new ArgumentNullException(nameof(passenger));
            if (distanceKms < 0)
                throw new InvalidTripException($"Distance cannot be negative.");
            if (durationMinutes <= 0)
                throw new InvalidTripException($"Duration must be greater than zero.");

            Vehicle = vehicle;
            Passenger = passenger;
            DistanceKms = distanceKms;
            DurationMinutes = durationMinutes;
            Promotion = promotion;
        }

        public decimal CalculateFinalFare()
        {
            decimal rawFare = Vehicle.BaseFare
                            + (Vehicle.PerKmRate * DistanceKms)
                            + (Vehicle.PerMinuteRate * DurationMinutes)
                            + Vehicle.AdditionalCharges;

            decimal discountedFare = Promotion is not null
                ? Promotion.ApplyDiscount(rawFare)
                : rawFare;

            return Math.Max(discountedFare, Vehicle.BaseFare);
        }

        public void CompleteTrip(IPaymentService paymentService)
        {
            if (paymentService is null)
                throw new ArgumentNullException(nameof(paymentService));

            decimal fare = CalculateFinalFare();

            bool success = paymentService.ProcessPayment(Passenger.PassengerId, fare);
            Status = success ? TripStatus.Paid : TripStatus.Failed;
        }
    }
}
