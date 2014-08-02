using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Connection : DbContext
    {
        public DbSet<Register> Registers
        {
            get;
            set;
        }
        public DbSet<Emp> Emps { get; set; }
        public DbSet<Dept> Depts { get; set; } 
    }
}