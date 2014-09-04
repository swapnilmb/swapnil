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
        // GET api/<controller>
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

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}