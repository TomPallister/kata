using System.Collections.Generic;
using NUnit.Framework;
using RateCalculation.Domain.Model;
using RateCalculation.Infrastructure.Console;

namespace RateCalculation.Tests
{
    /// <summary>
    /// Tests for the service that prints things
    /// </summary>
    [TestFixture]
    public class PrintServiceTests
    {
        /// <summary>
        /// This is being tested
        /// </summary>
        private IPrintService _printService;

        /// <summary>
        /// Sets up the tests
        /// </summary>
        [SetUp]
        public void set_up()
        {
            //we are testing the console print service
            _printService = new ConsolePrintService();
        }

        /// <summary>
        /// Happy path to make sure we can print the response to loan request without errors
        /// </summary>
        [Test]
        public void can_print_response_to_loan_request()
        {
            var responseToLoanRequest = new ResponseToLoanRequest(new Quote(new decimal(12), 12, new decimal(58), new decimal(96)), new ValidLoanRequest(new List<string>(), false ));
            _printService.PrintResponseToLoanRequest(responseToLoanRequest);
        }
    }
}
