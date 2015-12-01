using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MordheimRoster.Models;
using EntityState = System.Data.Entity.EntityState;

namespace MordheimRoster.Controllers
{
    public class HenchmenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Henchmen
        public ActionResult Index()
        {
            return View(db.Henchmen.ToList());
        }

        // GET: Henchmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henchmen henchmen = db.Henchmen.Find(id);
            if (henchmen == null)
            {
                return HttpNotFound();
            }
            return View(henchmen);
        }

        // GET: Henchmen/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Henchmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "HenchmenId,Number,GroupExperience,Name,Type,Experience")] Henchmen henchmen)
        {
            if (ModelState.IsValid)
            {
                db.Henchmen.Add(henchmen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(henchmen);
        }

        // GET: Henchmen/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henchmen henchmen = db.Henchmen.Find(id);
            if (henchmen == null)
            {
                return HttpNotFound();
            }
            return View(henchmen);
        }

        // POST: Henchmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "HenchmenId,Number,GroupExperience,Name,Type,Experience")] Henchmen henchmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(henchmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(henchmen);
        }

        // GET: Henchmen/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henchmen henchmen = db.Henchmen.Find(id);
            if (henchmen == null)
            {
                return HttpNotFound();
            }
            return View(henchmen);
        }

        // POST: Henchmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            Henchmen henchmen = db.Henchmen.Find(id);
            db.Henchmen.Remove(henchmen);
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
