using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class Newur
    {


        [DisplayName("UserName")]
        [Required(ErrorMessage = "Name Required")]
        public string Username { get; set; }
        [DisplayName("Email-Id")]
        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Emailid { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Required")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password Does not Match")]
        public string ConfirmPassword { get; set; }
    
    }
}