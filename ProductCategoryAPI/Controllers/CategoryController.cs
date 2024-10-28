using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DTOs.CategoryDto;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductCategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult ListAllCategoriesAsync()
        {
            var categories = _categoryService.CategoryWithProductCount();
            return Ok(categories);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("[action]")]
        public ActionResult AddCategory(CategoryAddDto categoryAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var value = _mapper.Map<Category>(categoryAddDto);

            try
            {
                _categoryService.TInsert(value);
                return Ok("Kategori eklendi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult CategoryWithCheapestPriceProduct()
        {
            var categories = _categoryService.CategoryWithCheapestPriceProduct();
            return Ok(categories);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("[action]")]
        public ActionResult UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // Kategori var mı kontrolü
            var existingCategory = _categoryService.TGetByID(categoryUpdateDto.Id);
            if (existingCategory == null)
            {
                return NotFound("Belirtilen kategori ID'sine sahip bir kategori bulunamadı.");
            }

            _mapper.Map(categoryUpdateDto, existingCategory);

            try
            {
                _categoryService.TUpdate(existingCategory);
                return Ok("Kategori Güncellendi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }

        }

    }
}
