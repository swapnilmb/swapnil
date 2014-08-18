using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.AccessControl;
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
                if (user.UserName == "Admin")
                {
                    await SignIn(user);
                    return RedirectToAction("Startpage", "Empss");
                }
                else
                {
                    if (user.ConfirmedEmail == true)
                    {
                        await SignIn(user);
                        return Redirect(GetRedirectUrl(model.ReturnUrl));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Confirm Email Address.");
                    }
                }

                //var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                ////GetAuthenticationManager().SignIn(identity);
                //var ctx = Request.GetOwinContext();
                //var authManager = ctx.Authentication;
                //authManager.SignIn(identity);
                //return Redirect(GetRedirectUrl(model.ReturnUrl));
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
            //ModelState.AddModelError("", "Invalid email or password");
            
            return Redirect("http://localhost:1938/Empss/Startpage#/Auth/Login?check=1");
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
      
        public ActionResult Register()
        {Newur ss=new Newur();
            return PartialView("_Register",ss);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                ConfirmedEmail = false
                // IsConfirmed = true
            };

            var result = await userManager.CreateAsync(user);

            if (result.Succeeded)
            {
              //  var code = await userManager.GenerateEmailConfirmationTokenAsync(user.Id);
                MailMessage m = new MailMessage(new MailAddress("bhavsar.swapnil90@gmail.com", "Web Registration"),
                    new MailAddress(user.Email));
                m.Subject = "Email Confirmation";
                m.Body = string.Format(" {1} <BR/> <a href={1}> </a>", user.UserName, Url.Action("ConfirmEmail", "Auth", new { token = user.Id, Email = user.Email }, Request.Url.Scheme))
                ;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("bhavsar.swapnil90@gmail.com", "swapnil199@");
                smtp.EnableSsl = true;
                smtp.Send(m);
               
               return Content("Confirm email sent");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View(model);
            // StatusMessage.Text = result.Errors.FirstOrDefault();
        }
        public ActionResult Confirm()
        {
            return Content("Email link is sent");
        } 
        public async Task<ActionResult> ConfirmEmail(string token, string Email)
        {
            AppUser user = this.userManager.FindById(token);
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.ConfirmedEmail = true;
                    await userManager.UpdateAsync(user);
                    await SignIn(user);
                    return Redirect("http://localhost:1938/Empss/Startpage#/Auth/Newpassword");         
                }
            else
            {
             return RedirectToAction("Confirm", "Auth", new { Email = user.Email });
            }
        }
        else
        {
          return RedirectToAction("Confirm", "Auth", new { Email = "" });
        }
        }
        public ActionResult Newpassword()
        {
            
            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> Newpassword (Newur model)
        {
           string x= User.Identity.GetUserId();
           string y = userManager.PasswordHasher.HashPassword( model.Password);

        AppUser user = this.userManager.FindById(x);
           
            if(user!=null)
            {
                user.PasswordHash = y;
                await userManager.UpdateAsync(user);
               // userManager.ChangePasswordAsync(x, " ", y);
                return PartialView("_Newpassword");
            }
            return View();
    }
        public ActionResult Editprofile()
        {
            var x = User.Identity.GetUserId();
            AppUser user = this.userManager.FindById(x);
            
            return PartialView(user);
        }
        [HttpPost]
        public async Task<ActionResult> Editprofile(AppUser Appuser)
        {
            if (ModelState.IsValid)
            {
               
                var c=await userManager.UpdateAsync(Appuser);
                if (c.Succeeded)
                {
                    //co.Entry(emp).State = EntityState.Modified;
                    //co.SaveChanges();
                    //var x = co.Emps.ToList(); 
                    return Content("User Updated");
                }
            }
            return View(Appuser);
        }
       
        public ActionResult Changepassword()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> Changepassword(string oldpassword,Newur model)
        {
            var x=User.Identity.GetUserName();
          
            AppUser user =await  userManager.FindAsync(x,oldpassword);

           
            if(user !=null)
            {
                await userManager.ChangePasswordAsync(user.Id, oldpassword, model.Password);
                await userManager.UpdateAsync(user);
                return PartialView("Changesuccess");
            }
            ViewBag.wrong = "your old password didn't match";
            return View();
            
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