using AutoMapper;
using BackOfficePOS.DTOs;
using Core.Entities;

namespace BackOfficePOS.Helpers
{
    public class MappingProfilescs :Profile
    {
        public MappingProfilescs()
        {
            // Entity to DTO Mapping for Get

            CreateMap<Product, ProductDto>() 
              .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
              .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
              .ForMember(d => d.ImageName, o => o.MapFrom<ProductImageUrlResolver>());

            CreateMap<Brand, BrandDto>()
                .ForMember(d => d.BrandImage, o => o.MapFrom<BrandImageUrlResolver>());

            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.CategoryImage, o => o.MapFrom<CategoryImageUrlResolver>());
         

            // DTO TO Entity Mapping for save
            CreateMap<productSaveDto , Product>();
            CreateMap<SaveBrandDTO , Brand>();
            CreateMap<CategoryDto , Category>();
        }
    }
}
