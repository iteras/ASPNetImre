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
    public class PersonsInPretensionController : Controller
    {
        //private KustersDbContext db = new KustersDbContext();
        private readonly IPersonInPretensionRepository _personInPretensionRepository = new PersonInPretensionRepository(new KustersDbContext());
        // GET: PersonsInPretension
        public ActionResult Index()
        {
            return View(_personInPretensionRepository.All);
        }

        // GET: PersonsInPretension/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInPretension personInPretension = _personInPretensionRepository.GetById(id);
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
                _personInPretensionRepository.Add(personInPretension);
                _personInPretensionRepository.SaveChanges();
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
            PersonInPretension personInPretension = _personInPretensionRepository.GetById(id);
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
                _personInPretensionRepository.Update(personInPretension);
                _personInPretensionRepository.SaveChanges();
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
            PersonInPretension personInPretension = _personInPretensionRepository.GetById(id);
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
            PersonInPretension personInPretension = _personInPretensionRepository.GetById(id);
            _personInPretensionRepository.Delete(personInPretension);
            _personInPretensionRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _personInPretensionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
