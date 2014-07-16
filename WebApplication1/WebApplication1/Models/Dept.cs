using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Dept
    {
        public int DeptId { get; set; }
        [DisplayName("Department")]
        [Required(ErrorMessage = "Department name required")]
        public string DeptName { get; set; }
       // public List<Emp> Emps { get; set; }
 
    }
}