using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification( Expression<Func<T, bool>> criteria) // for whare purpose
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get; } // Property
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>(); // Property
        protected void AddIncludes(Expression<Func<T, Object>> IncludeExpression)
        {
            Includes.Add(IncludeExpression);
        }
        // Order By Word
        public Expression<Func<T, object>> Orderby { get; private set;} // Property

        protected void AddOrderby(Expression<Func<T, Object>> OrderbyExpression)
        {
            Orderby = OrderbyExpression;
        }

        public Expression<Func<T, object>> OrderbyDesc { get; private set; } // Property


        protected void AddOrderbyDesc(Expression<Func<T, Object>> OrderbyDescExpression)
        {
            OrderbyDesc = OrderbyDescExpression;
        }


        // Pagination work
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddPaging(int skip, int take)
        {
            Take = take;
            Skip = skip;    
            IsPagingEnabled = true; 
        }

    }
}
