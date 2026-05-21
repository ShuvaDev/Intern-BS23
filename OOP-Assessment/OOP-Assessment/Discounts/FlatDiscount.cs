using OOP_Assessment.Contracts;

namespace OOP_Assessment.Discounts
{
    public class FlatDiscount : IPromotion
    {
        public decimal DiscountAmount { get; }
        private readonly decimal _minimumFare;

        public FlatDiscount(decimal discountAmount, decimal minimumFare)
        {
            if (discountAmount <= 0)
                throw new ArgumentException("Discount amount must be positive.", nameof(discountAmount));
            if (minimumFare < 0)
                throw new ArgumentException("Minimum fare cannot be negative.", nameof(minimumFare));

            DiscountAmount = discountAmount;
            _minimumFare = minimumFare;
        }

        public decimal ApplyDiscount(decimal currentFare)
        {
            return Math.Max(currentFare - DiscountAmount, _minimumFare);
        }
    }
}
