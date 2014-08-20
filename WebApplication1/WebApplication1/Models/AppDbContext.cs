using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace WebApplication1.Models
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Emp> Emps { get; set; }
        public DbSet<Dept> Depts { get; set; } 
    }
}