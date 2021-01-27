using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Models
{
    public class UserSingInViewModel
    {
        [Display(Name = "Kullanıcı Adı:")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez!")]
        public string UserName { get; set; }
        [Display(Name = "Şİfre:")]
        [Required(ErrorMessage = "Şifre Boş Geçilemez!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
