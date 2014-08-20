using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface IDeptRepository
    {
        Department GetDeptbyDeptid(int id);
        void CreateNewDept(Department deptToCreate);
        void DeleteDept(int id);
       
        IEnumerable<Department> GetAllDepts();
        int SaveChanges();

    }
}