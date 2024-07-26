using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eThekwiniEstate.Models
{
    public class EstatePenalty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PenaltyID { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Onwer { get; set; }
        public int AreaCode { get; set; }
        public virtual Area Area { get; set;}
        public int ViolationCode { get; set; }
        public double TPenaltyCost { get; set; }

        //1.2
        public double VCost()
        {
            EstateDb db = new EstateDb();
            var cc = (from v in db.Vio
                      where v.ViolationCode == ViolationCode
                      select v.ViolationCost).Single();

            return cc;
        }

        public double ARate()
        {
            EstateDb db = new EstateDb();
            var cc = (from v in db.Are
                      where v.AreaCode == AreaCode
                      select v.AreaRate).Single();

            return cc;
        }

        public double CalcAreaPenaltyCost()
        {
            return ARate() * VCost();
        }
    }
}