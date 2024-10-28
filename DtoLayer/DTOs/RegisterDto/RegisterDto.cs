using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.RegisterDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Ad Alanı Gereklidir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadı Alanı Gereklidir.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Mail Alanı Gereklidir.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Alanı Gereklidir.")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
