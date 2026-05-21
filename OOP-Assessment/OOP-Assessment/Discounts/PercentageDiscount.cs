using OOP_Assessment.Contracts;

namespace OOP_Assessment.Discounts
{
    public class PercentageDiscount : IPromotion
    {
        public decimal Percentage { get; }

        public PercentageDiscount(decimal percentage)
        {
            if (percentage <= 0 || percentage >= 100)
                throw new ArgumentException("Percentage must be between 0 and 100.", nameof(percentage));

            Percentage = percentage;
        }

        public decimal ApplyDiscount(decimal currentFare)
        {
            return currentFare * (1 - Percentage / 100m);
        }
    }
}
