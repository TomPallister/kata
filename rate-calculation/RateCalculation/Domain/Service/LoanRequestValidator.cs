using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RateCalculation.Domain.Command;
using RateCalculation.Domain.Model;

namespace RateCalculation.Domain.Service
{
    /// <inheritdoc />
    public class LoanRequestValidator : ILoanRequestValidator
    {
        /// <summary>
        /// Default constructor takes the values that we will validate against.
        /// </summary>
        /// <param name="maxLoanRequest"></param>
        /// <param name="minLoanRequet"></param>
        /// <param name="allowedIncrements"></param>
        public LoanRequestValidator(decimal maxLoanRequest, decimal minLoanRequet, decimal allowedIncrements)
        {
            _maximumLoanRequest = maxLoanRequest;
            _minimumLoanRequest = minLoanRequet;
            _allowedIncrement = allowedIncrements;
        }

        /// <summary>
        /// The maximum amount a loan could be
        /// </summary>
        private readonly decimal _maximumLoanRequest;

        /// <summary>
        /// The minimum amount a loan can be
        /// </summary>
        private readonly decimal _minimumLoanRequest;

        /// <summary>
        /// Allowed load increment value
        /// </summary>
        private readonly decimal _allowedIncrement;

        /// <summary>
        /// The currency format
        /// </summary>
        private NumberFormatInfo _numberFormat;
        
        /// <inheritdoc />
        public ValidLoanRequest ValidateLoanRequest(RequestLoanFromMarket requestLoanFromMarket,
            IEnumerable<Lender> availableLenders)
        {
            //find out how much we can possibly lend
            var maximumAvailable = availableLenders.Sum(x => x.Available);
            //set the currency format for messages..
            _numberFormat = requestLoanFromMarket.Currency.Value;
            //a container for error messages
            var errorMessages = new List<string>();
            //if the requested loan amount if greater than the maxiumum amount a borrower 
            //can request then set an error message 
            if (requestLoanFromMarket.Amount > _maximumLoanRequest)
            {
                errorMessages.Add(
                    string.Format(
                        "This is more than the maximum allowed. We can only lend up to {0}.",
                        FormatNumberForCurrency(_maximumLoanRequest)));
            }
            //if the requested loan amount if less than the minimum loan request then
            //set an error message
            if (requestLoanFromMarket.Amount < _minimumLoanRequest)
            {
                errorMessages.Add(
                    string.Format("This is less than the minimum allowed. Our lending options start at {0}.",
                        FormatNumberForCurrency(_minimumLoanRequest)));
            }
            //if the loan amount is not a valid increment value
            //set an error message
            if (requestLoanFromMarket.Amount % _allowedIncrement > 0)
            {
                errorMessages.Add(
                    string.Format(
                        "This is not an increment of {0}. Please specify an amount of any {0} increment between {1} and {2}.",
                        FormatNumberForCurrency(_allowedIncrement),
                        FormatNumberForCurrency(_minimumLoanRequest),
                        FormatNumberForCurrency(_maximumLoanRequest)));
            }
            //if the loan amount if greater than the maximum available
            //set an error message
            if (requestLoanFromMarket.Amount > maximumAvailable)
            {
                errorMessages.Add(string.Format("There are not enough funds available to service your request, the maximum we can lend is {0}", FormatNumberForCurrency(maximumAvailable)));
            }
            //if we have any error messages return an invalid loan request else return a valid loan request
            return errorMessages.Count > 0 ? new ValidLoanRequest(errorMessages, false) : new ValidLoanRequest(new List<string>(), true);
        }

        /// <summary>
        /// Little method to make it nicer to follow the horrible validation code above!
        /// </summary>
        /// <param name="value">the value to be formatted</param>
        /// <returns>The formatted value</returns>
        private string FormatNumberForCurrency(decimal value)
        {
            return value.ToString("c", _numberFormat);
        }
    }
}