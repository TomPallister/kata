using NUnit.Framework;

namespace RateCalculation.Tests
{
    /// <summary>
    /// end to end tests
    /// </summary>
    [TestFixture]
    public class EndToEndTests
    {
        /// <summary>
        /// Makes sure we can run the end to end process without expections
        /// When the test project builds it moves the files in the TestData folder
        /// into the root of bin which is why we can pass in market.csv
        /// </summary>
        [Test]
        public void can_get_loan_from_the_market_happy_path_should_not_throw_exception()
        {
            string[] args = { "market.csv", "1000" };
            Program.Main(args);
        }
    }
}
