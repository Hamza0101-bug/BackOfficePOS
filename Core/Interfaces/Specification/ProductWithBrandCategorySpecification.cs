using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification
{
    public class ProductWithBrandCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithBrandCategorySpecification()
        {
            AddIncludes(x => x.Category);
            AddIncludes(x => x.Brand);
        }

        public ProductWithBrandCategorySpecification(int id) : base(x=>x.Id ==id)
        {
            AddIncludes(x => x.Category);
            AddIncludes(x => x.Brand);
        }
    }
}
