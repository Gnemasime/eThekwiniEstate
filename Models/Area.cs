﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eThekwiniEstate.Models
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AreaCode { get; set; }
        public string AreaName { get; set; }
        public double AreaRate { get; set; }
    }
}