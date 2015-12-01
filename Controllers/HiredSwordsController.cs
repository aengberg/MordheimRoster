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
    public class HiredSwordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HiredSwords
        public ActionResult Index()
        {
            return View(db.HiredSwords.ToList());
        }

        // GET: HiredSwords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HiredSwords hiredSwords = db.HiredSwords.Find(id);
            if (hiredSwords == null)
            {
                return HttpNotFound();
            }
            return View(hiredSwords);
        }

        // GET: HiredSwords/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HiredSwords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "HiredSwordsId,Name,Type,Experience")] HiredSwords hiredSwords)
        {
            if (ModelState.IsValid)
            {
                db.HiredSwords.Add(hiredSwords);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hiredSwords);
        }

        // GET: HiredSwords/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HiredSwords hiredSwords = db.HiredSwords.Find(id);
            if (hiredSwords == null)
            {
                return HttpNotFound();
            }
            return View(hiredSwords);
        }

        // POST: HiredSwords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "HiredSwordsId,Name,Type,Experience")] HiredSwords hiredSwords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hiredSwords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hiredSwords);
        }

        // GET: HiredSwords/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HiredSwords hiredSwords = db.HiredSwords.Find(id);
            if (hiredSwords == null)
            {
                return HttpNotFound();
            }
            return View(hiredSwords);
        }

        // POST: HiredSwords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            HiredSwords hiredSwords = db.HiredSwords.Find(id);
            db.HiredSwords.Remove(hiredSwords);
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
