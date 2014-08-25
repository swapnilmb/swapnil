using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MockDbContext
    {

        public void Initializer()
        {
            var department = new List<Department>
            {
                new Department{DepartmentId=1,DeptName="HR"},
                new Department{DepartmentId=2,DeptName="Testing"}
            };
        }
    }
}