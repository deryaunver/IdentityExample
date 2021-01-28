using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IdentityExample.Models
{
    public class UserUpdateViewModel
    {
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "* Email alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz!")]
        public string Email { get; set; }
        [Display(Name = "Ad:")]
        [Required(ErrorMessage = "* Ad alanı zorunludur")]
        public string Name { get; set; }
        [Display(Name = "Soyad:")]
        [Required(ErrorMessage = "* Soyad alanı zorunludur")]
        public string SurName { get; set; }
        public string PictureUrl { get; set; }
        public IFormFile Picture { get; set; }
        [Display(Name = "Telefon:")]
        public string PhoneNumber { get; set; }
    }
}
