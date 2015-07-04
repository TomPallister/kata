namespace RateCalculation.Domain.Model
{
    /// <summary>
    /// The lender model, this is used to represent the current state of a lender.
    /// </summary>
    public class Lender
    {
        /// <summary>
        /// Default constructor for the lender model.
        /// </summary>
        /// <param name="name">The name of the lender</param>
        /// <param name="rate">The rate they are offering</param>
        /// <param name="available">The amound of money they have to lend</param>
        public Lender(string name, double rate, decimal available)
        {
            Name = name;
            Rate = rate;
            Available = available;
        }

        /// <summary>
        /// The name of the Lender.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The rate the lender is offering.
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// The amount of money the lender has available.
        /// </summary>
        public decimal Available { get; set; }
    }
}
