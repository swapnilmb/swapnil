using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Bid
    {
        public int BidId { get; set; }
        public double Amount { get; set; }
        public DateTime Createon { get; set; }
        public int ItemId { get; set; }
        public int RegisterId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        [ForeignKey("RegisterId")]
        public virtual  Register Register { get; set; }

    }
}