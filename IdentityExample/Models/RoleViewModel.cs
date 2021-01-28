using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IdentityExample.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Ad alanı gereklidir!!")]
        [Display(Name = "Rol Adı: ")]
        public string Name { get; set; }
    }
}
