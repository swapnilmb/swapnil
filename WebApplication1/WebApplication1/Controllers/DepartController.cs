using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartController : Controller
    {
        //private UnitofWork unitofWork = null;

        //public DepartController():this(new UnitofWork())
        //{
            
        //}

        //public DepartController(UnitofWork unow)
        //{
        //    this.unitofWork = unow;
        //}
        Connection co = new Connection();
        public PartialViewResult Index()
        {
            var ff = co.Depts.ToList();
            return PartialView("View", ff);
            //IEnumerable<Dept> depts = unitofWork.DeptRepository.GetAllContacts();
            //return PartialView(depts);
        }

        public PartialViewResult Create()
        {
            ViewBag.dname = new SelectList(co.Depts, "DeptId", "DeptName");
            return PartialView();
        }
        [HttpPost]
        public JsonResult Create(Dept dept)
        {
            if (ModelState.IsValid)
            {
                co.Depts.Add(dept);
                co.SaveChanges();
                //var x = co.Depts.ToList();
                return Json(new { result = "Department Created" },JsonRequestBehavior.AllowGet);
             
            }
            return Json(dept);
        }

        public PartialViewResult Update(int id)
        {
            Dept dd = co.Depts.Find(id);
         return PartialView(dd);

        }
        [HttpPost]
        public JsonResult Update(Dept dept)
        {
            if (ModelState.IsValid)
            {
                co.Entry(dept).State = EntityState.Modified;
                co.SaveChanges();
                //var x = co.Depts.ToList();
                return Json(new{result="Department Updated"},JsonRequestBehavior.AllowGet);
             
               
            }
            return Json(dept);

        }


        public ActionResult Delete(int id)
        {
            var del = co.Depts.Find(id);
            co.Depts.Remove(del);
            co.SaveChanges();
            var x = co.Depts.ToList();
            return PartialView("View", x);
             
            
        }

    }
}