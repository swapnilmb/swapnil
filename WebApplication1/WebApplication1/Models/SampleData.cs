using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
namespace WebApplication1.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<AppDbContext>
    {

        protected override void Seed(AppDbContext context)
        {
            var dep = new List<Dept>
            {
                new Dept {DeptName = "HR"},
                new Dept {DeptName = "testing"},
            };
            new List<Emp>
            {
                new Emp{Empname="swapnil",Empemail="bha@gmail.com",Dept = dep.Single(g=>g.DeptName=="HR")},
                new Emp{Empname="bhavsar",Empemail="bha@gmail.com",Dept = dep.Single(g=>g.DeptName=="testing")},
                new Emp{Empname="bha",Empemail="bha@gmail.com",Dept = dep.Single(g=>g.DeptName=="testing")}

            }.ForEach(a => context.Emps.Add(a));

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
            //user.Email = "swapnil@gmail.com";
            var adminresult = usermanager.Create(user, password);
            if (adminresult.Succeeded)
            {
                var result = usermanager.AddToRole(user.Id, name);


            }
            base.Seed(context);


        }


       
    }
}