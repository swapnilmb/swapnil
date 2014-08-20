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
            var dep = new List<Department>
            {
                new Department {DeptName = "HR"},
                new Department {DeptName = "testing"},
            };
            new List<Employee>
            {
                new Employee{Empname="swapnil",Empemail="bha@gmail.com",Department = dep.Single(g=>g.DeptName=="HR")},
                new Employee{Empname="bhavsar",Empemail="bha@gmail.com",Department = dep.Single(g=>g.DeptName=="testing")},
                new Employee{Empname="bha",Empemail="bha@gmail.com",Department = dep.Single(g=>g.DeptName=="testing")}

            }.ForEach(a => context.Employees.Add(a));

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