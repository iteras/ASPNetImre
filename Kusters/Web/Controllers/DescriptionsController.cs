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
    public class DescriptionsController : Controller
    {
        //private KustersDbContext db = new KustersDbContext();
        private readonly IDescriptionRepository _descriptionRepository = new DescriptionRepository(new KustersDbContext());
        // GET: Descriptions
        public ActionResult Index()
        {
            return View(_descriptionRepository.All);
        }

        // GET: Descriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = _descriptionRepository.GetById(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // GET: Descriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DescriptionId,Content")] Description description)
        {
            if (ModelState.IsValid)
            {
                _descriptionRepository.Add(description);
                _descriptionRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(description);
        }

        // GET: Descriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = _descriptionRepository.GetById();
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DescriptionId,Content")] Description description)
        {
            if (ModelState.IsValid)
            {
                _descriptionRepository.Update(description);
                _descriptionRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(description);
        }

        // GET: Descriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = _descriptionRepository.GetById(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Description description = _descriptionRepository.GetById(id);
            _descriptionRepository.Delete(description);
            _descriptionRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _descriptionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
