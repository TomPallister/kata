namespace RateCalculation.Domain.Command
{
    /// <summary>
    /// Command to use if you want to request a loan from the market
    /// </summary>
    public class RequestLoanFromMarket
    {
        /// <summary>
        /// Default construtor takes the amount that the user is requesting
        /// </summary>
        /// <param name="amount">The value of the loan request</param>
        /// <param name="repaymentMonths"></param>
        /// <param name="currency"></param>
        public RequestLoanFromMarket(decimal amount, int repaymentMonths, Model.Currency currency)
        {
            Amount = amount;
            RepaymentMonths = repaymentMonths;
            Currency = currency;
        }

        /// <summary>
        /// The vale of the loan request. 
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// The amount of months that the user would like to repay the amount over.
        /// </summary>
        public int RepaymentMonths { get; private set; }

        /// <summary>
        /// The currency that this loan request is made in.
        /// </summary>
        public Model.Currency Currency { get; private set; } 
    }
}
