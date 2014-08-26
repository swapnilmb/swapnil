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
        public void Get_partialview_name_of_Employee()
        {
            
            var controller = GetEmployeeController(new MocEmployeeRepository());
            PartialViewResult viewresult = controller.Index();
            Assert.IsNotNull(viewresult);
            Assert.AreEqual("_Employee", viewresult.ViewName);
            
        }
        [Test]
        public void Get_All_Employee()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            //VewResult viewresult = controller.;
           PartialViewResult viewresult = controller.Index();
           // ViewResult result = viewresult as ViewResult;
            IList<Employee> list=viewresult.Model as IList<Employee>;
            //var count = _employeerepository.GetallDepartment();
            Assert.AreEqual(list.Count,1);
        }
        [Test]
        public void Dropdown_List_of_Department()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            PartialViewResult viewresult = controller.Create();
            ViewDataDictionary viewdata = viewresult.ViewData;
            var c=viewdata.Values;
            //Department d from c;
            
            //Department list = c as Department;
            Assert.AreEqual(1, c.Count);
            Assert.AreEqual("", viewresult.ViewName);
        }
        [Test]
        public void Create_Employee()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            Employee emp = new Employee
            {
                EmployeeId = 2,
                DepartmentId=1,
                Empname = "sheetal",
                Empemail = "sheetal@gmail.com"
            };
          
            //JsonResult viewresult=controller.Create(emp);
            JsonResult viewresult = controller.Create(emp);
            Assert.AreEqual("Employee Created", viewresult.Data);
            Assert.NotNull(viewresult);
        }
        [Test]
        public void Get_Employee_To_Be_Updated()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Employee emp = new MocEmployeeRepository().GetEmployeebyId(1);
            PartialViewResult viewresult = controller.Update(1);
            //ViewDataDictionary viewdata = viewresult.ViewData;
            Employee emp1 =viewresult.Model as Employee;
            Assert.NotNull(viewresult);
            Assert.AreEqual(emp, emp1);
           

        }

        [Test]
        public void Employee_Updated()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            Employee emp = new Employee
            {
                EmployeeId = 1,
                DepartmentId = 1,
                Empname = "sheetal",
                Empemail = "sheetal@gmail.com"
            };
            JsonResult viewresult = controller.Update(emp);
            //Employee emp1 = viewresult.Model as Employee;
            Assert.AreEqual("Employee Updated", viewresult.Data);
        }
        [Test]
        public void Delete_Employee()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            Employee emp = new MocEmployeeRepository().GetEmployeebyId(1);
            PartialViewResult viewresult = controller.Delete(1);
            Employee emp1 = viewresult.Model as Employee;
            Assert.AreNotEqual(emp, emp1);
        }
        [Test]
        public void Get_partialview_name_of_Department()
        {

            var controller = GetEmployeeController(new MocEmployeeRepository());
            PartialViewResult viewresult = controller.IndexDept();
            Assert.IsNotNull(viewresult);
            Assert.AreEqual("_Department", viewresult.ViewName);

        }
        [Test]
        public void Get_All_Department()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            PartialViewResult viewresult = controller.IndexDept();
            IList<Department> list = viewresult.Model as IList<Department>;
            Assert.AreEqual(list.Count, 1);
        }
    
        [Test]
        public void Create_Department()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            Department dept = new Department
            {
               
                DepartmentId = 2,
                DeptName="Testing"
            };
                JsonResult viewresult = controller.CreateDept(dept);
                Assert.AreEqual("Department Created",viewresult.Data);
                Assert.NotNull(viewresult);
            
        }
        [Test]
        public void Get_Department_To_Be_Updated()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());

            Department dept = new MocEmployeeRepository().GetDepartmentbyId(1);
            PartialViewResult viewresult = controller.UpdateDept(1);
            //ViewDataDictionary viewdata = viewresult.ViewData;
            Department dept1 = viewresult.Model as Department;
            Assert.NotNull(viewresult);
            Assert.AreEqual(dept, dept1);


        }

        [Test]
        public void Department_Updated()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            Department dept = new Department
            {

                DepartmentId = 1,
                DeptName="Windows 8"
            };
            JsonResult viewresult = controller.UpdateDept(dept);
         
            Assert.AreEqual("Department Updated", viewresult.Data);
        }
        [Test]
        public void Delete_Department()
        {
            var controller = GetEmployeeController(new MocEmployeeRepository());
            Department dept = new MocEmployeeRepository().GetDepartmentbyId(1);
            PartialViewResult viewresult = controller.DeleteDept(1);
            Department dept1 = viewresult.Model as Department;
            Assert.AreNotEqual(dept, dept1);
        }

 
    
    }
}
