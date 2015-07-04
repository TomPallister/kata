using RateCalculation.Domain.Command;
using RateCalculation.Domain.Model;

namespace RateCalculation.Domain.Service
{
    /// <summary>
    /// The market service contract.
    /// </summary>
    public interface IMarketService
    {        
        /// <summary>
        /// Adds lenders to the market for future use.
        /// </summary>
        /// <param name="addLendersToMarket">Command that adds lenders to market.</param>
        void AddLendersToMarket(AddLendersToMarket addLendersToMarket);

        /// <summary>
        /// Requests a loan from the market
        /// </summary>
        /// <param name="requestLoanFromMarket">Command that requests a loan from the market</param>
        /// <returns></returns>
        ResponseToLoanRequest RequestQuoteFromMarket(RequestLoanFromMarket requestLoanFromMarket);
    }
}
