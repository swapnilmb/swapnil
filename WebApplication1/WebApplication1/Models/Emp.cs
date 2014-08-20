using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Emp
    {
        [ScaffoldColumn(false)]
        public int EmpId { get; set; }
         [DisplayName("Department")]
        public int DeptId { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter Name")]
        public string Empname { get; set; }
        [DisplayName("Email_id")]
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Empemail { get; set; }

       

        public virtual Dept Dept { get; set; }
    }
}