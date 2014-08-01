using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EF_DeptRepository: IDeptRepository
    {
        private Connection con = null;

        public EF_DeptRepository(Connection con)
        {
            this.con.Depts.ToList();
        }
       
        public IEnumerable<Dept> GetAllContacts()
        {
            return con.Depts.ToList();
        }

        public void CreateNewContact(Dept contactToCreate)
        {
            con.Depts.Add(contactToCreate);
           
            //_db.(contactToCreate);
            //_db.SaveChanges();
            //   return contactToCreate;
        }

        public Dept GetContactByID(int id)
        {
            return con.Depts.SingleOrDefault(s => s.DeptId == id);
        }
        public void Save()
        {
            con.SaveChanges();
        }

        public void DeleteContact(Dept dept)
        {
            
            con.Depts.Remove(dept);
            
            
        }
       
    }
}