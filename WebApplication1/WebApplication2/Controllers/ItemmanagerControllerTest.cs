using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WebApplication2.Controllers
{
    public class ItemmanagerControllerTest
    {
        // GET: ItemmanagerControllerTest
        public void Index()
        {ItemmanagerController dd=new ItemmanagerController();
           var ss= dd.Index(3);
          Assert.AreEqual(55,ss);
        }
    }
}