using Core.Entities;
using Core.Interfaces.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.SpecificationEvaluator
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuary(IQueryable<TEntity> inputQuary,
            ISpecification<TEntity> spec)
        {
            var quary = inputQuary;
            if(spec.Criteria != null)
            {
                quary = quary.Where(spec.Criteria);
            }
            if (spec.Orderby != null)
            {
                quary = quary.OrderBy(spec.Orderby);
            }
            if (spec.OrderbyDesc != null)
            {
                quary = quary.OrderByDescending(spec.OrderbyDesc);
            }
            if (spec.IsPagingEnabled)
            {
                quary = quary.Skip(spec.Skip).Take(spec.Take);
            }
            quary = spec.Includes
                .Aggregate(quary, (current, includs) => current
                 .Include(includs));
            return quary;
        }
    }
}
