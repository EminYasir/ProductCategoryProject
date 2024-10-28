using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.CategoryDto
{
    public class CategoryAddDto
    {
        [Required(ErrorMessage = "Lütfen Kategori ismini giriniz")]
        public string? CategoryName { get; set; }
    }
}
