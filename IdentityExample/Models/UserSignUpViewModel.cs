using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı:")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez!")]
        public  string UserName { get; set; }
        [Display(Name = "Şİfre:")]
        [Required(ErrorMessage = "Şİfre Boş Geçilemez!")]
        public  string Password { get; set; }
        [Display(Name = "Şİfre Tektar:")]
        [Compare("Password", ErrorMessage = "Parolalar Eşleşmiyor!")]
        public  string ConfirmPassword { get; set; }
        [Display(Name = "Ad:")]
        [Required(ErrorMessage = "Ad Boş Geçilemez!")]
        public  string Name { get; set; }
        [Display(Name = "Soyad:")]
        [Required(ErrorMessage = "Soyad Boş Geçilemez!")]
        public  string SurName { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email Boş Geçilemez!")]
        public  string Email { get; set; }
    }
}
