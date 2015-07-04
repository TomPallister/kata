using System.Collections.Generic;
using RateCalculation.Domain.Model;

namespace RateCalculation.Infrastructure.Console
{
    /// <summary>
    /// This service gets a list of lenders from a document.
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Gets a list of lenders from a document.
        /// </summary>
        /// <param name="marketLocation">The documents location on the file system</param>
        /// <returns></returns>
        List<Lender> GetLendersFromDocument(string marketLocation);
    }
}
