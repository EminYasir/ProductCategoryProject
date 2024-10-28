using DtoLayer.DTOs.CategoryDto;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {

        public List<CategoryDto> CategoryWithProductCount();
        public List<CategoryListWithCheapestProduct> CategoryWithCheapestPriceProduct();
    }
}
