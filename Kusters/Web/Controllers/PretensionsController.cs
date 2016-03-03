using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dal;
using Domain;

namespace Web.Controllers
{
    public class PretensionsController : Controller
    {
        private KustersDbContext db = new KustersDbContext();

        // GET: Pretensions
        public ActionResult Index()
        {
            return View(db.Pretensions.ToList());
        }

        // GET: Pretensions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretension pretension = db.Pretensions.Find(id);
            if (pretension == null)
            {
                return HttpNotFound();
            }
            return View(pretension);
        }

        // GET: Pretensions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pretensions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PretensionId,Content,Title")] Pretension pretension)
        {
            if (ModelState.IsValid)
            {
                db.Pretensions.Add(pretension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pretension);
        }

        // GET: Pretensions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretension pretension = db.Pretensions.Find(id);
            if (pretension == null)
            {
                return HttpNotFound();
            }
            return View(pretension);
        }

        // POST: Pretensions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PretensionId,Content,Title")] Pretension pretension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pretension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pretension);
        }

        // GET: Pretensions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretension pretension = db.Pretensions.Find(id);
            if (pretension == null)
            {
                return HttpNotFound();
            }
            return View(pretension);
        }

        // POST: Pretensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pretension pretension = db.Pretensions.Find(id);
            db.Pretensions.Remove(pretension);
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
