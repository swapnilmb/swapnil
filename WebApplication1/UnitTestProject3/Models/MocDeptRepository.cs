using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace UnitTestProject3.Models
{
    class MocDeptRepository: IDeptRepository
    {
        private List<Dept> con=new List<Dept>();
        public Exception ExceptionToThrow { get; set; }

        public void SaveChanges(Dept contactToUpdate)
        {
            foreach (Dept dept in con)
            {
                if (dept.DeptId == contactToUpdate.DeptId)
                {
                    con.Remove(dept);
                    con.Add(contactToUpdate);
                    break;
                }
            }
        }
        public void Add(Dept dept)
    {
        con.Add(dept);
    }
        public Dept GetContactByID(int id)
        {
            return con.FirstOrDefault(d => d.DeptId == id);
        }
        public void CreateNewContact(Dept contactToCreate)
        {
            
            con.Add(contactToCreate);
            // return contactToCreate;
        }
        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<Dept> GetAllContacts()
        {
            return con.ToList();
        }


        public void DeleteContact(int id)
        {
            con.Remove(GetContactByID(id));
        }

    }
}
