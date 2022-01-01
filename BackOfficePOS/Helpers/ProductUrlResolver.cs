using AutoMapper;
using BackOfficePOS.DTOs;
using Core.Entities;

namespace BackOfficePOS.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(
            Product source, 
            ProductDto destination, 
            string destMember,
            ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["ApiUrl"] + source.ImageUrl;
            }
            return null;
        }
    }
}
