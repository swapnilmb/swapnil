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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Helpers;
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
        public void GetpartialviewnameofEmployeeTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            PartialViewResult viewresult = controller.Index();
            Assert.IsNotNull(viewresult);
            Assert.AreEqual("_Employee", viewresult.ViewName);
            
        }
        [Test]
        public void GetAllEmployeeTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            PartialViewResult viewresult = controller.Index();
            IList<Employee> list=viewresult.Model as IList<Employee>;
            Assert.AreEqual(list.Count,1);
        }
        [Test]
        public void DropdownListofDepartmentTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            PartialViewResult viewresult = controller.Create();
            ViewDataDictionary viewdata = viewresult.ViewData;
            var result=viewdata.Values;
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("", viewresult.ViewName);
        }
        [Test]
        public void CreateEmployeeTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Employee employee = new Employee
            {
                EmployeeId = 2,
                DepartmentId=1,
                Empname = "sheetal",
                Empemail = "sheetal@gmail.com"
            };
            JsonResult viewresult = controller.Create(employee);
            Assert.NotNull(viewresult);
            Assert.AreEqual("Employee Created", viewresult.Data);
            
        }
        [Test]
        public void GetEmployeeToBeUpdatedTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Employee employee = new MocEmployeeRepository().GetEmployeebyId(1);
            PartialViewResult viewresult = controller.Update(1);
            Employee employee1 =viewresult.Model as Employee;
            Assert.NotNull(viewresult);
            Assert.AreEqual(employee, employee1);
        }

        [Test]
        public void EmployeeUpdatedTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Employee employee = new Employee
            {
                EmployeeId = 1,
                DepartmentId = 1,
                Empname = "sheetal",
                Empemail = "sheetal@gmail.com"
            };
            JsonResult viewresult = controller.Update(employee);
            Assert.AreEqual("Employee Updated", viewresult.Data);
        }
        [Test]
        public void DeleteEmployeeTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Employee employee = new MocEmployeeRepository().GetEmployeebyId(1);
            PartialViewResult viewresult = controller.Delete(1);
            Employee employee1 = viewresult.Model as Employee;
            Assert.AreNotEqual(employee, employee1);
        }
        [Test]
        public void GetpartialviewnameofDepartmentTest()
        {

            var controller = GetEmployeeController(new MocEmployeeRepository());

            PartialViewResult viewresult = controller.IndexDept();
            Assert.IsNotNull(viewresult);
            Assert.AreEqual("_Department", viewresult.ViewName);

        }
        [Test]
        public void GetAllDepartmentTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            PartialViewResult viewresult = controller.IndexDept();
            IList<Department> list = viewresult.Model as IList<Department>;
            Assert.AreEqual(list.Count, 1);
        }
    
        [Test]
        public void CreateDepartmentTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Department department = new Department
            {
               DepartmentId = 2,
                DeptName="Testing"
            };
                JsonResult viewresult = controller.CreateDept(department);
                Assert.NotNull(viewresult);
                Assert.AreEqual("Department Created",viewresult.Data);
        }
        [Test]
        public void GetDepartmentToBeUpdatedTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Department department = new MocEmployeeRepository().GetDepartmentbyId(1);

            PartialViewResult viewresult = controller.UpdateDept(1);
            Department department1 = viewresult.Model as Department;
            Assert.NotNull(viewresult);
            Assert.AreEqual(department, department1);

        }

        [Test]
        public void DepartmentUpdatedTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Department department = new Department
            {
                DepartmentId = 1,
                DeptName="Windows 8"
            };
            JsonResult viewresult = controller.UpdateDept(department);
            Assert.AreEqual("Department Updated", viewresult.Data);
        }
        [Test]
        public void DeleteDepartmentTest()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Department department = new MocEmployeeRepository().GetDepartmentbyId(1);
            PartialViewResult viewresult = controller.DeleteDept(1);
            Department department1 = viewresult.Model as Department;
            Assert.AreNotEqual(department, department1);
        }

 
    
    }
}
