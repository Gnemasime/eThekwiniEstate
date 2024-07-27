using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eThekwiniEstate.Models;

namespace eThekwiniEstate.Controllers
{
    public class EstatePenaltiesController : Controller
    {
        private EstateDb db = new EstateDb();

        // GET: EstatePenalties
        public ActionResult Index()
        {
            var estate = db.Estate.Include(e => e.Area).Include(e => e.Onwer);
            return View(estate.ToList());
        }

        // GET: EstatePenalties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatePenalty estatePenalty = db.Estate.Find(id);
            if (estatePenalty == null)
            {
                return HttpNotFound();
            }
            return View(estatePenalty);
        }

        // GET: EstatePenalties/Create
        public ActionResult Create()
        {
            ViewBag.AreaCode = new SelectList(db.Are, "AreaCode", "AreaName");
            ViewBag.OwnerId = new SelectList(db.Ow, "OwnerId", "OwnerName");
            return View();
        }

        // POST: EstatePenalties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PenaltyID,OwnerId,AreaCode,ViolationCode,TPenaltyCost")] EstatePenalty estatePenalty)
        {
            if (ModelState.IsValid)
            {
                db.Estate.Add(estatePenalty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaCode = new SelectList(db.Are, "AreaCode", "AreaName", estatePenalty.AreaCode);
            ViewBag.OwnerId = new SelectList(db.Ow, "OwnerId", "OwnerName", estatePenalty.OwnerId);
            return View(estatePenalty);
        }

        // GET: EstatePenalties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatePenalty estatePenalty = db.Estate.Find(id);
            if (estatePenalty == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaCode = new SelectList(db.Are, "AreaCode", "AreaName", estatePenalty.AreaCode);
            ViewBag.OwnerId = new SelectList(db.Ow, "OwnerId", "OwnerName", estatePenalty.OwnerId);
            return View(estatePenalty);
        }

        // POST: EstatePenalties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PenaltyID,OwnerId,AreaCode,ViolationCode,TPenaltyCost")] EstatePenalty estatePenalty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estatePenalty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaCode = new SelectList(db.Are, "AreaCode", "AreaName", estatePenalty.AreaCode);
            ViewBag.OwnerId = new SelectList(db.Ow, "OwnerId", "OwnerName", estatePenalty.OwnerId);
            return View(estatePenalty);
        }

        // GET: EstatePenalties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatePenalty estatePenalty = db.Estate.Find(id);
            if (estatePenalty == null)
            {
                return HttpNotFound();
            }
            return View(estatePenalty);
        }

        // POST: EstatePenalties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstatePenalty estatePenalty = db.Estate.Find(id);
            db.Estate.Remove(estatePenalty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
