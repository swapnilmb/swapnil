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
        private List<Department> con=new List<Department>();
        public Exception ExceptionToThrow { get; set; }

        public void SaveChanges(Department deptToUpdate)
        {
            foreach (Department dept in con)
            {
                if (dept.DepartmentId == deptToUpdate.DepartmentId)
                {
                    con.Remove(dept);
                    con.Add(deptToUpdate);
                    break;
                }
            }
        }
        public void Add(Department dept)
    {
        con.Add(dept);
    }
        public Department GetDeptbyDeptid(int id)
        {
            return con.FirstOrDefault(d => d.DepartmentId == id);
        }
        public void CreateNewDept(Department deptToCreate)
        {
            
            con.Add(deptToCreate);
            // return contactToCreate;
        }
        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<Department> GetAllDepts()
        {
            return con.ToList();
        }


        public void DeleteDept(int id)
        {
            con.Remove(GetDeptbyDeptid(id));
        }

    }
}
