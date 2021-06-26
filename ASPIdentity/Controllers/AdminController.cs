using Microsoft.AspNetCore.Mvc;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    public partial class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        private IPasswordValidator<AppUser> passwordValidator;
        private IUserValidator<AppUser> userValidator;
        public AdminController(UserManager<AppUser> usrMgr, IPasswordHasher<AppUser> passwordHash, IPasswordValidator<AppUser> passwordVal, IUserValidator<AppUser> userValid) 
            => (userManager, passwordHasher, passwordValidator, userValidator) = (usrMgr, passwordHash, passwordVal, userValid);
        public IActionResult Index() => View(userManager.Users);
        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }
    }
}