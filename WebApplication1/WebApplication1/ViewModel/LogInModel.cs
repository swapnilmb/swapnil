using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class LogInModel
    {


        [Required(ErrorMessage = "Please Enter Email or Username")]
        [DisplayName("Email Or UserName")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}