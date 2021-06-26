using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Identity.Models;

namespace Identity.Controllers
{
    [Authorize]
    public partial class ClaimsController : Controller
    {
        private UserManager<AppUser> userManager;
        public ClaimsController(UserManager<AppUser> userMgr)
            => userManager = userMgr;
        public ViewResult Index() => View(User?.Claims);
        void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        [Authorize(Policy = "AspManager")]
        public ViewResult Project() => View("Index", User?.Claims);
        [Authorize(Policy = "AllowTom")]
        public ViewResult TomFiles() => View("Index", User?.Claims);
    }
}