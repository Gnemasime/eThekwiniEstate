using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eThekwiniEstate.Models
{
    public class EstateDb : DbContext
    {
        public EstateDb(): base ("EstatePenalty")
        {

        }
        public DbSet<Area> Are { get; set; }
        public DbSet<Owner> Ow { get; set; }
        public DbSet<Violation> Vio { get; set; }
        public DbSet<EstatePenalty> Estate { get; set; }
    }
} 