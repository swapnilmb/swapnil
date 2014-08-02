using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EF_DeptRepository: IDeptRepository
    {
         Connection con = new Connection();

        //public EF_DeptRepository()
        //{
        //    con=new Connection();
        //}

         public IEnumerable<Dept> GetAllDepts()
        {
            return con.Depts.ToList();
        }

         public void CreateNewDept(Dept deptToCreate)
        {
            con.Depts.Add(deptToCreate);
             con.SaveChanges();
             //_db.(contactToCreate);
             //_db.SaveChanges();
             //   return contactToCreate;
        }

        public Dept GetDeptbyDeptid(int id)
        {
            return con.Depts.SingleOrDefault(s => s.DeptId == id);
        }
        public int SaveChanges()
        {
           return con.SaveChanges();
        }

        public void DeleteDept(int id)
        {
            var dept = GetDeptbyDeptid(id);
            con.Depts.Remove(dept);
            con.SaveChanges();
       
            
            
        }
       
    }
}