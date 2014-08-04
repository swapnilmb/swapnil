using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmpssController : Controller
    {
      Connection co=new Connection();

      public PartialViewResult Index()
        {
            var dd = co.Emps.Include(e => e.Dept).ToList();


            return PartialView("View1",dd);
        }
        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.DeptId = new SelectList(co.Depts, "DeptId", "DeptName");
            return PartialView();
        }
        [HttpPost]
        public JsonResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                co.Emps.Add(emp);
                co.SaveChanges();
                //var x = co.Emps.ToList();
                return Json("Employee Created");
            }
            return Json(emp);
        }
        [OutputCache(NoStore = true, Duration = 0)]
        [HttpGet]
        public PartialViewResult Update(int? id)
        {
            Emp emp = co.Emps.Find(id);
            ViewBag.DeptId = new SelectList(co.Depts, "DeptId", "DeptName", emp.DeptId);
            return PartialView(emp);
        }
        [HttpPost]
        public JsonResult Update( Emp emp)
        {
            if (ModelState.IsValid)
            {
                co.Entry(emp).State = EntityState.Modified;
                co.SaveChanges();
                //var x = co.Emps.ToList(); 
                return Json("Employee Updated");
            }
            ViewBag.edept = new SelectList(co.Depts, "DeptId", "DeptName", emp.EmpId);
            return Json(emp);
        }
        public PartialViewResult Delete(int id)
        {
            var del = co.Emps.Find(id);
            co.Emps.Remove(del);
            co.SaveChanges();
            var x = co.Emps.ToList(); 
            return PartialView("View1",x);
        }
        [AllowAnonymous]
         public ActionResult Startpage()
         {
            // var claimsIdentity = User.Identity as ClaimsIdentity;
            // ViewBag.Country = CurrentUser.Country;
                 //claimsIdentity.FindFirst(ClaimTypes.Country).Value;
             return View();
         }

         public PartialViewResult IndexDept()
         {
             var ff = co.Depts.ToList();
             return PartialView("View", ff);
             //IEnumerable<Dept> depts = unitofWork.DeptRepository.GetAllContacts();
             //return PartialView(depts);
         }

         public PartialViewResult CreateDept()
         {
             ViewBag.dname = new SelectList(co.Depts, "DeptId", "DeptName");
             return PartialView();
         }
         [HttpPost]
         public JsonResult CreateDept(Dept dept)
         {
             if (ModelState.IsValid)
             {
                 co.Depts.Add(dept);
                 co.SaveChanges();
                 //var x = co.Depts.ToList();
                 return Json(new { result = "Department Created" }, JsonRequestBehavior.AllowGet);

             }
             return Json(dept);
         }

         public PartialViewResult UpdateDept(int id)
         {
             Dept dd = co.Depts.Find(id);
             return PartialView(dd);

         }
         [HttpPost]
         public JsonResult UpdateDept(Dept dept)
         {
             if (ModelState.IsValid)
             {
                 co.Entry(dept).State = EntityState.Modified;
                 co.SaveChanges();
                 //var x = co.Depts.ToList();
                 return Json(new { result = "Department Updated" }, JsonRequestBehavior.AllowGet);


             }
             return Json(dept);

         }


         public ActionResult DeleteDept(int id)
         {
             var del = co.Depts.Find(id);
             co.Depts.Remove(del);
             co.SaveChanges();
             var x = co.Depts.ToList();
             return PartialView("View", x);


         }
    }
}