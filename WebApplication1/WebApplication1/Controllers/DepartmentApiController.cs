using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class DepartmentApiController : ApiController
    {
        IEmployeeRepository repository = new EmployeeRepository();
        
        [HttpGet]
        public IEnumerable<Department> AllDepartment()
        {
            return repository.GetallDepartment();
        }
        [HttpPost]
        public IHttpActionResult CreateDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                repository.CreateDepartment(dept);
                
                Message msg = new Message();
                msg.message = "Department Created";

                return Ok(msg);

            }
            return Ok(dept);
        }

         public Department GetDepartmentbyid(int Id)
        {
             var dept = repository.GetDepartmentbyId(Id); 
             return dept;

        }

        [HttpPost]
      
        public IHttpActionResult UpdateDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                repository.DepartmentUpdate(dept);
                Message msg = new Message();
                msg.message = "Department Updated";

                return Ok(msg);
            }
          
            return Ok(dept);

        }
        [HttpGet]
        public IHttpActionResult DeleteDepartment(int id)
        {
            repository.DepartmentDelete(id);
            Message msg = new Message();
            msg.message = "Department Deleted";
            return Ok(msg);
        }

        [HttpGet]
        public IEnumerable<Employee> AllEmployee()
        {
            return repository.GetallEmployee();
        }
    }
}