using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication1.ViewModel
{
    public class Userlog
    {
        public int UserlogonId { get; set; }
        [Required(ErrorMessage = "Email-Id Required")]
        [DataType(DataType.EmailAddress)]
        public string Emailid { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]

        public bool RememberMe { get; set; }
        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}