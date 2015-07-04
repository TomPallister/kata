using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RateCalculation.Domain.Model;

namespace RateCalculation.Infrastructure.Repository
{
    /// <summary>
    /// Stub market repository. 
    /// </summary>
    public class StubLenderRepository : ILenderRepository
    {
        /// <summary>
        /// Constructor to set up empty lender repo.
        /// </summary>
        public StubLenderRepository()
        {
            _lenders = new List<Lender>();
        }

        /// <summary>
        /// Constructor to set up repository with pre populated list of lenders.
        /// </summary>
        /// <param name="lenders">A list of lenders to persist to the repository</param>
        public StubLenderRepository(List<Lender> lenders)
        {
            _lenders = lenders;
        }

        /// <summary>
        /// Persists lenders.
        /// </summary>
        private readonly List<Lender> _lenders;

        ///<inheritdoc /> 
        public void Store(Lender lender)
        {
            _lenders.Add(lender);
        }

        ///<inheritdoc /> 
        public void Store(List<Lender> lenders)
        {
            _lenders.AddRange(lenders);
        }

        ///<inheritdoc /> 
        public IEnumerable<Lender> FindBy(Expression<Func<Lender, bool>> predicate)
        {
            return _lenders.AsQueryable().Where(predicate);
        }
    }
}
