using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using WebApplication1.Models;
namespace UnitTestProject3.Models
{
    class MocDeptRepository: IDeptRepository

    {
        private List<Dept> con=new List<Dept>();
        public Exception ExceptionToThrow { get; set; }

        public void SaveChanges(Dept deptToUpdate)
        {
            foreach (Dept dept in con)
            {
                if (dept.DeptId == deptToUpdate.DeptId)
                {
                    con.Remove(dept);
                    con.Add(deptToUpdate);
                    break;
                }
            }
        }
        public void Add(Dept dept)
    {
        con.Add(dept);
    }
        public Dept GetDeptbyDeptid(int id)
        {
            return con.FirstOrDefault(d => d.DeptId == id);
        }
        public void CreateNewDept(Dept deptToCreate)
        {
            
            con.Add(deptToCreate);
            // return contactToCreate;
        }
        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<Dept> GetAllDepts()
        {
            return con.ToList();
        }


        public void DeleteDept(int id)
        {
            con.Remove(GetDeptbyDeptid(id));
        }

    }
}
