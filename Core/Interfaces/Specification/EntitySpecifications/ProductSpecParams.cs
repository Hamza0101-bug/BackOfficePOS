using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification.EntitySpecifications
{
    public class ProductSpecParams : CommonSpecParams
    {
      
        
        public int? BrandId { get; set; }
        public int? CategoryID { get; set; }
        public int? BranchID { get; set; }
        public string?  ItemCode { get; set; }


    }
}
