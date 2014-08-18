using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<Connection>
    {

        protected override void Seed(Connection context)
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

           


        }


       
    }
}