using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace UnitTestProject3.Models
{
    class TestDatabase
    {
        private static IEnumerable<Department> department;
        private static IEnumerable<Employee> employee;
        
        public static void InitializeDatabase()
        {
            department = new List<Department>
            {
            new Department()
            {
                DepartmentId=1,
                DeptName="HR"
            },
            };

            employee = new List<Employee>
            {
                new Employee()
                {
                    EmployeeId=1,
                    Empname="swapnil",
                    Empemail="bhavsar.swapnil90@gmail.com",
                    DepartmentId=1
                    
                },
            };
        }

        public static IEnumerable<Department>GetAllDepartment()
        {
            return department.ToList();
        }
        public static IEnumerable<Employee>GetAllEmployee()
        {
            return employee.ToList();
        }

        //public static IEnumerable<T> GetAll<T>()
        //{
        //    if (typeof(T) == typeof(Department))
        //    {
        //        return (IEnumerable<T>)(department);
        //    }
        //    return null;
        //}

    }
}
