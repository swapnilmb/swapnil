using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ItemmanagerController : Controller
    {
     Connections con=new Connections();
        public ActionResult Index(int? id)
        {
            ViewBag.Register = id;
            var c = con.Items.Include("Bid");
            return View(c.ToList());
        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
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

        public ActionResult Detail(int id,int? userid)
        {
            ViewBag.userid = userid;
            var select = con.Items.Find(id);
            return View(select);
        }
        
        public ActionResult Add(int id,int price,DateTime date,int user)
        {
            Bid bid = new Bid
            {
                Amount = price,
                Createon = date,
                ItemId = id,
                RegisterId = user
            };
            con.Bids.Add(bid);
            con.SaveChanges();
            
            return View();
        }
    }
}