using RateCalculation.Domain.Model;

namespace RateCalculation.Infrastructure.Console
{
    /// <summary>
    /// This service can be used to print output.
    /// </summary>
    public interface IPrintService
    {
        /// <summary>
        /// Prints the response to loan request.
        /// </summary>
        /// <param name="responseToLoanRequest">The response to loan request</param>
        void PrintResponseToLoanRequest(ResponseToLoanRequest responseToLoanRequest);
    }
}
