using System;
using System.Collections.Generic;
using System.Linq;
using RateCalculation.Domain.Model;

namespace RateCalculation.Domain.Service
{
    /// <summary>
    /// This class is used to do the loan calculations.
    /// </summary>
    public class LoanCalculator : ILoanCalculator
    {    
        /// <inheritdoc />
        public IEnumerable<Offer> GetTheBestAvailableOffersFromLenders(IEnumerable<Lender> lenders, decimal requestedLoadAmount)
        {
            //order the lenders by best rate
            lenders = lenders.OrderBy(x => x.Rate).ToList();
            //container to store offers
            var offers = new List<Offer>();
            //loop through the lenders
            foreach (var lender in lenders)
            {
                //get the total already offered.
                var totalOffered = offers.Sum(item => item.Amount);
                //if the total offered is less than the requested amount
                if (totalOffered < requestedLoadAmount)
                {
                    //add a new offer which will be either the full amount the lender has available or 
                    //the amount that the system needs to make up the requested loan amount.
                    offers.Add(new Offer(Math.Min(lender.Available, requestedLoadAmount - totalOffered),
                        lender.Rate));
                }
                //we have enough offers
                else
                {
                    //end the loop
                    break;
                }
            }
            //return the offers to the caller.
            return offers;
        }

        /// <inheritdoc />
        public Quote CalculateQuoteFromOffers(IEnumerable<Offer> offers, int numberOfRepaymentMonths, decimal requestedAmount)
        {
            //the total amount to repay calculated from the available offers we already selected
            var totalAmountToRepay = offers.Sum(x => CalculateTotalRepaymentAmountPerOffer(x, numberOfRepaymentMonths));
            //the amount the borrower has to repay each month
            var monthlyRepayment = totalAmountToRepay/numberOfRepaymentMonths;
            //work out the rate using the following formula
            //http://www.calculatorsoup.com/calculators/financial/compound-interest-calculator-periodic.php
            //formula is further down the page.
            //r = (A/P)^(1/t) - 1
            //Where:
            //A = Accrued Amount (principal + interest)
            //P = Principal Amount
            //r = Rate of Interest per period as a decimal
            //t = Number of Periods
            //I use math.pow to raise the power correctly.
            //    r                            a                    o                                    t                         
            var rate = (Math.Pow((double)(totalAmountToRepay / requestedAmount), (1.0 / ((double)numberOfRepaymentMonths / 12))) - 1);
            //we format the quote to specification and return it to the caller
            return FormatQuote(new Quote(requestedAmount, rate, monthlyRepayment, totalAmountToRepay), numberOfRepaymentMonths);
        }

        /// <summary>
        /// Calculates the total repayment amount for an offer
        /// </summary>
        /// <param name="offer">The offer</param>
        /// <param name="numberOfRepaymentMonths">The number of repayment months</param>
        /// <returns>a decimal amount that represents the repayment amount</returns>
        private decimal CalculateTotalRepaymentAmountPerOffer(Offer offer, int numberOfRepaymentMonths)
        {
            //This uses the following formula
            //http://www.thecalculatorsite.com/articles/finance/compound-interest-formula.php
            //A = P (1 + r/n) ^ nt:
            //Where:
            //A = the future value of the investment/loan, including interest
            //P = the principal investment amount (the initial deposit or loan amount)
            //r = the annual interest rate (decimal)
            //n = the number of times that interest is compounded per year
            //t = the number of years the money is invested or borrowed for
            //I use math.pow to raise the power correctly.
            //              P                                 r        n    nt (we use the number of repayment months because we already have it.
            return offer.Amount * (decimal)Math.Pow(1 + (offer.Rate / 12), numberOfRepaymentMonths);
        }

        /// <summary>
        /// Takes the quote and formats it to specification. I'm not sure how the rounding
        /// should be done (lack of experience in finance!!)
        /// </summary>
        /// <returns>The formatted quote</returns>
        private Quote FormatQuote(Quote quote, int numberOfRepaymentMonths)
        {
            //round the total amount to 2 decimal place
            var formattedTotalAmountToRepay = decimal.Round(quote.TotalRepyment, 2);
            //round the rate to 1 decimal place
            var formattedRate = Math.Round(quote.Rate, 1);
            //round the monthly repayment to 2 decimal place
            var formattedMonthlyRepayment = decimal.Round(quote.MonthlyRepayment, 2);
            //there is a little domain problem here im not sure how to handle where 
            //figures dont add up after rounding and stuff
            //I think that it is best to not overcharge customers
            var overcharged = (formattedMonthlyRepayment*numberOfRepaymentMonths) >= formattedTotalAmountToRepay;
            //if the person is overcharged
            if (overcharged)
            {
                //then the total amount they should repay is the monthly repayment * the number of months.
                formattedTotalAmountToRepay = formattedMonthlyRepayment*numberOfRepaymentMonths;
            }
            //return a formatted quote.
            return new Quote(quote.RequestedAmount, formattedRate, formattedMonthlyRepayment, formattedTotalAmountToRepay);
        }
    }
}
