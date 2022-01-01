using Core.Entities;
using Core.Interfaces.Specification.EntitySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification.EnitiySpecificationImplementation.SpecForCount
{
    public class BrandWithFilterCountSpec : BaseSpecification<Brand> 
    {
        public BrandWithFilterCountSpec(CommonSpecParams commonSpecParams) :
          base(x =>
          (string.IsNullOrEmpty(commonSpecParams.Search) || x.Name.ToLower().Contains(commonSpecParams.Search)))
           {

           }
    }
}
