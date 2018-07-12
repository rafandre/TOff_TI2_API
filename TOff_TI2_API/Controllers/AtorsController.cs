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
using TimeOff.Models;
using TOff_TI2_API.Models;

namespace TimeOff.Api
{
    public class AtorsController : ApiController
    {
        private DbCtxt db = new DbCtxt();

        // GET: api/Ators
        public IQueryable<Ator> GetAtors()
        {
            return db.Ators;
        }

        // GET: api/Ators/5
        [ResponseType(typeof(Ator))]
        public IHttpActionResult GetAtor(int id)
        {
            Ator ator = db.Ators.Find(id);
            if (ator == null)
            {
                return NotFound();
            }

            return Ok(ator);
        }

        // PUT: api/Ators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtor(int id, Ator ator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ator.Id)
            {
                return BadRequest();
            }

            db.Entry(ator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtorExists(id))
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

        // POST: api/Ators
        [ResponseType(typeof(Ator))]
        public IHttpActionResult PostAtor(Ator ator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ators.Add(ator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ator.Id }, ator);
        }

        // DELETE: api/Ators/5
        [ResponseType(typeof(Ator))]
        public IHttpActionResult DeleteAtor(int id)
        {
            Ator ator = db.Ators.Find(id);
            if (ator == null)
            {
                return NotFound();
            }

            db.Ators.Remove(ator);
            db.SaveChanges();

            return Ok(ator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtorExists(int id)
        {
            return db.Ators.Count(e => e.Id == id) > 0;
        }
    }
}