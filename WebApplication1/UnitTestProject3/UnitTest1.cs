using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;

using WebApplication1.Controllers;
using System.Web;
using WebApplication1.Models;
using UnitTestProject3.Models;
using System.Web.Mvc;

using System.Security.Principal;
namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
         Department GetDept()
        {
            return GetDept(1, "php");
        }
        Department GetDept(int id, string fName)
        {
            return new Department
            {
                DepartmentId=id,
                DeptName=fName
            
            };
        }

       
        private static HoController GetHomeController(IDeptRepository repository)
        {
            HoController controller = new HoController(repository);

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
        public void Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetHomeController(new MocDeptRepository());
            // Act
            ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void Index_Get_RetrievesAllDeptFromRepository()
        {
            // Arrange
            Department dept1 = GetDept(1, "Orlando");
            Department dept2 = GetDept(2, "Keith");
            MocDeptRepository repository = new MocDeptRepository();
            repository.Add(dept1);
            repository.Add(dept2);
            var controller = GetHomeController(repository);

            // Act
            var result = controller.Index();

            // Assert
            var model = (IEnumerable<Department>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), dept1);
            CollectionAssert.Contains(model.ToList(), dept2);
        }

        //[TestMethod]
        //public void Create_Post_ReturnsViewIfModelStateIsNotValid()
        //{
        //    // Arrange
        //    HomeController controller = GetHomeController(new MocDeptRepository());
        //    // Simply executing a method during a unit test does just that - executes a method, and no more. 
        //    // The MVC pipeline doesn't run, so binding and validation don't run.
        //    controller.ModelState.AddModelError("", "mock error message");
        //    Dept model = GetDept(1, "");

        //    // Act
        //    var result = (ViewResult)controller.Create(model);

        //    // Assert
        //    Assert.AreEqual("Create", result.ViewName);
        //} 

    }
}
