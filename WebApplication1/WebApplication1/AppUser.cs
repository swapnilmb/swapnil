using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1
{
    public class AppUser : IdentityUser
    {
        //public AppUser(ClaimsPrincipal principal) : base(principal)
        //{
            
        //}
        //public string Name
        //{
        //    get
        //    {
        //        return this.FindFirst(ClaimTypes.Name).Value;
        //    }
        //}

        //public string Country
        //{
        //    get
        //    {
        //        return this.FindFirst(ClaimTypes.Country).Value;
        //    }
        //}

        //public string Email
        //{
        //    get
        //    {
        //        return this.FindFirst(ClaimTypes.Email).Value;
        //    }
        //}
        public string Country { get; set; }
       
      
       // public string Email { get; set; }
    }
}