using AutoMapper;
using DtoLayer.DTOs.CategoryDto;
using DtoLayer.DTOs.ProductDto;
using DtoLayer.DTOs.RegisterDto;
using EntityLayer.Models;

namespace ProductCategoryAPI.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListWithCheapestProduct>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            CreateMap<User,RegisterDto>().ReverseMap()
                .ForMember(dest=>dest.UserName,opt =>opt.MapFrom(src=>src.Mail))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest=>dest.RealPassword,opt=>opt.MapFrom(src=>src.Password));



            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}