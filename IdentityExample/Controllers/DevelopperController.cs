using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace IdentityExample.Controllers
{
    [Authorize(Roles = "Admin,Developper")]
    public class DevelopperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
