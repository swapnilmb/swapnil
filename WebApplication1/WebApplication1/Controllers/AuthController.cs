using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;
namespace WebApplication1.Controllers
{[AllowAnonymous]
    public class AuthController : Controller
    {
        
   [HttpGet]
   public ActionResult LogIn(string returnUrl)
{
    var model = new LogInModel
    {
        ReturnUrl = returnUrl
    };

    return View(model);
}
    [HttpPost]
    public ActionResult LogIn(LogInModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (model.Email == "bhavsar.swapnil90@gmail.com" && model.Password == "swapnil")
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "swa"),
                new Claim(ClaimTypes.Email, "bhavsar@gmail.com"),
                new Claim(ClaimTypes.Country, "bhavnagar")
            }, "ApplicationCookie");

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignIn(identity);
            return Redirect(GetRedirectUrl(model.ReturnUrl));
        }
        ModelState.AddModelError("", "Invalid email or password");
        return View();
    }

    private string GetRedirectUrl(string returnUrl)
    {
        if(string.IsNullOrEmpty(returnUrl)||!Url.IsLocalUrl(returnUrl))
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

    }
}