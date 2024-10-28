using DtoLayer.DTOs.ProductDto;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        public List<ProductDto> ProductsWithCategoryInfos();
    }
}
