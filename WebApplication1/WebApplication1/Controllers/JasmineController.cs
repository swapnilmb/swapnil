using System;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
