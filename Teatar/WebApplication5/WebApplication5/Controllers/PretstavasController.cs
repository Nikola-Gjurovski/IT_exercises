using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class PretstavasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pretstavas
        public ActionResult Index()
        {
            var pretstavas = db.pretstavas.Include(p => p.Actor).Include(p => p.Genre);
            return View(pretstavas.ToList());
        }

        // GET: Pretstavas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretstava pretstava = db.pretstavas.Find(id);
            if (pretstava == null)
            {
                return HttpNotFound();
            }
            return View(pretstava);
        }

        // GET: Pretstavas/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.actors, "ActorId", "Name");
            ViewBag.GenreId = new SelectList(db.genres, "GenreId", "Name");
            return View();
        }

        // POST: Pretstavas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ActorId,GenreId,Price,code")] Pretstava pretstava)
        {
            if (ModelState.IsValid)
            {
                db.pretstavas.Add(pretstava);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.actors, "ActorId", "Name", pretstava.ActorId);
            ViewBag.GenreId = new SelectList(db.genres, "GenreId", "Name", pretstava.GenreId);
            return View(pretstava);
        }

        // GET: Pretstavas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretstava pretstava = db.pretstavas.Find(id);
            if (pretstava == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.actors, "ActorId", "Name", pretstava.ActorId);
            ViewBag.GenreId = new SelectList(db.genres, "GenreId", "Name", pretstava.GenreId);
            return View(pretstava);
        }

        // POST: Pretstavas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ActorId,GenreId,Price,code")] Pretstava pretstava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pretstava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.actors, "ActorId", "Name", pretstava.ActorId);
            ViewBag.GenreId = new SelectList(db.genres, "GenreId", "Name", pretstava.GenreId);
            return View(pretstava);
        }

        // GET: Pretstavas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretstava pretstava = db.pretstavas.Find(id);
            if (pretstava == null)
            {
                return HttpNotFound();
            }
            return View(pretstava);
        }

        // POST: Pretstavas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pretstava pretstava = db.pretstavas.Find(id);
            db.pretstavas.Remove(pretstava);
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
