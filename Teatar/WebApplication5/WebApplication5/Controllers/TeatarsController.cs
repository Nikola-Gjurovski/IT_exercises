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
    public class TeatarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teatars
        public ActionResult Index()
        {
            return View(db.teatri.ToList());
        }

        // GET: Teatars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teatar teatar = db.teatri.Find(id);
            if (teatar == null)
            {
                return HttpNotFound();
            }
            return View(teatar);
        }

        // GET: Teatars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teatars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,Rating")] Teatar teatar)
        {
            if (ModelState.IsValid)
            {
                db.teatri.Add(teatar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teatar);
        }

        // GET: Teatars/Edit/5
        [Authorize(Roles ="Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teatar teatar = db.teatri.Find(id);
            if (teatar == null)
            {
                return HttpNotFound();
            }
            return View(teatar);
        }
        public ActionResult AddPretstava(int id)
        {
            TeatarPretstava model=new TeatarPretstava();
            model.TeatarId = id;
            model.teatar=db.teatri.Find(id);
            model.Pretstava=db.pretstavas.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPretstava(TeatarPretstava model)
        {
            var teatar = db.teatri.Find(model.TeatarId);
            var pretstava=db.pretstavas.Find(model.PretstavaId);
            teatar.Pretstava.Add(pretstava);
            db.SaveChanges();
            return View("Index",db.teatri.ToArray());
        }
        // POST: Teatars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,Rating")] Teatar teatar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teatar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teatar);
        }

        // GET: Teatars/Delete/5
        /*public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teatar teatar = db.teatri.Find(id);
            if (teatar == null)
            {
                return HttpNotFound();
            }
            return View(teatar);
        }

        // POST: Teatars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]*/
        public ActionResult Delete(int id)
        {
            Teatar teatar = db.teatri.Find(id);
            db.teatri.Remove(teatar);
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
