using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;
using Microsoft.AspNet.Identity.EntityFramework;

using WebApplication1.ViewModel;
namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    [HandleError]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AuthController()
            : this(Startup.UserManagerFactory.Invoke())
        {

        }
        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return PartialView("Login", model);
        }
        [HttpPost]
        
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();//View("Login",model);
            }
            var user = await userManager.FindByNameOrEmailAsync(model.Email, model.Password);
            if (user != null)
            {
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                //GetAuthenticationManager().SignIn(identity);
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            //if (model.Email == "bhavsar.swapnil90@gmail.com" && model.Password == "swapnil")
            //{
            //    var identity = new ClaimsIdentity(new[]
            //    {
            //        new Claim(ClaimTypes.Name, "swa"),
            //        new Claim(ClaimTypes.Email, "bhavsar@gmail.com"),
            //        new Claim(ClaimTypes.Country, "bhavnagar")
            //    }, "ApplicationCookie");

            //    var ctx = Request.GetOwinContext();
            //    var authManager = ctx.Authentication;
            //    authManager.SignIn(identity);
            //    return Redirect(GetRedirectUrl(model.ReturnUrl));
            //}
            ModelState.AddModelError("", "Invalid email or password");
            return View("Login", model);
        }

        [HttpPost]
        public JsonResult IsUserNameAvailable(string Name)
        {
            var user = userManager.FindByName(Name);
            return Json(user == null);
        }
        [HttpPost]
        public JsonResult IsUserEmailAvailable(string Emailid)
        {
            var user = userManager.FindByEmail(Emailid);
            return Json(user == null);
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Startpage", "Empss");
            }
            return returnUrl;
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authmanager = ctx.Authentication;
            authmanager.SignOut("ApplicationCookie");
            return RedirectToAction("Startpage", "Empss");

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Newur model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView();
            }

            var user = new AppUser
            {
                UserName = model.Name,
                Country = model.Country,

                Email = model.Emailid,
                EmailConfirmed = true
                // IsConfirmed = true
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("Startpage", "Empss");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View(model);
            // StatusMessage.Text = result.Errors.FirstOrDefault();
        }
        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Country, user.Country));
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignIn(identity);

            // GetAuthenticationManager().SignIn(identity);
        }

    }
}