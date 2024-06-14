using EntityLayer.Concrete;
using Mail_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mail_App.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signınManager;

        public LoginController(SignInManager<AppUser> signınManager)
        {
            _signınManager = signınManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSıgnViewModel sıgnViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signınManager.PasswordSignInAsync(sıgnViewModel.UserName, sıgnViewModel.Password, false, true); 
                if (result.Succeeded) 
                {
                    return RedirectToAction("InBox", "MailMessage");
                }
                else
                {
                    ModelState.AddModelError("","Hatalı Kullanıcı veya şifre yanlış !");
                }
            }
            return View();
        } 
        public async Task<IActionResult> LogOut()
        {
            await _signınManager.SignOutAsync(); 
            return RedirectToAction("Index","Login");
        }
    }
}
