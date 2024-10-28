using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DtoLayer.DTOs.CategoryDto;
using DtoLayer.DTOs.ProductDto;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ProductManager(IProductDal productRepository, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _productDal = productRepository;
            _mapper = mapper;
            _context = applicationDbContext;
        }

        public List<ProductDto> ProductsWithCategoryInfos()
        {
            var products = _context.Products.ToList();
            var category=_context.Categories.ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(products).ToList();
            foreach (var dto in productDtos)
            {
                dto.CategoryName = category.FirstOrDefault(x => x.Id == dto.CategoryId).CategoryName;
            }
            return productDtos;
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);

        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TInsert(Product t)
        {
            _productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
