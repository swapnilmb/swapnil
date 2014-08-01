using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
         public ActionResult Startpage()
         {
             return View();
         }
    }
}