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
    public class SpecialRulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpecialRules
        public ActionResult Index()
        {
            return View(db.SpecialRules.ToList());
        }

        // GET: SpecialRules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialRule specialRule = db.SpecialRules.Find(id);
            if (specialRule == null)
            {
                return HttpNotFound();
            }
            return View(specialRule);
        }

        // GET: SpecialRules/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialRules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "SpecialRuleId,Name,Description")] SpecialRule specialRule)
        {
            if (ModelState.IsValid)
            {
                db.SpecialRules.Add(specialRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialRule);
        }

        // GET: SpecialRules/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialRule specialRule = db.SpecialRules.Find(id);
            if (specialRule == null)
            {
                return HttpNotFound();
            }
            return View(specialRule);
        }

        // POST: SpecialRules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "SpecialRuleId,Name,Description")] SpecialRule specialRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialRule);
        }

        // GET: SpecialRules/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialRule specialRule = db.SpecialRules.Find(id);
            if (specialRule == null)
            {
                return HttpNotFound();
            }
            return View(specialRule);
        }

        // POST: SpecialRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialRule specialRule = db.SpecialRules.Find(id);
            db.SpecialRules.Remove(specialRule);
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
