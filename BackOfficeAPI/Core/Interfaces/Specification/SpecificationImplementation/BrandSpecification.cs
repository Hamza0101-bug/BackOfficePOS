using Core.Entities;
using Core.Interfaces.Specification.EntitySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification.EnitiySpecificationImplementation.SpectForData
{

    public class BrandSpecification :BaseSpecification<Brand>
    {
        public BrandSpecification() : base()
        {

        }
        public BrandSpecification(int id) : base(x=>x.Id == id)
        {

        }
        public BrandSpecification(BrandSpecParams brandSpecParams) :
          base(x =>
          (string.IsNullOrEmpty(brandSpecParams.Search) || x.Name.ToLower().Contains(brandSpecParams.Search))) 
        {
            AddIncludes(x => x.Branch);
            AddOrderby(x => x.Name);
            AddPaging(brandSpecParams.PageSize * (brandSpecParams.PageIndex - 1), brandSpecParams.PageSize);

            if (!string.IsNullOrEmpty(brandSpecParams.Sort))
            {
                switch (brandSpecParams.Sort)
                {
                    case "NameAsc":
                        AddOrderby(x => x.Name);
                        break;
                    case "NameDesc":
                        AddOrderbyDesc(p => p.Name);
                        break;
                    default:
                        AddOrderby(n => n.Name);
                        break;
                }
            }
        }
    }

    // For Count Specification
    public class BrandCountSpec : BaseSpecification<Brand>
    {
        public BrandCountSpec(BrandSpecParams brandSpecParams) :
          base(x =>
          (string.IsNullOrEmpty(brandSpecParams.Search) || x.Name.ToLower().Contains(brandSpecParams.Search)))
          {

          }
    }
}
