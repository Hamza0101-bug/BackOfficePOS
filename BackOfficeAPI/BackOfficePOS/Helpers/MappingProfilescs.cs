using API.Dtos;
using AutoMapper;
using BackOfficePOS.DTOs;
using Core.Entities;
using Core.Entities.Identity;

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
              .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.Name))
              .ForMember(d => d.ImageName, o => o.MapFrom<ProductImageUrlResolver>());

            CreateMap<Brand, BrandDto>()
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.Name))
                .ForMember(d => d.BrandImage, o => o.MapFrom<BrandImageUrlResolver>());

            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.Name))
                .ForMember(d => d.CategoryImage, o => o.MapFrom<CategoryImageUrlResolver>());
            CreateMap<Branch, BranchDto>();
            CreateMap<Address, AddressDto>();


            // DTO TO Entity Mapping for save
            CreateMap<productSaveDto , Product>();
            CreateMap<SaveBrandDTO , Brand>();
            CreateMap<CategoryDto , Category>();
            CreateMap<BranchDto , Branch>();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
