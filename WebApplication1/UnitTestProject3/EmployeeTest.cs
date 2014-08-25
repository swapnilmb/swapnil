using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTestProject3.Models;
using WebApplication1.Models;
using WebApplication1.Controllers;
using System.Web.Mvc;
using System.Web;
namespace UnitTestProject3
{
    [TestFixture]
    class EmployeeTest
    {
        private IEmployeeRepository _employeerepository;
        [SetUp]
        public void InitializeTest()
        {
            TestDatabase.InitializeDatabase();
        }
        
        public static EmployeeController GetEmployeeController(IEmployeeRepository repository)
        {
            EmployeeController controller= new EmployeeController(repository);
            return controller;
        }

        [Test]
        public void Get_partialview_name_of_Employee()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            
            PartialViewResult viewresult = controller.Index();
            Assert.AreEqual("_Employee", viewresult.ViewName);
            
        }

        public void Get_All_Department()
        {
            //var controller = GetEmployeeController(new MocEmployeeRepository());
            //VewResult viewresult = controller.;
            int count = _employeerepository.GetallDepartment().Count();
            Assert.AreEqual(1, count);
        }
    }
}
