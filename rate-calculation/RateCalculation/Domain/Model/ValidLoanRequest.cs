using System.Collections.Generic;

namespace RateCalculation.Domain.Model
{
    /// <summary>
    /// Model used as a response when a loan request is validated.
    /// </summary>
    public class ValidLoanRequest
    {
        /// <summary>
        /// Default constructor takes all properties.
        /// </summary>
        /// <param name="errorMessages">A list of error messages</param>
        /// <param name="isValid">Was the loan request valid</param>
        public ValidLoanRequest(List<string> errorMessages, bool isValid )
        {
            ErrorMessages = errorMessages;
            IsValid = isValid;
        }

        /// <summary>
        /// A list of error messages
        /// </summary>
        public List<string> ErrorMessages { get; private set; } 

        /// <summary>
        /// Was the loan request valid
        /// </summary>
        public bool IsValid { get; private set; }
    }
}
