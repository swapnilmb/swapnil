using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        AppDbContext context = new AppDbContext();

        public IList<Employee> GetallEmployee()
        {
            var employeelist = context.Employees.Include(d => d.Department).ToList();
            return employeelist;
       }

        public IEnumerable<Department> CreateDepartmentDropDown()
        {
            var department = context.Departments;
            return department;
        }

        public void CreateEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public Employee GetEmployeebyId(int id)
        {
            return context.Employees.SingleOrDefault(e => e.EmployeeId == id);
        }

        public void EmployeeUpdate(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void EmployeeDelete(int id)
        {

            var emp = GetEmployeebyId(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }


        public IList<Department>GetallDepartment()
        {
            var departmentlist=context.Departments.ToList();
            return departmentlist;
        }

        public void CreateDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }
        public Department GetDepartmentbyId(int id)
        {
            return context.Departments.SingleOrDefault(d => d.DepartmentId == id);
        }
        public void DepartmentUpdate(Department department)
        {
            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DepartmentDelete(int id)
        {
            var department = GetDepartmentbyId(id);
            context.Departments.Remove(department);
            context.SaveChanges();
        }
    }
}