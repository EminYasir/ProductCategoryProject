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
            CreateMap<CategoryDto, Category>().ReverseMap()
                .ForMember(dest=>dest.ProductCount, opt =>opt.MapFrom(src=>src.Products.Count()));

            CreateMap<CategoryListWithCheapestProduct, Product>().ReverseMap()
                .ForMember(dest => dest.categoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.categoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.productId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.productPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.Name));

            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            CreateMap<User,RegisterDto>().ReverseMap()
                .ForMember(dest=>dest.UserName,opt =>opt.MapFrom(src=>src.Mail))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest=>dest.RealPassword,opt=>opt.MapFrom(src=>src.Password));



            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        }
    }
}
