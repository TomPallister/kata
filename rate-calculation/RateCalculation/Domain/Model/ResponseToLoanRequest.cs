namespace RateCalculation.Domain.Model
{
    /// <summary>
    /// This is returned by the market service when a user requests a loan.
    /// </summary>
    public class ResponseToLoanRequest
    {
        /// <summary>
        /// Default constructor takes all properties
        /// </summary>
        /// <param name="quote">The quote that has been created</param>
        /// <param name="validLoanRequest">This tells us if the quote request was successful</param>
        public ResponseToLoanRequest(Quote quote, ValidLoanRequest validLoanRequest)
        {
            Quote = quote;
            ValidLoanRequest = validLoanRequest;
        }

        /// <summary>
        /// The quote that has been generated for the user.
        /// </summary>
        public Quote Quote { get; private set; }

        /// <summary>
        /// This contains information that tells us if the loan request was valid.
        /// </summary>
        public ValidLoanRequest ValidLoanRequest { get; private set; }

    }
}
