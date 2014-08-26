using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace UnitTestProject3.Models
{
    class MocEmployeeRepository:IEmployeeRepository
    {
        private IList<Department> _department;
        private IList<Employee> _employee;

        public MocEmployeeRepository()
        {
            this._department = TestDatabase.GetAllDepartment().ToList();
            this._employee = TestDatabase.GetAllEmployee().ToList();
        }
         public IList<Employee> GetallEmployee()
        {
            return _employee;
        }

         public IEnumerable<Department> CreateDepartmentDropDown()
         {
             
             return _department;
         }


         public void CreateEmployee(Employee employee)
         {
             _employee.Add(employee);
             
         }

         public Employee GetEmployeebyId(int id)
         {
             return _employee.SingleOrDefault(e => e.EmployeeId == id);
         }

         public void EmployeeUpdate(Employee employee)
         {
             foreach (Employee employees in _employee)
             {
                 if(employees.EmployeeId==employee.EmployeeId)
                 {
                     _employee.Remove(employees);
                     _employee.Add(employee);
                     break;
                 }
             }
         }

         public void EmployeeDelete(int id)
         {
             var emp = GetEmployeebyId(id);
             _employee.Remove(emp);
         }


         public IList<Department> GetallDepartment()
         {

             return _department;
         }

         public void CreateDepartment(Department department)
         {
             _department.Add(department);
             
         }
         public Department GetDepartmentbyId(int id)
         {
             return _department.SingleOrDefault(d => d.DepartmentId == id);
         }
         public void DepartmentUpdate(Department department)
         {
             foreach (Department departments in _department)
             {
                 if (departments.DepartmentId == department.DepartmentId)
                 {
                     _department.Remove(departments);
                     _department.Add(department);
                     
                 }
                 break;
             }
         }
         public void DepartmentDelete(int id)
         {
             var dept = GetDepartmentbyId(id);
             _department.Remove(dept);
         }

    }
}
