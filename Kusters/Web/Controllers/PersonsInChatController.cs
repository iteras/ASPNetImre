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
    public class PersonsInChatController : Controller
    {
        //private KustersDbContext db = new KustersDbContext();
        private readonly IPersonInChatRepository _personInChatRepository = new PersonInChatRepository(new KustersDbContext());
        // GET: PersonsInChat
        public ActionResult Index()
        {
            return View(_personInChatRepository.All);
        }

        // GET: PersonsInChat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInChat personInChat = _personInChatRepository.GetById(id);
            if (personInChat == null)
            {
                return HttpNotFound();
            }
            return View(personInChat);
        }

        // GET: PersonsInChat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsInChat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonInChatId,Time")] PersonInChat personInChat)
        {
            if (ModelState.IsValid)
            {
                _personInChatRepository.Add(personInChat);
                _personInChatRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personInChat);
        }

        // GET: PersonsInChat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInChat personInChat = _personInChatRepository.GetById(id);
            if (personInChat == null)
            {
                return HttpNotFound();
            }
            return View(personInChat);
        }

        // POST: PersonsInChat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonInChatId,Time")] PersonInChat personInChat)
        {
            if (ModelState.IsValid)
            {
                _personInChatRepository.Update(personInChat);
                _personInChatRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personInChat);
        }

        // GET: PersonsInChat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInChat personInChat = _personInChatRepository.GetById(id);
            if (personInChat == null)
            {
                return HttpNotFound();
            }
            return View(personInChat);
        }

        // POST: PersonsInChat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonInChat personInChat = _personInChatRepository.GetById(id);
            _personInChatRepository.Delete(personInChat);
            _personInChatRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _personInChatRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
