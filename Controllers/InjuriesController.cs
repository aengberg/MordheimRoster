using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MordheimRoster.Models;
using EntityState = System.Data.Entity.EntityState;

namespace MordheimRoster.Controllers
{
    public class InjuriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Injuries
        public ActionResult Index()
        {
            return View(db.Injuries.ToList());
        }

        // GET: Injuries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injurie injurie = db.Injuries.Find(id);
            if (injurie == null)
            {
                return HttpNotFound();
            }
            return View(injurie);
        }

        // GET: Injuries/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Injuries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "InjurieId,Name,Description")] Injurie injurie)
        {
            if (ModelState.IsValid)
            {
                db.Injuries.Add(injurie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(injurie);
        }

        // GET: Injuries/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injurie injurie = db.Injuries.Find(id);
            if (injurie == null)
            {
                return HttpNotFound();
            }
            return View(injurie);
        }

        // POST: Injuries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "InjurieId,Name,Description")] Injurie injurie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(injurie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(injurie);
        }

        // GET: Injuries/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injurie injurie = db.Injuries.Find(id);
            if (injurie == null)
            {
                return HttpNotFound();
            }
            return View(injurie);
        }

        // POST: Injuries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            Injurie injurie = db.Injuries.Find(id);
            db.Injuries.Remove(injurie);
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
