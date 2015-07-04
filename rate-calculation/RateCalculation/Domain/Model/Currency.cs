using System.Globalization;

namespace RateCalculation.Domain.Model
{
    /// <summary>
    /// The curreny value object. NumberFormatInfo isn't very expressive so we make it more
    /// expresive with the value object.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Default constructor takes a numberformatinfo which is the currency.
        /// </summary>
        /// <param name="numberFormatInfo">Currency the loan request is made with.</param>
        public Currency(NumberFormatInfo numberFormatInfo)
        {
            Value = numberFormatInfo;
        }

        /// <summary>
        /// Exposes the Currency vale.
        /// </summary>
        public NumberFormatInfo Value { get; private set; }
    }
}
