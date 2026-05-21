using OOP_Assessment.Contracts;

namespace OOP_Assessment.Services
{
    public class CreditCardPaymentService : IPaymentService
    {
        public bool ProcessPayment(string passengerId, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(passengerId))
                throw new ArgumentException("Passenger ID must not be empty.", nameof(passengerId));
            if (amount <= 0)
                return false; 

            Console.WriteLine($"  [CreditCardPaymentService] Charged ${amount:F2} to passenger '{passengerId}'.");
            return true;
        }
    }
}
