using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        [ScaffoldColumn(false)]
        public int EmployeeId { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("UserName")]
        [Required(ErrorMessage = "Please enter UserName")]
        public string Empname { get; set; }
        [DisplayName("Email-Id")]
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email-Id is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Empemail { get; set; }



        public virtual Department Department { get; set; }
    }
}