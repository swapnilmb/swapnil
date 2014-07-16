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
        public ActionResult Index()
        {
            var dd = co.Emps.Include(e => e.Dept);
            return View(dd.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(co.Depts, "DeptId", "DeptName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                co.Emps.Add(emp);
                co.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public ActionResult Update(int? id)
        {
            Emp emp = co.Emps.Find(id);
            ViewBag.DeptId = new SelectList(co.Depts, "DeptId", "DeptName", emp.DeptId);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Update( Emp emp)
        {
            if (ModelState.IsValid)
            {
                co.Entry(emp).State = EntityState.Modified;
                co.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.edept = new SelectList(co.Depts, "DeptId", "DeptName", emp.EmpId);
            return View(emp);
        }
        public ActionResult Delete(int id)
        {
            var del = co.Emps.Find(id);
            co.Emps.Remove(del);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}