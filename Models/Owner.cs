using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eThekwiniEstate.Models
{
    public class Owner
    {
        [Key]
    
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int OwnerAge { get; set; }
        public double OwnerPoints { get; set; }
    }
}