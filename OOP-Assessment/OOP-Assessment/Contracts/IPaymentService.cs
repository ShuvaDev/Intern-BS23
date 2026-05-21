namespace OOP_Assessment.Contracts
{
    public interface IPaymentService
    {
        bool ProcessPayment(string passengerId, decimal amount);
    }
}
