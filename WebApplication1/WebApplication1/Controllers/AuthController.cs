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

 // Declare usermanager of type AppUser
        private readonly UserManager<AppUser> userManager;


//Invoke UsermanagerFactory
        public AuthController()
            : this(Startup.UserManagerFactory.Invoke())
        {

        }

//Create usermanager object
        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

//Shows Login ViewModel
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return PartialView("Login", model);
        }

//Check if user Exists. If yes then will Login
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
                    return RedirectToAction("Startpage", "Employee");
                }
                else
                {
                    if (user.EmailConfirmed == true)
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

            return Redirect("http://10.1.81.37:8040/Employee/Startpage#/Auth/Login?check=1");
        }

//Checks if the UserName all ready Exist or Not
        [HttpPost]
        public JsonResult IsUserNameAvailable(string Name)
        {
            var user = userManager.FindByName(Name);
            return Json(user == null);
        }

//Checks if the UserEmail all ready Exist or Not
        [HttpPost]
        public JsonResult IsUserEmailAvailable(string Emailid)
        {
            var user = userManager.FindByEmail(Emailid);
            return Json(user == null);
        }

//Method user to GetRedirectUrl
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Startpage", "Employee");
            }
            return returnUrl;
        }

//Used When User Logouts
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authmanager = ctx.Authentication;
            authmanager.SignOut("ApplicationCookie");
            return RedirectToAction("Startpage", "Employee");

        }

//Release both Managed and Unmanaged Resources
        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }

//Shows The View Of Register ViewModel
        [HttpGet]
       public ActionResult Register()
        {Newur ss=new Newur();
            return PartialView("_Register",ss);
        }

//Registers the User and Sends Email For the Confirmation 
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
                EmailConfirmed = false
                // IsConfirmed = true
            };

            var result = await userManager.CreateAsync(user);

            if (result.Succeeded)
            {
              //  var code = await userManager.GenerateEmailConfirmationTokenAsync(user.Id);
                MailMessage m = new MailMessage(new MailAddress("bhavsar.swapnil90@gmail.com", "Web Registration"),
                    new MailAddress(user.Email));
                m.Subject = "Email Confirmation";
                m.Body = string.Format(" {1} <BR/>", user.UserName, Url.Action("ConfirmEmail", "Auth", new { token = user.Id, Email = user.Email }, Request.Url.Scheme));
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

//Gives message of Email Sent
        public ActionResult Confirm()
        {
            return Content("Email link is sent");
        } 

//After Email Confirmation User is Logged In
        public async Task<ActionResult> ConfirmEmail(string token, string Email)
        {
            AppUser user = this.userManager.FindById(token);
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.EmailConfirmed = true;
                    await userManager.UpdateAsync(user);
                    await SignIn(user);
                    return Redirect("http://10.1.81.37:8040/Employee/Startpage#/Auth/Newpassword");         
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

//Shows the View for NewPassword
        public ActionResult Newpassword()
        {
            
            return PartialView();
        }

//This method Used For setting NewPassword 
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
                return PartialView("_Newpassword");
            }
            return View();
    }

//Shows ViewModel for EditProfile with User Data
        public ActionResult Editprofile()
        {
            var x = User.Identity.GetUserId();
            AppUser user = this.userManager.FindById(x);
            
            return PartialView(user);
        }

//Updates Profile of User after Editing
        [HttpPost]
        public async Task<ActionResult> Editprofile(Editprofile editprofile)
        {
            var x = User.Identity.GetUserId();
            AppUser user = this.userManager.FindById(x);
            user.UserName = editprofile.UserName;
            user.Email = editprofile.Email;
            user.Country = editprofile.Country;
            var c = await userManager.UpdateAsync(user);

                if (c.Succeeded)
               {
                   
                    return PartialView("_Editprofile");
               }

                //var error = ModelState.AddModelError("", c);
            return View(editprofile);
        }

//Shows View For Change Password       
        public ActionResult Changepassword()
        {
            return PartialView();
        }

//Method Used for Changing Password 
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

//Method Used for Creating Identity of User,Adding Claims and Authentication
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