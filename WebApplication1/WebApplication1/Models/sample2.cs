using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
namespace WebApplication1.Models
{
    public class sample2 : DropCreateDatabaseIfModelChanges<AppDbContext>
    {

        protected override void Seed(AppDbContext context)
        {
            var usermanager = new UserManager<AppUser>(
                  new UserStore<AppUser>(context));
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string name = "Admin";

            string password = "swapnil";

            if (!rolemanager.RoleExists(name))
            {
                var roleresult = rolemanager.Create(new IdentityRole(name));
            }

            var user = new AppUser();

            user.UserName = name;
            user.Country = "India";
            var adminresult = usermanager.Create(user, password);
            if (adminresult.Succeeded)
            {
                var result = usermanager.AddToRole(user.Id, name);


            }
            base.Seed(context);


        }

    }
}