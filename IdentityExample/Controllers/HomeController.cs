using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityExample.Context;
using IdentityExample.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityExample.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View(new UserSingInViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GirisYap(UserSingInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityResult =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
                if (identityResult.IsLockedOut)
                {
                    var gelen = await _userManager.GetLockoutEndDateAsync(
                        await _userManager.FindByNameAsync(model.UserName));
                    var kisitlananSure = gelen.Value;
                    var kalanDakika = kisitlananSure.Minute - DateTime.Now.Minute;
                    ModelState.AddModelError("",$"3 başarısız giriş gerçekleştirdiniz.Hesabınız {kalanDakika} dakika boyunca kitlenmiştir.");
                    return View("Index", model);
                }

                if (identityResult.IsNotAllowed)
                {
                    ModelState.AddModelError("","Email Adresininzi doğrulayınız!");
                }
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Panel");
                }

                var yanlısGirilmeSayisi =
                    await _userManager.GetAccessFailedCountAsync(await _userManager.FindByNameAsync(model.UserName));
                ModelState.AddModelError("",$"Kullancı adı veya şifre hatalı {3-yanlısGirilmeSayisi} giriş hakkınız kaldı!!!");
            }
            return View("Index",model);
        }

        public IActionResult KayitOl()
        {
            return View(new UserSignUpViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> KayitOl(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user=new AppUser
                {
                    Email = model.Email,
                    Name = model.Name,
                    SurName = model.SurName,
                    UserName = model.UserName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                        ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
