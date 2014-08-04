using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Register
    {

        public int RegisterId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Emailid { get; set; }
   
        public string Country { get; set; }
    }
}