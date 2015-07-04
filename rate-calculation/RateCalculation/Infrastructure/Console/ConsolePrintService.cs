using RateCalculation.Domain.Model;

namespace RateCalculation.Infrastructure.Console
{    
    /// <inheritdoc />
    public class ConsolePrintService : IPrintService
    {    
        /// <inheritdoc />
        public void PrintResponseToLoanRequest(ResponseToLoanRequest responseToLoanRequest)
        {
            if (responseToLoanRequest.ValidLoanRequest.IsValid)
            {
                //print result
                System.Console.WriteLine("Requested amount: £{0}", responseToLoanRequest.Quote.RequestedAmount);
                System.Console.WriteLine("Rate: {0}%", responseToLoanRequest.Quote.Rate);
                System.Console.WriteLine("Monthly repayment: £{0}", responseToLoanRequest.Quote.MonthlyRepayment);
                System.Console.WriteLine("Total repayment: £{0}", responseToLoanRequest.Quote.TotalRepyment);
            }
            else
            {
                //print errors
                foreach (var error in responseToLoanRequest.ValidLoanRequest.ErrorMessages)
                {
                    System.Console.WriteLine(error);
                }
            }
        }
    }
}
