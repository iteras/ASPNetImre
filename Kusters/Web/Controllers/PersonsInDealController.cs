using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dal;
using Dal.Interfaces;
using Dal.Repositories;
using Domain;

namespace Web.Controllers
{
    public class PersonsInDealController : Controller
    {
        //private KustersDbContext db = new KustersDbContext();
        private readonly IPersonInDealRepository _personInDealRepository = new PersonInDealRepository(new KustersDbContext());
        // GET: PersonsInDeal
        public ActionResult Index()
        {
            return View(_personInDealRepository.All);
        }

        // GET: PersonsInDeal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInDeal personInDeal = _personInDealRepository.GetById(id);
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
                _personInDealRepository.Add(personInDeal);
                _personInDealRepository.SaveChanges();
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
            PersonInDeal personInDeal = _personInDealRepository.GetById(id);
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
                _personInDealRepository.Update(personInDeal);
                _personInDealRepository.SaveChanges();
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
            PersonInDeal personInDeal = _personInDealRepository.GetById(id);
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
            PersonInDeal personInDeal = _personInDealRepository.GetById(id);
            _personInDealRepository.Delete(personInDeal);
            _personInDealRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _personInDealRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
