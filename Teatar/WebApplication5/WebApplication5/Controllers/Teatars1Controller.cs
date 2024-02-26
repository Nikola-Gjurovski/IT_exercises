using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Teatars1Controller : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Teatars1
        public IQueryable<Teatar> Getteatri()
        {
            return db.teatri;
        }

        // GET: api/Teatars1/5
        [ResponseType(typeof(Teatar))]
        public IHttpActionResult GetTeatar(int id)
        {
            Teatar teatar = db.teatri.Find(id);
            if (teatar == null)
            {
                return NotFound();
            }

            return Ok(teatar);
        }

        // PUT: api/Teatars1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeatar(int id, Teatar teatar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teatar.Id)
            {
                return BadRequest();
            }

            db.Entry(teatar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeatarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Teatars1
        [ResponseType(typeof(Teatar))]
        public IHttpActionResult PostTeatar(Teatar teatar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.teatri.Add(teatar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teatar.Id }, teatar);
        }

        // DELETE: api/Teatars1/5
        [ResponseType(typeof(Teatar))]
        public IHttpActionResult DeleteTeatar(int id)
        {
            Teatar teatar = db.teatri.Find(id);
            if (teatar == null)
            {
                return NotFound();
            }

            db.teatri.Remove(teatar);
            db.SaveChanges();

            return Ok(teatar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeatarExists(int id)
        {
            return db.teatri.Count(e => e.Id == id) > 0;
        }
    }
}