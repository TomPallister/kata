using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using RateCalculation.Domain.Command;
using RateCalculation.Domain.Model;
using RateCalculation.Domain.Service;

namespace RateCalculation.Tests
{
    /// <summary>
    /// Tests to make sure the loan validator works
    /// </summary>
    [TestFixture]
    public class LoanRequestValidatorTests
    {
        /// <summary>
        /// Thing being tested
        /// </summary>
        private ILoanRequestValidator _loanRequestValidator;

        /// <summary>
        /// The currency we will use
        /// </summary>
        private Currency _currency;

        /// <summary>
        /// Set up the tests
        /// </summary>
        [SetUp]
        public void set_up()
        {
            //tests in uk gb
            _currency = new Currency(new CultureInfo("en-gb").NumberFormat);
            _loanRequestValidator = new LoanRequestValidator(15000, 1000, 100);
        }

        /// <summary>
        /// Happy path tests to make sure we can validate the loan
        /// </summary>
        [Test]
        public void can_validate_loan()
        {
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var requestLoanFromMarket = new RequestLoanFromMarket(1000, 36, _currency);
            var validRequest = _loanRequestValidator.ValidateLoanRequest(requestLoanFromMarket,
                lenders);
            validRequest.ErrorMessages.Count.Should().Be(0);
            validRequest.IsValid.Should().BeTrue();
        }

        /// <summary>
        /// Makes sure we wont validate a loan over the maximum
        /// </summary>
        [Test]
        public void cannot_validate_loan_request_for_value_over_maximum()
        {
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var requestLoanFromMarket = new RequestLoanFromMarket(17000, 36, _currency);
            var validRequest = _loanRequestValidator.ValidateLoanRequest(requestLoanFromMarket,
                lenders);
            validRequest.ErrorMessages.Count.Should().Be(2);
            validRequest.IsValid.Should().BeFalse();
            validRequest.ErrorMessages.Should().Contain(x => x == "This is more than the maximum allowed. We can only lend up to £15,000.00.");
            validRequest.ErrorMessages.Should().Contain(x => x == "There are not enough funds available to service your request, the maximum we can lend is £2,330.00");
        }

        /// <summary>
        /// Makes sure we wont validate a loan below the minimum
        /// </summary>
        [Test]
        public void cannot_validate_loan_request_for_value_less_than_minimum()
        {
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var requestLoanFromMarket = new RequestLoanFromMarket(100, 36, _currency);
            var validRequest = _loanRequestValidator.ValidateLoanRequest(requestLoanFromMarket,
                lenders);
            validRequest.ErrorMessages.Count.Should().Be(1);
            validRequest.IsValid.Should().BeFalse();
            validRequest.ErrorMessages.Should().Contain(x => x == "This is less than the minimum allowed. Our lending options start at £1,000.00.");
        }

        /// <summary>
        /// Makes sure we wont validate a loan that isnt within our increments
        /// </summary>
        [Test]
        public void cannot_validate_loan_request_for_incremement_that_is_not_100()
        {
            var lenders = TestHelpers.GetSevenLendersForTesting();
            var requestLoanFromMarket = new RequestLoanFromMarket(1790, 36, _currency);
            var validRequest = _loanRequestValidator.ValidateLoanRequest(requestLoanFromMarket,
                lenders);
            validRequest.ErrorMessages.Count.Should().Be(1);
            validRequest.IsValid.Should().BeFalse();
            validRequest.ErrorMessages.Should().Contain(x => x == "This is not an increment of £100.00. Please specify an amount of any £100.00 increment between £1,000.00 and £15,000.00.");
        }
    }
}
