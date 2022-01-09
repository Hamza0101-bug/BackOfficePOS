﻿using Core.Entities;
using Core.Interfaces.Specification.EntitySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.Category);
            AddIncludes(x => x.Brand);
        }
        public ProductSpecification(ProductSpecParams proprams) :
            base
            (x =>
            (string.IsNullOrEmpty(proprams.Search) || x.Description.ToLower().Contains(proprams.Search) || x.Name.ToLower().Contains(proprams.Search)) &&
            (string.IsNullOrEmpty(proprams.ItemCode) || x.ItemCode == proprams.ItemCode) &&
            (!proprams.BrandId.HasValue || x.BrandID == proprams.BrandId) &&
            (!proprams.CategoryID.HasValue || x.CategoryID == proprams.CategoryID)&&
            (proprams.AllRecord || x.Active == proprams.Active))
        {
            AddIncludes(x => x.Category);
            AddIncludes(x => x.Brand);
            AddIncludes(x => x.Branch);
            AddOrderby(x => x.Name);
            AddPaging(proprams.PageSize * (proprams.PageIndex - 1), proprams.PageSize);

            if (!string.IsNullOrEmpty(proprams.Sort))
            {
                switch (proprams.Sort)
                {
                    case "priceAsc":
                        AddOrderby(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderbyDesc(p => p.Price);
                        break;
                    default:
                        AddOrderby(n => n.Name);
                        break;
                }
            }
        }
    }

    // For Count Spec 
    public class ProductCountSpec : BaseSpecification<Product>
    {
        public ProductCountSpec(ProductSpecParams productSpecParams) :
           base(x =>
           (string.IsNullOrEmpty(productSpecParams.Search) || x.Description.ToLower().Contains(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
           (!productSpecParams.BrandId.HasValue || x.BrandID == productSpecParams.BrandId) &&
           (!productSpecParams.CategoryID.HasValue || x.CategoryID == productSpecParams.CategoryID))
        {

        }
    }
}