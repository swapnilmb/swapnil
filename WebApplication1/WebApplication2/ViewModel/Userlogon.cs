using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.ViewModel
{
    public class Userlogon
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