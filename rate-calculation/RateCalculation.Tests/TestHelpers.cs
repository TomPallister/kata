using System.Collections.Generic;
using RateCalculation.Domain.Model;

namespace RateCalculation.Tests
{
    /// <summary>
    /// Contains helpers for tests
    /// </summary>
    public static class TestHelpers
    {
        /// <summary>
        /// Sets up lenders from market csv
        /// </summary>
        /// <returns></returns>
        public static List<Lender> GetSevenLendersForTesting()
        {
            return new List<Lender>
            {
                new Lender("Bob", 0.075, 640),
                new Lender("Jane", 0.069, 480),
                new Lender("Fred", 0.071, 520),
                new Lender("Mary", 0.104, 170),
                new Lender("John", 0.081, 320),
                new Lender("Dave", 0.074, 140),
                new Lender("Angela", 0.071, 60)
            };
        } 
    }
}
