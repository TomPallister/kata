using System.Collections.Generic;
using RateCalculation.Domain.Model;

namespace RateCalculation.Domain.Service
{
    /// <summary>
    /// The loan calculator contract.
    /// </summary>
    public interface ILoanCalculator
    {
        /// <summary>
        /// Takes a collection of lenders and the loan amount and returns the best offers from that collection
        /// </summary>
        /// <param name="lenders">The list of lenders to work with</param>
        /// <param name="requestedLoanAmount">The amount the user wants to borrow</param>
        /// <returns>A collection of offers</returns>
        IEnumerable<Offer> GetTheBestAvailableOffersFromLenders(IEnumerable<Lender> lenders, decimal requestedLoanAmount);
        
        /// <summary>
        /// Takes a collection of offers, the numbers of months to repay a loan over and the requested amount
        /// then works out a Quote for the request
        /// </summary>
        /// <param name="offers">The offers to work with</param>
        /// <param name="numberOfRepaymentMonths">The number of months the loan is repaid over</param>
        /// <param name="requestedAmount">The amount the user wants to borrow</param>
        /// <returns></returns>
        Quote CalculateQuoteFromOffers(IEnumerable<Offer> offers, int numberOfRepaymentMonths, decimal requestedAmount);
    }
}
