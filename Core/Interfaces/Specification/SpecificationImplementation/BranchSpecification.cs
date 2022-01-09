using Core.Entities;
using Core.Interfaces.Specification.EntitySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification.SpecificationImplementation
{
    public class BranchSpecification : BaseSpecification<Branch>
    {
        public BranchSpecification(int id) : base(x => x.Id == id)
        {

        }
        public BranchSpecification(CommonSpecParams commonSpecParams) :
          base(x =>
          (string.IsNullOrEmpty(commonSpecParams.Search) || x.Name.ToLower().Contains(commonSpecParams.Search)))


        {
            AddPaging(commonSpecParams.PageSize * (commonSpecParams.PageIndex - 1), commonSpecParams.PageSize);

            if (!string.IsNullOrEmpty(commonSpecParams.Sort))
            {
                switch (commonSpecParams.Sort)
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
    public class BranchCountSpec : BaseSpecification<Branch>
    {
        public BranchCountSpec(CommonSpecParams commonSpecParams) :
          base(x =>
          (string.IsNullOrEmpty(commonSpecParams.Search) || x.Name.ToLower().Contains(commonSpecParams.Search)))
        {

        }
    }
}
