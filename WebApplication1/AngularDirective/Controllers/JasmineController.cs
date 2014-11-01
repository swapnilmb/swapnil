using System;
using System.Web.Mvc;

namespace AngularDirective.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
