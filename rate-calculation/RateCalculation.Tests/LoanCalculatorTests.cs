using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RateCalculation.Domain.Model;
using RateCalculation.Domain.Service;

namespace RateCalculation.Tests
{
    /// <summary>
    /// Loan calculator tests
    /// </summary>
    [TestFixture]
    public class LoanCalculatorTests
    {
        /// <summary>
        /// Thing being tested
        /// </summary>
        private LoanCalculator _offerCalculator;

        /// <summary>
        /// Sets up the tests
        /// </summary>
        [SetUp]
        public void set_up()
        {
            _offerCalculator = new LoanCalculator();
        }

        /// <summary>
        /// Makes sure that we get the best offers when borrowing 1000
        /// </summary>
        [Test]
        public void can_get_best_offers_from_lenders_1000()
        {
            //set up
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var requestedAmount = 1000;
            //act
            var offers = _offerCalculator.GetTheBestAvailableOffersFromLenders(lenders, requestedAmount).ToList();
            //assert
            offers.Count.Should().Be(2);
            offers[1].Amount.Should().Be(520);
            offers[1].Rate.Should().Be(0.071);
            offers[0].Amount.Should().Be(480);
            offers[0].Rate.Should().Be(0.069);
        }

        /// <summary>
        /// Makes sure we get the best offer first then they get worse
        /// </summary>
        [Test]
        public void order_of_offers_should_start_with_lowest_rate_then_rate_should_rise_for_each_subsequent_offer()
        {
            //set up
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var requestedAmount = 1500;
            //act
            var offers = _offerCalculator.GetTheBestAvailableOffersFromLenders(lenders, requestedAmount).ToList();
            //assert
            double lastRate = 0.00;
            foreach (var offer in offers)
            {
                offer.Rate.Should().BeGreaterOrEqualTo(lastRate);
            }
        }

        /// <summary>
        /// Makes sure we get the best offers when borrowing an increment of 100 over 1100
        /// </summary>
        [Test]
        public void can_get_best_offers_from_lenders_1100()
        {
            //set up
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var requestedAmount = 1100;
            //act
            var offers = _offerCalculator.GetTheBestAvailableOffersFromLenders(lenders, requestedAmount).ToList();
            //assert
            offers.Count.Should().Be(4);
            offers[3].Amount.Should().Be(40);
            offers[3].Rate.Should().Be(0.074);
            offers[2].Amount.Should().Be(60);
            offers[2].Rate.Should().Be(0.071);
            offers[1].Amount.Should().Be(520);
            offers[1].Rate.Should().Be(0.071);
            offers[0].Amount.Should().Be(480);
            offers[0].Rate.Should().Be(0.069);
        }

        /// <summary>
        /// Happy path making sure we calculate the loan request correctly
        /// </summary>
        [Test]
        public void can_calculate_quote()
        {
            //set up
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var requestedAmount = 1000;
            var numberOfRepaymentMonths = 36;
            var offers = _offerCalculator.GetTheBestAvailableOffersFromLenders(lenders, requestedAmount).ToList();
            //act
            var quote = _offerCalculator.CalculateQuoteFromOffers(offers, numberOfRepaymentMonths, requestedAmount);
            //assert
            quote.Rate.Should().Be(0.1);
            quote.MonthlyRepayment.Should().Be(new decimal(34.25));
            quote.RequestedAmount.Should().Be(requestedAmount);
            quote.TotalRepyment.Should().Be(new decimal(1233.08));
        }
    }
}
