using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartController : Controller
    {
       Connection co=new Connection();
        public ActionResult Index()
        {
            var ff = co.Depts.ToList();
            return View(ff);
        }

        public ActionResult Create()
        {
            ViewBag.dname = new SelectList(co.Depts, "DeptId", "DeptName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Dept dept)
        {
            if (ModelState.IsValid)
            {
                co.Depts.Add(dept);
                co.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        public ActionResult Update(int id)
        {
            Dept dd = co.Depts.Find(id);
            return View(dd);

        }
        [HttpPost]
        public ActionResult Update(Dept dept)
        {
            if (ModelState.IsValid)
            {
                co.Entry(dept).State = EntityState.Modified;
                co.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dept);

        }

      
        public ActionResult Delete(int id)
        {
            var del = co.Depts.Find(id);
            co.Depts.Remove(del);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}