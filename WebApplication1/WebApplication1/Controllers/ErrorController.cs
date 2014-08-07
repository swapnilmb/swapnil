using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
      // [HandleError]
        [AllowAnonymous]
        public ViewResult Unauthorised()
        {
            Response.StatusCode = 401;
            //throw new HttpException(401, "Unauthorized");
            //Response.StatusCode = 401; // Do not set this or else you get a redirect loop
            return View("Unauthorised");
        }
        [AllowAnonymous]
        public ViewResult ee()
        {
            return View();
        }
        
    }
}