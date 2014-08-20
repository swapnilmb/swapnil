using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EF_DeptRepository: IDeptRepository
    {
         AppDbContext con = new AppDbContext();

        //public EF_DeptRepository()
        //{
        //    con=new Connection();
        //}

         public IEnumerable<Department> GetAllDepts()
        {
            return con.Departments.ToList();
        }

         public void CreateNewDept(Department deptToCreate)
        {
            con.Departments.Add(deptToCreate);
             con.SaveChanges();
             //_db.(contactToCreate);
             //_db.SaveChanges();
             //   return contactToCreate;
        }

        public Department GetDeptbyDeptid(int id)
        {
            return con.Departments.SingleOrDefault(s => s.DepartmentId == id);
        }
        public int SaveChanges()
        {
           return con.SaveChanges();
        }

        public void DeleteDept(int id)
        {
            var dept = GetDeptbyDeptid(id);
            con.Departments.Remove(dept);
            con.SaveChanges();
       
            
            
        }
       
    }
}