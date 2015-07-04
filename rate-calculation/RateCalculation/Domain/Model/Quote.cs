namespace RateCalculation.Domain.Model
{
    /// <summary>
    /// The results of a loan request
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="requestedAmount">The loan amount requested</param>
        /// <param name="rate">The rate that has been set for the request</param>
        /// <param name="monthlyRepayment">The amount that needs to be repaid per month</param>
        /// <param name="totalRepayment">The total value of the loan repayment</param>
        public Quote(decimal requestedAmount, double rate, decimal monthlyRepayment, decimal totalRepayment)
        {
            RequestedAmount = requestedAmount;
            Rate = rate;
            MonthlyRepayment = monthlyRepayment;
            TotalRepyment = totalRepayment;
        }

        /// <summary>
        /// The loan amount requested
        /// </summary>
        public decimal RequestedAmount { get; private set; }

        /// <summary>
        /// The rate that has been set for the request
        /// </summary>
        public double Rate { get; private set; }

        /// <summary>
        /// The amount that needs to be repaid per month
        /// </summary>
        public decimal MonthlyRepayment { get; private set; }

        /// <summary>
        /// The total value of the loan repayment
        /// </summary>
        public decimal TotalRepyment { get; private set; }
    }
}
