using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ItemmanagerController : Controller
    {
     Connections con=new Connections();
        [Authorize]
        public ActionResult Index(int id)
        {
            ViewBag.Register = id;
            var c = con.Items.ToList(); 
            return View(c);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                
                con.Items.Add(item);
                con.SaveChanges();
                return RedirectToAction("Index",new{id=0});
            }
            return View(item);
        }
        [Authorize]
        [OutputCache(NoStore = true, Duration = 0)]
        [HttpGet]
        public PartialViewResult Detail(int id,int? userid,string name,int pri,DateTime start)
        {
            ViewBag.userid = userid;
            ViewBag.id = id;
            ViewBag.name = name;
            ViewBag.pri = pri;
            ViewBag.start = start;
            return PartialView("Detail");
            // return View();
        }
        [HttpPost]
        [Authorize]
        //, int ItemId, DateTime createon, int registerid
        public ActionResult Detail(Bid bid)
        {
            if (ModelState.IsValid)
            {
                con.Bids.Add(bid);
                con.SaveChanges();
                ViewBag.id = bid.RegisterId;
                return View("Thankyou");
            }
            //Bid bids = new Bid
            //{
            //    Amount = bid.Amount,
            //    Createon = createon,
            //    ItemId = bid.ItemId,
            //    RegisterId = registerid
            //};
            //con.Bids.Add(bid);
            //con.SaveChanges();
            
            return View(bid);
        }

    }
}