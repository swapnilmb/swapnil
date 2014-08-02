using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UnitofWork
    {
        private Connection con = null;

        public UnitofWork()
        {
            con = new Connection();
            EF_DeptRepository = new EF_DeptRepository();

        }

        public UnitofWork(IDeptRepository deptsRepo)
        {
            EF_DeptRepository = deptsRepo;
        }

        public IDeptRepository DeptRepository
        { get;
            private set;
        }
    }
}