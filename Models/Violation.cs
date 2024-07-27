using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eThekwiniEstate.Models
{
    public class Violation
    {
        [Key]
        
        public int ViolationCode { get; set; }
        public string ViolationName { get; set; }
        public double ViolationCost { get; set; }

    }
}