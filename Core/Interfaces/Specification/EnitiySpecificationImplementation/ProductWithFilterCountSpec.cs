using Core.Entities;
using Core.Interfaces.Specification.EntitySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification.EnitiySpecificationImplementation
{
    public class ProductWithFilterCountSpec : BaseSpecification<Product>
    {
        public ProductWithFilterCountSpec(ProductSpecParams productSpecParams) :
           base(x =>
           (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
           (!productSpecParams.BrandId.HasValue || x.BrandID == productSpecParams.BrandId) &&
           (!productSpecParams.CategoryID.HasValue || x.CategoryID == productSpecParams.CategoryID))
        {

        }
    }
}
