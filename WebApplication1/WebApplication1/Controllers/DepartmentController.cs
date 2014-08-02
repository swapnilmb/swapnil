using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [HandleError]
    public class DepartmentController : Controller
    {
        private IDeptRepository _repository;

        public DepartmentController()
            : this(new EF_DeptRepository())
        {

        }

        public DepartmentController(IDeptRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Index()
        {
            // List<Dept> depts =EF_DeptRepository.Get
            return View("Index", _repository.GetAllDepts());
            //return View(depts);
        }
    }
}