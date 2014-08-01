using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using WebApplication1.Controllers;

using WebApplication1.Models;
using UnitTestProject3.Models;
using System.Web;

using System.Security.Principal;
namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
         Dept GetContact()
        {
            return GetContact(1, "php");
        }
        Dept GetContact(int id, string fName)
        {
            return new Dept
            {
                DeptId=id,
                DeptName=fName
            
            };
        }

       
        private static HomeController GetHomeController(IDeptRepository repository)
        {
            HomeController controller = new HomeController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }
        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
