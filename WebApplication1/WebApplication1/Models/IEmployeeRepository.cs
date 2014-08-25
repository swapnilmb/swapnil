using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface IEmployeeRepository
    {
        IList<Employee> GetallEmployee();
        IEnumerable<Department> CreateDepartmentDropDown();
        void CreateEmployee(Employee employee);

        Employee GetEmployeebyId(int id);
        void EmployeeUpdate(Employee employee);
        void EmployeeDelete(int id);

        IList<Department> GetallDepartment();
        void CreateDepartment(Department department);
        Department GetDepartmentbyId(int id);
        void DepartmentUpdate(Department department);
        void DepartmentDelete(int id);

    }
}