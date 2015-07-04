using System.Collections.Generic;
using RateCalculation.Domain.Model;

namespace RateCalculation.Domain.Command
{
    /// <summary>
    /// Add lenders to market command, this is used to describe intention when adding lenders to the market.
    /// </summary>
    public class AddLendersToMarket
    {
        /// <summary>
        /// Default constructor takes a list of lenders that we will attempt to add to the market.
        /// </summary>
        /// <param name="lenders"></param>
        public AddLendersToMarket(List<Lender> lenders)
        {
            Lenders = lenders;
        }

        /// <summary>
        /// Property that holds the lenders we want to add to the market.
        /// </summary>
        public List<Lender> Lenders { get; private set; } 
    }
}
