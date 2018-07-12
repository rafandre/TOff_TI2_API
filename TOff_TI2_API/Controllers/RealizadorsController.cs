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
    
    public class RealizadorsController : ApiController
    {
        //referência para a base de dados  
        private DbCtxt db = new DbCtxt();

        // GET: api/Realizadors/5
        [HttpGet, Route("api/realizadores")]
        public IHttpActionResult GetRealizador()
        {
            //codigo 
            var resultado = db.Realizador.Select(
               aa => new
               {
                   id = aa.Id,  // Retorna o Id do Realizador
                   nome = aa.NomeRealizador, // Retorna o Titulo do Filme 
                   ano = aa.DataNasc, // Retorna o Ano de Lançamento 
                   sinopse = aa.Biografia, //Rertorna a Biografia do Realizador 
               });

            return Ok(resultado);
        }

        // PUT: api/Realizadors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRealizador(int id, Realizador realizador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realizador.Id)
            {
                return BadRequest();
            }

            db.Entry(realizador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealizadorExists(id))
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

        // POST: api/Realizadors
        [ResponseType(typeof(Realizador))]
        public IHttpActionResult PostRealizador(Realizador realizador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Realizador.Add(realizador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = realizador.Id }, realizador);
        }

        // DELETE: api/Realizadors/5
        [ResponseType(typeof(Realizador))]
        public IHttpActionResult DeleteRealizador(int id)
        {
            Realizador realizador = db.Realizador.Find(id);
            if (realizador == null)
            {
                return NotFound();
            }

            db.Realizador.Remove(realizador);
            db.SaveChanges();

            return Ok(realizador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealizadorExists(int id)
        {
            return db.Realizador.Count(e => e.Id == id) > 0;
        }
    }
}