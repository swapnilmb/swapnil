using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class Item
    {
        public int ItemId { get; set ; }
        [Required(ErrorMessage = "Iteam name Required")]
        [DisplayName("Item Name")]
        public string Itemname { get; set; }
        [Required(ErrorMessage = "Should give Initial price")]
        [DisplayName("Price")]
        public double Itemprice { get; set; }
        [DisplayName("Start Date")]
        //[DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Startdate { get; set; }
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayName("End Date")]
        public DateTime Enddate { get; set; }
      
        public virtual ICollection<Bid> Bids { get; set; }
 

    }
}