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
    public class EmpssController : Controller
    {

    //Database Connection
         AppDbContext appdbcontext = new AppDbContext();


    //Shows the list of Employees
        public PartialViewResult Index()
        {
            var employeeList = appdbcontext.Emps.Include(e => e.Dept).ToList();
            return PartialView("View1", employeeList);
        }


    //Create Employee view
        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.DeptId = new SelectList(appdbcontext.Depts, "DeptId", "DeptName");
            return PartialView();
        }

    //Create Employee and return message 
        [HttpPost]
        public JsonResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                appdbcontext.Emps.Add(emp);
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
            Emp emp = appdbcontext.Emps.Find(id);
            ViewBag.DeptId = new SelectList(appdbcontext.Depts, "DeptId", "DeptName", emp.DeptId);
            return PartialView(emp);
        }

    //Updates Employee after modification and return message
        [HttpPost]
        public JsonResult Update( Emp emp)
        {
            if (ModelState.IsValid)
            {
                appdbcontext.Entry(emp).State = EntityState.Modified;
                appdbcontext.SaveChanges();
                //var x = appdbcontext.Emps.ToList(); 
                return Json("Employee Updated");
            }
            ViewBag.edept = new SelectList(appdbcontext.Depts, "DeptId", "DeptName", emp.EmpId);
            return Json(emp);
        }

    //Delete the Employee
        public PartialViewResult Delete(int id)
        {
            var del = appdbcontext.Emps.Find(id);
            appdbcontext.Emps.Remove(del);
            appdbcontext.SaveChanges();
            var x = appdbcontext.Emps.ToList(); 
            return PartialView("View1",x);
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
             var department = appdbcontext.Depts.ToList();
             return PartialView("View", department);
             
         }

    //create Department View
         public PartialViewResult CreateDept()
         {
             ViewBag.dname = new SelectList(appdbcontext.Depts, "DeptId", "DeptName");
             return PartialView();
         }

    //Creates Departments and return message
         [HttpPost]
         public JsonResult CreateDept(Dept dept)
         {
             if (ModelState.IsValid)
             {
                 appdbcontext.Depts.Add(dept);
                 appdbcontext.SaveChanges();
                 return Json(new { result = "Department Created" }, JsonRequestBehavior.AllowGet);

             }
             return Json(dept);
         }


    //Update Department View
         public PartialViewResult UpdateDept(int id)
         {
             Dept dd = appdbcontext.Depts.Find(id);
             return PartialView(dd);
         }

    //Updates Department and Retun message
         [HttpPost]
         public JsonResult UpdateDept(Dept dept)
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
             var del = appdbcontext.Depts.Find(id);
             appdbcontext.Depts.Remove(del);
             appdbcontext.SaveChanges();
             var x = appdbcontext.Depts.ToList();
             return PartialView("View", x);


         }
    }
}