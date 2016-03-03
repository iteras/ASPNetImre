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
    public class PersonsInPretensionController : Controller
    {
        private KustersDbContext db = new KustersDbContext();

        // GET: PersonsInPretension
        public ActionResult Index()
        {
            return View(db.PersonInPretensions.ToList());
        }

        // GET: PersonsInPretension/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInPretension personInPretension = db.PersonInPretensions.Find(id);
            if (personInPretension == null)
            {
                return HttpNotFound();
            }
            return View(personInPretension);
        }

        // GET: PersonsInPretension/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsInPretension/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonInPretensionId,From,Until")] PersonInPretension personInPretension)
        {
            if (ModelState.IsValid)
            {
                db.PersonInPretensions.Add(personInPretension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personInPretension);
        }

        // GET: PersonsInPretension/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInPretension personInPretension = db.PersonInPretensions.Find(id);
            if (personInPretension == null)
            {
                return HttpNotFound();
            }
            return View(personInPretension);
        }

        // POST: PersonsInPretension/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonInPretensionId,From,Until")] PersonInPretension personInPretension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personInPretension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personInPretension);
        }

        // GET: PersonsInPretension/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInPretension personInPretension = db.PersonInPretensions.Find(id);
            if (personInPretension == null)
            {
                return HttpNotFound();
            }
            return View(personInPretension);
        }

        // POST: PersonsInPretension/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonInPretension personInPretension = db.PersonInPretensions.Find(id);
            db.PersonInPretensions.Remove(personInPretension);
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
