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
using BertaProto.Models;

namespace BertaProto.Controllers
{
    public class IgenyekController : ApiController
    {
        private IgenyDBContext db = new IgenyDBContext();

        // GET: api/Igenyek
        public IQueryable<Igeny> GetIgenyek()
        {
            return db.Igenyek;
        }

        // GET: api/Igenyek/5
        [ResponseType(typeof(Igeny))]
        public IHttpActionResult GetIgeny(int id)
        {
            Igeny igeny = db.Igenyek.Find(id);
            if (igeny == null)
            {
                return NotFound();
            }

            return Ok(igeny);
        }

        // PUT: api/Igenyek/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIgeny(int id, Igeny igeny)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != igeny.ID)
            {
                return BadRequest();
            }

            db.Entry(igeny).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IgenyExists(id))
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

        // POST: api/Igenyek
        [ResponseType(typeof(Igeny))]
        public IHttpActionResult PostIgeny(Igeny igeny)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Igenyek.Add(igeny);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = igeny.ID }, igeny);
        }

        // DELETE: api/Igenyek/5
        [ResponseType(typeof(Igeny))]
        public IHttpActionResult DeleteIgeny(int id)
        {
            Igeny igeny = db.Igenyek.Find(id);
            if (igeny == null)
            {
                return NotFound();
            }

            db.Igenyek.Remove(igeny);
            db.SaveChanges();

            return Ok(igeny);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IgenyExists(int id)
        {
            return db.Igenyek.Count(e => e.ID == id) > 0;
        }
    }
}