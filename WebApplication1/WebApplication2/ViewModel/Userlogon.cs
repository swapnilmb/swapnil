using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
    }
}