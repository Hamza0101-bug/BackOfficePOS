using Core.Entities;
using Core.Interfaces.Specification.EntitySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification.EnitiySpecificationImplementation.SpectForData
{
    public class CategorySpecification : BaseSpecification<Category>
    {
        public CategorySpecification(int id) : base(x => x.Id == id)
        {

        }
        public CategorySpecification(CategorySpecParams categorySpecParams) :
          base(x =>
          (string.IsNullOrEmpty(categorySpecParams.Search) || x.ShortDescription.ToLower().Contains(categorySpecParams.Search) || x.Description.ToLower().Contains(categorySpecParams.Search) || x.Name.ToLower().Contains(categorySpecParams.Search)))
           {
            AddPaging(categorySpecParams.PageSize * (categorySpecParams.PageIndex - 1), categorySpecParams.PageSize);

            if (!string.IsNullOrEmpty(categorySpecParams.Sort))
            {
                switch (categorySpecParams.Sort)
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
    // For Count 
    public class CategoryCountSpec : BaseSpecification<Category>
    {
        public CategoryCountSpec(CategorySpecParams categorySpecParams) :
          base(x =>
          (string.IsNullOrEmpty(categorySpecParams.Search) || x.ShortDescription.ToLower().Contains(categorySpecParams.Search) || x.Description.ToLower().Contains(categorySpecParams.Search) || x.Name.ToLower().Contains(categorySpecParams.Search)))
        {

        }
    }


    // for id 
   

}
