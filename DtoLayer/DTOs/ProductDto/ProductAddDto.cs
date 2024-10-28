using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.ProductDto
{
    public class ProductAddDto
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Lütfen Ürün İsmini giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Ürün Açıklamasını giriniz")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Lütfen Ürün Fiyatını giriniz")]
        public decimal Price { get; set; }
    }
}
