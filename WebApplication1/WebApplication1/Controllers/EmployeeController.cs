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
         AppDbContext appdbcontext = new AppDbContext();


    //Shows the list of Employees
        public PartialViewResult Index()
        {
            var employeeList = appdbcontext.Employees.Include(e => e.Department).ToList();
            return PartialView("_Employee", employeeList);
        }


    //Create Employee view
        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.DepartmentId = new SelectList(appdbcontext.Departments, "DepartmentId", "DeptName");
            return PartialView();
        }

    //Create Employee and return message 
        [HttpPost]
        public JsonResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                appdbcontext.Employees.Add(emp);
                appdbcontext.SaveChanges();
                return Json("Employee Created");
            }
            return Json(emp);
        }

    //Update Employee View
        [OutputCache(NoStore = true, Duration = 0)]
        [HttpGet]
        public PartialViewResult Update(int? id)
        {
            Employee emp = appdbcontext.Employees.Find(id);
            ViewBag.DepartmentId = new SelectList(appdbcontext.Departments, "DepartmentId", "DeptName", emp.DepartmentId);
            return PartialView(emp);
        }

    //Updates Employee after modification and return message
        [HttpPost]
        public JsonResult Update( Employee emp)
        {
            if (ModelState.IsValid)
            {
                appdbcontext.Entry(emp).State = EntityState.Modified;
                appdbcontext.SaveChanges();
                //var x = appdbcontext.Emps.ToList(); 
                return Json("Employee Updated");
            }
            ViewBag.DepartmentId = new SelectList(appdbcontext.Departments, "DepartmentId", "DeptName", emp.EmployeeId);
            return Json(emp);
        }

    //Delete the Employee
        public PartialViewResult Delete(int id)
        {
            var del = appdbcontext.Employees.Find(id);
            appdbcontext.Employees.Remove(del);
            appdbcontext.SaveChanges();
            var x = appdbcontext.Employees.ToList(); 
            return PartialView("_Employee",x);
        }

    //Index Page Which will run first
        [AllowAnonymous]
         public ActionResult Startpage()
        {
            return View();
        }

   
    //Shows the list of Departments
         public PartialViewResult IndexDept()
         {
             var department = appdbcontext.Departments.ToList();
             return PartialView("_Department", department);
             
         }

    //create Department View
         public PartialViewResult CreateDept()
         {
             ViewBag.dname = new SelectList(appdbcontext.Departments, "DepartmentId", "DeptName");
             return PartialView();
         }

    //Creates Departments and return message
         [HttpPost]
         public JsonResult CreateDept(Department dept)
         {
             if (ModelState.IsValid)
             {
                 appdbcontext.Departments.Add(dept);
                 appdbcontext.SaveChanges();
                 return Json(new { result = "Department Created" }, JsonRequestBehavior.AllowGet);

             }
             return Json(dept);
         }


    //Update Department View
         public PartialViewResult UpdateDept(int id)
         {
             Department dept = appdbcontext.Departments.Find(id);
             return PartialView(dept);
         }

    //Updates Department and Retun message
         [HttpPost]
         public JsonResult UpdateDept(Department dept)
         {
             if (ModelState.IsValid)
             {
                 appdbcontext.Entry(dept).State = EntityState.Modified;
                 appdbcontext.SaveChanges();
                 //var x = appdbcontext.Depts.ToList();
                 return Json(new { result = "Department Updated" }, JsonRequestBehavior.AllowGet);
             }
             return Json(dept);

         }

    //Delete Department
         public ActionResult DeleteDept(int id)
         {
             var del = appdbcontext.Departments.Find(id);
             appdbcontext.Departments.Remove(del);
             appdbcontext.SaveChanges();
             var x = appdbcontext.Departments.ToList();
             return PartialView("_Department", x);


         }
    }
}