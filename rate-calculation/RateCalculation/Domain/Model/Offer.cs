namespace RateCalculation.Domain.Model
{
    /// <summary>
    /// This is used to store offers that lenders can make to borrowers.
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="amount">The amount the lender can offer</param>
        /// <param name="rate">The rate the lender can offer</param>
        public Offer(decimal amount, double rate)
        {
            Amount = amount;
            Rate = rate;
        }

        /// <summary>
        /// The amount offered.
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// The rate offered.
        /// </summary>
        public double Rate { get; private set; }
    }
}
