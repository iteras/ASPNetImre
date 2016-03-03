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
    public class PersonsInDealController : Controller
    {
        private KustersDbContext db = new KustersDbContext();

        // GET: PersonsInDeal
        public ActionResult Index()
        {
            return View(db.PersonInDeals.ToList());
        }

        // GET: PersonsInDeal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInDeal personInDeal = db.PersonInDeals.Find(id);
            if (personInDeal == null)
            {
                return HttpNotFound();
            }
            return View(personInDeal);
        }

        // GET: PersonsInDeal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsInDeal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonInDealId,Date")] PersonInDeal personInDeal)
        {
            if (ModelState.IsValid)
            {
                db.PersonInDeals.Add(personInDeal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personInDeal);
        }

        // GET: PersonsInDeal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInDeal personInDeal = db.PersonInDeals.Find(id);
            if (personInDeal == null)
            {
                return HttpNotFound();
            }
            return View(personInDeal);
        }

        // POST: PersonsInDeal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonInDealId,Date")] PersonInDeal personInDeal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personInDeal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personInDeal);
        }

        // GET: PersonsInDeal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInDeal personInDeal = db.PersonInDeals.Find(id);
            if (personInDeal == null)
            {
                return HttpNotFound();
            }
            return View(personInDeal);
        }

        // POST: PersonsInDeal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonInDeal personInDeal = db.PersonInDeals.Find(id);
            db.PersonInDeals.Remove(personInDeal);
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
