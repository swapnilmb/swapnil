using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("Connection")
        {
        }
    }
}