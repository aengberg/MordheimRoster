using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MordheimRoster.Models;
using EntityState = System.Data.Entity.EntityState;

namespace MordheimRoster.Controllers
{
    public class WarbandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Warbands
        public ActionResult Index()
        {
            //var list = new List<WarbandViewModel>();
            //db.Warbands.ForEach(warband => list.Add(new WarbandViewModel(warband)));
            //return View(list);
            return View(db.Warbands.ToList());
        }

        // GET: Warbands
        public ActionResult MyWarbands()
        {
            string userId = User.Identity.GetUserId();
            return View(db.Warbands.Where(p=>p.UserId == userId).ToList());
        }

        // GET: Warbands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warband warband = db.Warbands.Find(id);
            if (warband == null)
            {
                return HttpNotFound();
            }
            return View(warband);
        }

        // GET: Warbands/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warbands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "WarbandId,Name,Type,Gold")] Warband warband)
        {
            if (ModelState.IsValid)
            {
                warband.UserId = User.Identity.GetUserId();


                db.Warbands.Add(warband);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warband);
        }

        [HttpPost]
        [Authorize(Roles = "canEdit")]
        public ActionResult MultipleCommand(int? id, string command)
        {
            return View("GameMode");
        }

        // GET: Warbands/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warband warband = db.Warbands.Find(id);
            if (warband == null)
            {
                return HttpNotFound();
            }
            return View(warband);
        }

        // POST: Warbands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "WarbandId,Name,Type,Gold,Wyrdstone")] Warband warband)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warband).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warband);
        }

        // GET: Warbands/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult GameMode(int? id, string command)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warband warband = db.Warbands.Find(id);
            if (warband == null)
            {
                return HttpNotFound();
            }

            if (command != null && command.Equals("AddHero"))
            {
                var hero = new Hero();
                hero = db.Heroes.Add(hero);
                
                db.SaveChanges();

                //if(warband.Heroes==null)
                //    warband.Heroes = new List<Hero>();

                warband.Heroes.Add(hero);
                //db.Warbands.AddOrUpdate(w=>w.WarbandId, warband);
                db.Entry(warband).State = EntityState.Modified;
                
                db.SaveChanges();
            }
            return View(warband);
        }

        // POST: Warbands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult GameMode([Bind(Include = "WarbandId,Name,Type,Gold,Wyrdstone")] Warband warband)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warband).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warband);
        }

        // GET: Warbands/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warband warband = db.Warbands.Find(id);
            if (warband == null)
            {
                return HttpNotFound();
            }
            return View(warband);
        }

        // POST: Warbands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            Warband warband = db.Warbands.Find(id);
            db.Warbands.Remove(warband);
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
