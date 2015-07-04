using System;
using System.Configuration;
using System.Globalization;
using Microsoft.Practices.Unity;
using RateCalculation.Domain.Command;
using RateCalculation.Domain.Service;
using RateCalculation.Infrastructure.Console;
using RateCalculation.Infrastructure.Repository;

namespace RateCalculation
{
    /// <summary>
    /// The main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// IoC container used to resolve constructor dependencies.
        /// </summary>
        private static UnityContainer _unityContainer;

        /// <summary>
        /// Entry point for application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //bootstrap dependency injection container, this is probably overkill
            //for a console app but I wanted to show and understanding of IoC
            _unityContainer = Bootstrap();
            //check we have the correct number of arguments
            if (args.Length == 2)
            {
                //try and get the quote
                GetQuote(args);
            }
            else
            {
                //let the user know they didnt call the app correctly
                Console.WriteLine("Please pass in arguments to this application as follows");
                Console.WriteLine("cmd> [application] [market_file] [loan_amount]");
            }
        }

        /// <summary>
        /// This method takes the arguments passed into the console and attempts to get a quote.
        /// </summary>
        /// <param name="args"></param>
        private static void GetQuote(string[] args)
        {
            var marketService = _unityContainer.Resolve<IMarketService>();
            var consoleService = _unityContainer.Resolve<IDocumentService>();
            var printService = _unityContainer.Resolve<IPrintService>();
            //receive a request for a loan which has the current market and the loan amount required..
            var documentLocation = args[0];
            var loanAmountRequested = Convert.ToDecimal(args[1]);
            var numberOfRepaymentMonths = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfRepaymentMonths"]);
            //parse the document to get the lenders
            var lenders = consoleService.GetLendersFromDocument(documentLocation);
            //persist the current market
            var addLendersToMarket = new AddLendersToMarket(lenders);
            marketService.AddLendersToMarket(addLendersToMarket);
            //try and get the loan requested
            var requestLoanFromMarket = new RequestLoanFromMarket(loanAmountRequested, numberOfRepaymentMonths, new Domain.Model.Currency(new CultureInfo("en-gb").NumberFormat));
            var responseToLoanRequest = marketService.RequestQuoteFromMarket(requestLoanFromMarket);
            printService.PrintResponseToLoanRequest(responseToLoanRequest);
        }

        /// <summary>
        /// Sets up IoC container. 
        /// </summary>
        private static UnityContainer Bootstrap()
        {
            var printService = new ConsolePrintService();
            var loanCalculator = new LoanCalculator();
            var consoleService = new CsvReaderConsoleService();
            var lenderRepository = new StubLenderRepository();
            var loanRequestValidator = new LoanRequestValidator(15000, 1000, 100);
            var marketService = new MarketService(lenderRepository, loanCalculator, loanRequestValidator);
            var unityContainer = new UnityContainer();
            unityContainer.RegisterInstance<IMarketService>(marketService);
            unityContainer.RegisterInstance<ILenderRepository>(lenderRepository);
            unityContainer.RegisterInstance<IDocumentService>(consoleService);
            unityContainer.RegisterInstance<ILoanCalculator>(loanCalculator);
            unityContainer.RegisterInstance<ILoanRequestValidator>(loanRequestValidator);
            unityContainer.RegisterInstance<IPrintService>(printService);
            return unityContainer;
        }
    }
}
