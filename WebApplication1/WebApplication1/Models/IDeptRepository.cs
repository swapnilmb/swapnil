using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface IDeptRepository
    {
        Dept GetDeptbyDeptid(int id);
        void CreateNewDept(Dept deptToCreate);
        void DeleteDept(int id);
       
        IEnumerable<Dept> GetAllDepts();
        int SaveChanges();

    }
}