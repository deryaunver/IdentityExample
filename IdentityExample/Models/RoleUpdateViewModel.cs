using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Models
{
    public class RoleUpdateViewModel
    {
        public int  Id { get; set; }
        [Required(ErrorMessage = "Düzenleyeceğin rol adını girmek zorunludur.")]
        [Display(Name = "Rol Adı:")]
        public string Name { get; set; }
    }
}
