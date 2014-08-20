using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class Editprofile
    {
        [DisplayName("UserName")]
        [Required(ErrorMessage = "UserName Required")]
        
        public string UserName { get; set; }

         [DisplayName("Email-Id")]
        [Required(ErrorMessage = "Email-Id Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Country { get; set; }
    }
}