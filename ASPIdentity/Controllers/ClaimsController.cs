using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Identity.Models;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Identity.Controllers
{
    [Authorize]
    public partial class ClaimsController : Controller
    {
        private ILogger<ClaimsController> _logger;
        private UserManager<AppUser> userManager;
        public ClaimsController(UserManager<AppUser> userMgr, ILogger<ClaimsController> logger)
            => (userManager, _logger) = (userMgr, logger);
        public ViewResult Index() => View(User?.Claims);
        void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [Authorize(Policy = "AspManager")]
        public ViewResult Project()
        {
            /*foreach (ClaimsIdentity claimsidentity in User?.Identities)
                    _logger.LogInformation("The type is {type}", claimsidentity.Name);*/
            //Its Tom, if by default
            /*string Issuer = "https://gov.uk";
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, "Andrew", ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.Surname, "Lock", ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.Country, "UK", ClaimValueTypes.String, Issuer),
                new Claim("ChildhoodHero", "Tom", ClaimValueTypes.String)
            };
            ClaimsIdentity newIdentity = new ClaimsIdentity(claims, "Passport");
            User?.AddIdentity(newIdentity);*/
            //Successfully added but not refereshed in AspnetUserClaim
            return View("Index", User?.Claims);
        }
        /*[Authorize(Policy = "AspManager")]
        public ViewResult Project() => View("Index", User?.Claims);*/
        [Authorize(Policy = "AllowTom")]
        public ViewResult TomFiles() => View("Index", User?.Claims);
    }
}