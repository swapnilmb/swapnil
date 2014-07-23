using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Connections:DbContext
    {
        public DbSet<Register> Registers
        {
            get;
            set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }

        
    }
}