using System.Collections.Generic;
using System.IO;
using CsvHelper;
using RateCalculation.Domain.Model;
using RateCalculation.Infrastructure.Extension;

namespace RateCalculation.Infrastructure.Console
{
    /// <inheritdoc />
    public class CsvReaderConsoleService : IDocumentService
    {
        /// <inheritdoc />
        public List<Lender> GetLendersFromDocument(string marketLocation)
        {
            var lenders = new List<Lender>();
            using (var textReader = new StreamReader(marketLocation))
            {
                //This CsvReader could be injected however I have chosen to leave it here
                //as the implementation for a CsvReader and taking it out
                //means the API isn't as nice/easy to follow. It would be easy to switch up
                //and inject it or write another implemetation of the service.
                using (var csvReader = new CsvReader(textReader))
                {
                    while (csvReader.Read())
                    {
                        var name = csvReader.GetSafeValue<string>(0, "Could not load name from Document");
                        var rate = csvReader.GetSafeValue<double>(1, 0);
                        var available = csvReader.GetSafeValue<decimal>(2, 0);
                        var lender = new Lender(name, rate, available);
                        lenders.Add(lender);
                    }
                }
            }
            return lenders;
        }
    }
}
