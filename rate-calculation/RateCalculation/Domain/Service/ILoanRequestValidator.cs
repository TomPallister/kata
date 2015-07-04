using System.Collections.Generic;
using RateCalculation.Domain.Command;
using RateCalculation.Domain.Model;

namespace RateCalculation.Domain.Service
{
    /// <summary>
    /// This service is used to validate loan requests.
    /// </summary>
    public interface ILoanRequestValidator
    {
        /// <summary>
        /// This will validate a loan request.
        /// </summary>
        /// <param name="requestLoanFromMarket">The loan request to validate</param>
        /// <param name="availableLenders">All of the available lenders for this request</param>
        /// <returns></returns>
        ValidLoanRequest ValidateLoanRequest(RequestLoanFromMarket requestLoanFromMarket, IEnumerable<Lender> availableLenders);
    }
}
