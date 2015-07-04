using System.Globalization;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RateCalculation.Domain.Command;
using RateCalculation.Domain.Model;
using RateCalculation.Domain.Service;
using RateCalculation.Infrastructure.Repository;

namespace RateCalculation.Tests
{
    /// <summary>
    /// The market service tests
    /// </summary>
    [TestFixture]
    public class MarketServiceTests
    {
        /// <summary>
        /// Persists lenders
        /// </summary>
        private ILenderRepository _lenderRepository;
        /// <summary>
        /// Thing being tested
        /// </summary>
        private IMarketService _marketService;
        /// <summary>
        /// Calculates loans and offers
        /// </summary>
        private ILoanCalculator _loanCalculator;
        /// <summary>
        /// Validates loan requests
        /// </summary>
        private ILoanRequestValidator _loanRequestValidator;

        /// <summary>
        /// Set up tests
        /// </summary>
        [SetUp]
        public void set_up()
        {
            _loanCalculator = new LoanCalculator();
            _lenderRepository = new StubLenderRepository();
            _loanRequestValidator = new LoanRequestValidator(15000, 1000, 100);
            _marketService = new MarketService(_lenderRepository, _loanCalculator, _loanRequestValidator);
        }

        /// <summary>
        /// Makes sure we can add lenders to the market
        /// </summary>
        [Test]
        public void can_add_lenders_to_market()
        {
            //set up
            var lenders = TestHelpers.GetSevenLendersForTesting();
            //act
            var addLendersToMarket = new AddLendersToMarket(lenders);
            _marketService.AddLendersToMarket(addLendersToMarket);
            //assert
            var storedLenders = _lenderRepository.FindBy(x => x.Available > 0).ToList();
            storedLenders.Count.Should().Be(7);
        }

        /// <summary>
        /// Makes sure we can request a loan from the markets
        /// </summary>
        [Test]
        public void can_request_loan_from_market()
        {   
            //set up
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var addLendersToMarket = new AddLendersToMarket(lenders);
            _marketService.AddLendersToMarket(addLendersToMarket);
            var amountRequested = 1000;
            var repaymentMonths = 36;
            //act
            var requestLoanFromMarket = new RequestLoanFromMarket(amountRequested, repaymentMonths, new Currency(new CultureInfo("en-gb").NumberFormat));
            var quote = _marketService.RequestQuoteFromMarket(requestLoanFromMarket);
            //assert
            quote.Quote.RequestedAmount.Should().Be(amountRequested);
            quote.Quote.TotalRepyment.Should().Be(new decimal(1233.08));
            quote.Quote.MonthlyRepayment.Should().Be(new decimal(34.25));
            quote.Quote.Rate.Should().Be(0.1);

        }
    }
}
