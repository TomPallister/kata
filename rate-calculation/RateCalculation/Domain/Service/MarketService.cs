using System.Collections.Generic;
using System.Linq;
using RateCalculation.Domain.Command;
using RateCalculation.Domain.Model;
using RateCalculation.Infrastructure.Repository;

namespace RateCalculation.Domain.Service
{
    /// <summary>
    /// The market service, responsible for the business logic of the market and providing a human readable dsl over the top of the application internals.
    /// </summary>
    public class MarketService : IMarketService
    {
        /// <summary>
        /// The lender repository that will persist for the service.
        /// </summary>
        private readonly ILenderRepository _lenderRepository;

        /// <summary>
        /// The loan calculator is used to work out best available offers and repayments.
        /// </summary>
        private readonly ILoanCalculator _loanCalculator;

        /// <summary>
        /// The loan request validator is used to make sure the loan request meets some basic 
        /// requirements
        /// </summary>
        private readonly ILoanRequestValidator _loanRequestValidator;

        /// <summary>
        /// Constructor to inject lender repository dependency.
        /// </summary>
        /// <param name="lenderRepository">An implementation of ILenderRepository</param>
        /// <param name="loanCalculator">An implementation of ILoanCalculator</param>
        public MarketService(ILenderRepository lenderRepository, ILoanCalculator loanCalculator, ILoanRequestValidator loanRequestValidator)
        {
            _lenderRepository = lenderRepository;
            _loanCalculator = loanCalculator;
            _loanRequestValidator = loanRequestValidator;
        }

        /// <inheritdoc />
        public void AddLendersToMarket(AddLendersToMarket addLendersToMarket)
        {
            //the document might have broken lenders in it (any lender with 0 available money
            //decided that 0 rate is probably OK but bad
            var lendersWithMoneyToLoan = addLendersToMarket.Lenders.Where(x => x.Available > 0).ToList();
            //store the command
            _lenderRepository.Store(lendersWithMoneyToLoan);
        }

        /// <inheritdoc />
        public ResponseToLoanRequest RequestQuoteFromMarket(RequestLoanFromMarket requestLoanFromMarket)
        {
            //get all the lenders with available money
            var lenders = _lenderRepository.FindBy(x => x.Available > 0);
            //convert he ienumberable to an array or we can get enumeration problems! This is 
            //not ideal.
            var availableLenders = lenders as Lender[] ?? lenders.ToArray();
            //validate the loan request
            var validateRequest = _loanRequestValidator.ValidateLoanRequest(requestLoanFromMarket,
                availableLenders);
            //if the loan request isnt valid
            if (!validateRequest.IsValid)
            {
                //return a response that indicates failure. 
                return new ResponseToLoanRequest(null, validateRequest);
            }
            //get the best offers for the loan request
            var offers = _loanCalculator.GetTheBestAvailableOffersFromLenders(availableLenders, requestLoanFromMarket.Amount);
            //work out the quote from the offers
            var quote = _loanCalculator.CalculateQuoteFromOffers(offers, requestLoanFromMarket.RepaymentMonths,
                requestLoanFromMarket.Amount);
            //return the quote with a successful response
            return new ResponseToLoanRequest(quote, new ValidLoanRequest(new List<string>(), true));
        }
    }
}
