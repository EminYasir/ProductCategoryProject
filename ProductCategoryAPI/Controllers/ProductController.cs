using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DTOs.ProductDto;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;


        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult ProductList()
        {
            var products = _productService.ProductsWithCategoryInfos();
            return Ok(products);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public ActionResult AddProduct(ProductAddDto productAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var productDto = _mapper.Map<Product>(productAddDto);
            _productService.TInsert(productDto);
            return Ok("Ürün başarıyla eklendi");
        }
    }
}
