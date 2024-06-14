using EntityLayer.Concrete;
using Mail_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mail_App.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterViewModel createRegister)
        {
            if (createRegister.Password != null)
            {
                AppUser appUser = new AppUser()
                {
                    Name = createRegister.Name,
                    Surname = createRegister.Surname,
                    Email = createRegister.Email,
                    UserName = createRegister.Username,
                    ImageUrl = "https://static-00.iconduck.com/assets.00/user-icon-2048x2048-ihoxz4vq.png"
                };


                if (createRegister.Password == createRegister.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, createRegister.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }

            return View();
        }
    }
}
