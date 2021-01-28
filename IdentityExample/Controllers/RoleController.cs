using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityExample.Context;
using IdentityExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IdentityExample.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult AddRole()
        {
            return View(new RoleViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.Name
                };
                var identityResult = await _roleManager.CreateAsync(role);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        public IActionResult UpdateRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(I => I.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var tobeUpdateRole = _roleManager.Roles.Where(I => I.Id == model.Id).FirstOrDefault();
            tobeUpdateRole.Name = model.Name;
            var identityResult = await _roleManager.UpdateAsync(tobeUpdateRole);
            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        public async Task< IActionResult> DeleteRole(int id)
        {
             var tobeDeletedRole=_roleManager.Roles.FirstOrDefault(I => I.Id == id);
              var identityResult = await _roleManager.DeleteAsync(tobeDeletedRole);
              if (identityResult.Succeeded)
              {
                  return RedirectToAction("Index");
              }

              TempData["Errors"] = identityResult.Errors;
              return RedirectToAction("Index");
              // return View();
        }
        public IActionResult UserLİst()
        {
            return View(_userManager.Users.ToList());
        }
    }
}
