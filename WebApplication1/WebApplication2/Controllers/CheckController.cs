using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;
using System.Data;
using WebApplication2.ViewModel;
using System.Web.Security;
namespace WebApplication2.Controllers
{
    public class CheckController : Controller
    {Connections con =new Connections();
      
    [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(Userlogon userlogon)
        {
            var c = userlogon.Emailid;
            var p = userlogon.Password;
            var auth =con.Registers.FirstOrDefault(e => e.Emailid == c && e.Password == p);
           
            if(auth!=null)
            {
                FormsAuthentication.SetAuthCookie(auth.Name,true);
                var vi = auth.RegisterId;
                //ViewBag.runId = vi;
                return RedirectToAction("Index","Itemmanager",new{id=vi});
            }
            ViewBag.message= "Email or Password doesno't match";
            return View();
        }

        public ActionResult Newuser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Newuser(Newuser newuser){
            if (ModelState.IsValid)
            {
                Register rs = new Register

                {
                   
                    Name = newuser.Username,
                    Password = newuser.Password,
                    Emailid=newuser.Emailid
                };
                
               con.Registers.Add(rs);
                var t = rs;
                con.SaveChanges();
                var vi = t.RegisterId;
                FormsAuthentication.SetAuthCookie(t.Name, true);
                //con.SaveChanges();
                return RedirectToAction("Index", "Itemmanager", new { id = vi });
            }

               
                
               // con.Registerusers.InsertOnSubmit(rs);
               // con.SaveChanges();
             
            return View();
        }
        public ActionResult Startup()
        {
            return View();
        }

        public JsonResult Hello()
        {
            return Json("Hello");
        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Check");

        }
    }
}