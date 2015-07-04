using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RateCalculation.Domain.Model;

namespace RateCalculation.Infrastructure.Repository
{
    /// <summary>
    /// The lender repository contract.
    /// </summary>
    public interface ILenderRepository
    {   
        /// <summary>
        /// Stores a lender in the lender repository.
        /// </summary>
        /// <param name="lender"></param>
        void Store(Lender lender);
        /// <summary>
        /// Stores a list of lenders in the lender repository.
        /// </summary>
        /// <param name="lender"></param>
        void Store(List<Lender> lender);
        /// <summary>
        /// Finds lenders using a lambda expression.
        /// </summary>
        /// <param name="predicate">Lambda expression to find lenders in lender repository</param>
        /// <returns></returns>
        IEnumerable<Lender> FindBy(Expression<Func<Lender, bool>> predicate);
    }
}
