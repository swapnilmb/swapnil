using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{[HandleError]
    public class HomeController : Controller
{
    private IDeptRepository _repository;

    //public HomeController() : this(new EF_DeptRepository())
    //{
        
    //}

    public HomeController(IDeptRepository repository)
    {
        _repository = repository;
    }
        public ViewResult Index()
        {
            throw new NotImplementedException();
            //return View();
        }
    }
}