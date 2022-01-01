using AutoMapper;
using BackOfficePOS.DTOs;
using Core.Entities;

namespace BackOfficePOS.Helpers
{
    public class MappingProfilescs :Profile
    {
        public MappingProfilescs()
        {
            CreateMap<Product, ProductDto>()
              .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
              .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
              .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<Brand, BrandDto>();
            CreateMap<productSaveDto , Product>();
        }
    }
}
