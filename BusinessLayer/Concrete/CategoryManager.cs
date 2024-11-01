using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOs.CategoryDto;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;


        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _context = applicationDbContext;
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);

        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TInsert(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }

        public List<CategoryDto> CategoryWithProductCount()
        {
            var categoryWithProducts = _context.Categories.Include(x => x.Products).ToList();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categoryWithProducts).ToList();
            //var results = categoryWithProducts.Select(x => x.Products.Count()).ToList();

            //foreach (var dto in categoryDtos)
            //{
            //    dto.ProductCount = results.FirstOrDefault(c => c.Id == dto.Id)?.Products.Count() ?? 0;
            //}
            return categoryDtos;
        }

        public List<CategoryListWithCheapestProduct> CategoryWithCheapestPriceProduct()
        {

            var categoryWithProducts = _context.Categories.Include(x=>x.Products).ToList();
            var categoryWithMinPriceProducts = categoryWithProducts.Select(x => x.Products.OrderBy(p=>p.Price).FirstOrDefault()).ToList();
            var categoryProductDtos = _mapper.Map<List<CategoryListWithCheapestProduct>>(categoryWithMinPriceProducts).ToList();
            //foreach (var categoryProduct in categoryProductDtos)
            //{
            //    //var lowestPrice = _context.Products.Where(x=>x.CategoryId== categoryProduct.Id).Min(x => x.Price);
            //    //var lowestPriceProduct = _context.Products.Where(x => x.Price == lowestPrice).ToList();
            //    //var productDtos = _mapper.Map<List<ProductDto>>(lowestPriceProduct).ToList();
            //    var lowestPriceProduct = _context.Products
            //                             .Where(x => x.CategoryId == categoryProduct.Id)
            //                             .OrderBy(x => x.Price)
            //                             .FirstOrDefault();
            //    if (lowestPriceProduct != null)
            //    {
            //        categoryProduct.productId = lowestPriceProduct.Id;
            //        categoryProduct.productName = lowestPriceProduct.Name;
            //        categoryProduct.productPrice = lowestPriceProduct.Price;
            //    }
            //}
            return categoryProductDtos;
        }
    }
}
