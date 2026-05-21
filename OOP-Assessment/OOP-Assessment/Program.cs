using OOP_Assessment;
using OOP_Assessment.Cars;
using OOP_Assessment.Contracts;
using OOP_Assessment.Discounts;
using OOP_Assessment.Services;

namespace FareEngineAssessment
{
    public record Passenger(string PassengerId, string FullName);

    class Program
    {
        static void Main(string[] args)
        {

            IPaymentService paymentService = new CreditCardPaymentService();

            var standardCar = new StandardCar("ABC-1234");
            var luxurySedan = new LuxurySedan("XYZ-9999", luxuryTax: 5.00m);

            var alice = new Passenger("P001", "Shakwat Hossain");
            var bob = new Passenger("P002", "Arafat Hossain Anik");

            var tenPctOff = new PercentageDiscount(10);
            var fiveDollarOff = new FlatDiscount(5.00m, standardCar.BaseFare);

            RunTest("1. Standard Car — no promotion",
                new Trip(standardCar, alice, distanceKms: 12, durationMinutes: 20),
                paymentService);

            RunTest("2. Standard Car — 10% off",
                new Trip(standardCar, alice, distanceKms: 12, durationMinutes: 20, tenPctOff),
                paymentService);

            RunTest("3. Standard Car — $5 flat off",
                new Trip(standardCar, alice, distanceKms: 12, durationMinutes: 20, fiveDollarOff),
                paymentService);

            RunTest("4. Luxury Sedan — no promotion",
                new Trip(luxurySedan, bob, distanceKms: 10, durationMinutes: 15),
                paymentService);

            RunTest("5. Luxury Sedan — 10% off",
                new Trip(luxurySedan, bob, distanceKms: 10, durationMinutes: 15, tenPctOff),
                paymentService);

            RunTest("6. Flat discount that would exceed BaseFare (floors at BaseFare)",
                new Trip(standardCar, alice, distanceKms: 0.1m, durationMinutes: 1,
                         new FlatDiscount(50m, standardCar.BaseFare)),
                paymentService);

            // Exception handling tests
            Console.WriteLine("── Exception Tests ──\n");

            TryThrow("7. Negative distance",
                () => new Trip(standardCar, alice, distanceKms: -5, durationMinutes: 10));

            TryThrow("8. Zero duration",
                () => new Trip(standardCar, alice, distanceKms: 5, durationMinutes: 0));

            TryThrow("9. Null vehicle",
                () => new Trip(null!, alice, distanceKms: 5, durationMinutes: 10));

            TryThrow("10. Bad PercentageDiscount value (> 100)",
                () => new PercentageDiscount(110));

            TryThrow("11. Negative FlatDiscount amount",
                () => new FlatDiscount(-1m, 3m));
        }


        static void RunTest(string label, Trip trip, IPaymentService svc)
        {
            Console.WriteLine($"── Test {label} ──");
            Console.WriteLine($"  Vehicle     : {trip.Vehicle}");
            Console.WriteLine($"  Passenger   : {trip.Passenger.FullName}");
            Console.WriteLine($"  Distance    : {trip.DistanceKms} km");
            Console.WriteLine($"  Duration    : {trip.DurationMinutes} min");
            Console.WriteLine($"  Promotion   : {trip.Promotion?.ToString() ?? "None"}");
            Console.WriteLine($"  Final Fare  : ${trip.CalculateFinalFare():F2}");
            trip.CompleteTrip(svc);
            Console.WriteLine($"  Trip Status : {trip.Status}\n");
        }

        static void TryThrow(string label, Action action)
        {
            Console.Write($"  Test {label}: ");
            try
            {
                action();
                Console.WriteLine("No exception was thrown.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" {ex.GetType().Name} — \"{ex.Message}\"");
            }
        }
    }
}