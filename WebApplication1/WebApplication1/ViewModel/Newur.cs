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
        [System.Web.Mvc.Remote("IsUserNameAvailable","Auth",HttpMethod = "POST",ErrorMessage="UserName Is been taken")]
        public string Name { get; set; }
        [DisplayName("Email-Id")]
        [System.Web.Mvc.Remote("IsUserEmailAvailable", "Auth",HttpMethod = "POST", ErrorMessage = "Email already exists. Please enter a different Email.")]
        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Emailid { get; set; }

        [DisplayName("Password")]
        //[Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required(ErrorMessage = "Confirm Password Required")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password Does not Match")]
        public string ConfirmPassword { get; set; }
             [Required(ErrorMessage="Enter your Country")]
        public string Country { get; set; }
    
    }
}