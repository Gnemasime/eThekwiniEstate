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

        //1.3.
        public double PullAge()
        {
            EstateDb db = new EstateDb();
            var cc = (from v in db.Ow
                      where v.OwnerId == OwnerId
                      select v.OwnerAge).Single();

            return cc;
        }
        public double CalcAgePenalty()
        {
           double pcharge = 0.00;

            if(PullAge() < 26)
            {
                pcharge = CalcAreaPenaltyCost() + (CalcAreaPenaltyCost() * 0.05);
            }
            else
            {
                pcharge = CalcAreaPenaltyCost() + (CalcAreaPenaltyCost() * 0.03);
            }

            return pcharge;
        }

        //1.4.
        public double CalcTPenaltyC()
        {
            return VCost() + CalcAgePenalty();
        }

        //1.5
        public double CalcPointsD()
        {
            return Math.Floor(VCost() * 0.01);
        }

        //1.6
        public void UpdatePoints()
        {
           
            EstateDb db = new EstateDb() ;
            Owner owner = (from m in db.Ow
                           where m.OwnerId == OwnerId
                           select m).FirstOrDefault();

            owner.OwnerPoints = owner.OwnerPoints - Convert.ToInt16(CalcPointsD());
            if(owner.OwnerPoints < 0)
            {
                owner.OwnerPoints = 0;
                owner.status = "Invalid";
            }
            db.SaveChanges();
        } 

    } 
}