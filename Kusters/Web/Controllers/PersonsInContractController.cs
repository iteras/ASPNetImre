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
    public class PersonsInContractController : Controller
    {
        //private KustersDbContext db = new KustersDbContext();
        private readonly IPersonInContractRepository _personInContractRepository = new PersonInContractRepository(new KustersDbContext());
        // GET: PersonsInContract
        public ActionResult Index()
        {
            return View(_personInContractRepository.All);
        }

        // GET: PersonsInContract/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInContract personInContract = _personInContractRepository.GetById(id);
            if (personInContract == null)
            {
                return HttpNotFound();
            }
            return View(personInContract);
        }

        // GET: PersonsInContract/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsInContract/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonInContractId,From,Until")] PersonInContract personInContract)
        {
            if (ModelState.IsValid)
            {
                _personInContractRepository.Add(personInContract);
                _personInContractRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personInContract);
        }

        // GET: PersonsInContract/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInContract personInContract = _personInContractRepository.GetById(id);
            if (personInContract == null)
            {
                return HttpNotFound();
            }
            return View(personInContract);
        }

        // POST: PersonsInContract/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonInContractId,From,Until")] PersonInContract personInContract)
        {
            if (ModelState.IsValid)
            {
                _personInContractRepository.Update(personInContract);
                _personInContractRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personInContract);
        }

        // GET: PersonsInContract/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInContract personInContract = _personInContractRepository.GetById(id);
            if (personInContract == null)
            {
                return HttpNotFound();
            }
            return View(personInContract);
        }

        // POST: PersonsInContract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonInContract personInContract = _personInContractRepository.GetById(id);
            _personInContractRepository.Delete(personInContract);
            _personInContractRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _personInContractRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
