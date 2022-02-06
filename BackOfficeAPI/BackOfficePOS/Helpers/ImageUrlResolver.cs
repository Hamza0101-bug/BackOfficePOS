using AutoMapper;
using BackOfficePOS.DTOs;
using Core.Entities;

namespace BackOfficePOS.Helpers
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;
        public ProductImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(
            Product source, 
            ProductDto destination, 
            string destMember,
            ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageName))
            {
                return _config["ApiUrl"]+"Images/ProductImages/"+ source.ImageName;
            }
            return null;
        }
    }
    public class BrandImageUrlResolver : IValueResolver<Brand, BrandDto, string>
    {
        private readonly IConfiguration _config;
        public BrandImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(
            Brand source,
            BrandDto destination,
            string destMember,
            ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.BrandImage))
            {
                return _config["ApiUrl"] + "Images/BrandImages/" + source.BrandImage;
            }
            return null;
        }
    }
    public class CategoryImageUrlResolver : IValueResolver<Category, CategoryDto, string>
    {
        private readonly IConfiguration _config;
        public CategoryImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(
            Category source,
            CategoryDto destination,
            string destMember,
            ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.CategoryImage))
            {
                return _config["ApiUrl"] + "Images/BrandImages/" + source.CategoryImage;
            }
            return null;
        }
    }
}
