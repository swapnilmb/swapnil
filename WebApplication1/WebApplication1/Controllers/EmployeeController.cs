using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{[HandleError]
    public class EmployeeController : Controller
    {

    //Database Connection
         //AppDbContext appdbcontext = new AppDbContext();
    private IEmployeeRepository repository;
    //public EmployeeController()
    //    : this(new EmployeeRepository())
    //{

    //}
    public EmployeeController(IEmployeeRepository repo)
    {
        repository = repo;
    }
    //Shows the list of Employees
        public PartialViewResult Index()

        {
            return PartialView("_Employee",  repository.GetallEmployee());
        }



    //Create Employee view
        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.DepartmentId = new SelectList(repository.CreateDepartmentDropDown(), "DepartmentId", "DeptName");
            return PartialView();
        }

    //Create Employee and return message 
        [HttpPost]
        public JsonResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                repository.CreateEmployee(emp);
                return Json("Employee Created");
            }
            return Json(emp);
        }

    //Update Employee View
        [OutputCache(NoStore = true, Duration = 0)]
        [HttpGet]
        public PartialViewResult Update(int id)
        {
            var empy = repository.GetEmployeebyId(id);
            ViewBag.DepartmentId = new SelectList(repository.CreateDepartmentDropDown(), "DepartmentId", "DeptName", empy.DepartmentId);
            return PartialView(empy);
        }

    //Updates Employee after modification and return message
        [HttpPost]
        public JsonResult Update( Employee emp)
        {
            if (ModelState.IsValid)
            {
                repository.EmployeeUpdate(emp);
                return Json("Employee Updated");
            }
            ViewBag.DepartmentId = new SelectList(repository.CreateDepartmentDropDown(), "DepartmentId", "DeptName", emp.EmployeeId);
            return Json(emp);
        }

    //Delete the Employee
        public PartialViewResult Delete(int id)
        {
            repository.EmployeeDelete(id);
            //var x = appdbcontext.Employees.ToList(); 
            var employee = repository.GetallEmployee();
            return PartialView("_Employee",employee);
        }

    //Index Page Which will run first
        [AllowAnonymous]
         public ActionResult Startpage()
        {
            return View();
        }

   
    //Shows the list of Departments
         public JsonResult IndexDept()
         {
            
             return Json(repository.GetallDepartment(),JsonRequestBehavior.AllowGet);
             //return PartialView("_Department", repository.GetallDepartment());
             
         }

    //create Department View
         public PartialViewResult CreateDept()
         {
             //ViewBag.dname = new SelectList(appdbcontext.Departments, "DepartmentId", "DeptName");
             return PartialView();
         }

    //Creates Departments and return message
         [HttpPost]
         public JsonResult CreateDept(Department dept)
         {
             if (ModelState.IsValid)
             {
                 repository.CreateDepartment(dept);
                 return Json("Department Created",  JsonRequestBehavior.AllowGet);

             }
             return Json(dept);
         }


    //Update Department View
         public PartialViewResult UpdateDept(int id)
         {
             var dept = repository.GetDepartmentbyId(id);
             return PartialView(dept);
         }

    //Updates Department and Retun message
         [HttpPost]
         public JsonResult UpdateDept(Department dept)
         {
             if (ModelState.IsValid)
             {
                 repository.DepartmentUpdate(dept);
                 //var x = appdbcontext.Depts.ToList();
                 //return Json(new { result = "Department Updated" }, JsonRequestBehavior.AllowGet);
                 return Json("Department Updated", JsonRequestBehavior.AllowGet);
             }
             return Json(dept);

         }

    //Delete Department
         public PartialViewResult DeleteDept(int id)
         {
             repository.DepartmentDelete(id);
             var department = repository.GetallDepartment();
             return PartialView("_Department",department);
         }
    }
}