using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface IDeptRepository
    {
        Dept GetContactByID(int id);
        void CreateNewContact(Dept contactToCreate);
        void DeleteContact(Dept dept);
       
        IEnumerable<Dept> GetAllContacts();
        void Save();

    }
}