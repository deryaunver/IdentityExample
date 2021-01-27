using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityExample.Context
{
    public class AppUser:IdentityUser<int>
    {
        public  string PictureUrl { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public  string SurName { get; set; }

    }
}
