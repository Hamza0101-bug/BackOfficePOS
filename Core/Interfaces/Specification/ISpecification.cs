using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification
{
    public interface ISpecification<T>
    {

        // In this Interface we define expression for critera and Expression of Includs list
        // for navigation properies lik product have category so for get the product with category 
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, Object>>> Includes { get; }
        Expression<Func<T, Object>> Orderby { get; }
        Expression<Func<T, Object>> OrderbyDesc { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
