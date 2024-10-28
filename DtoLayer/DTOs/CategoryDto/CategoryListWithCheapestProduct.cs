using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.CategoryDto
{
    public class CategoryListWithCheapestProduct
    {
        public int Id { get; set; }
        public string? categoryName { get; set; }
        public int productId { get; set; }
        public string? productName { get; set; }
        public decimal productPrice { get; set; }
    }
}
