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
using TestJudicial123.Models;

namespace TestJudicial123.Controllers
{
    public class EstudiosJuridicosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EstudiosJuridicos
        public IQueryable<EstudiosJuridicos> GetEstudiosJuridicos()
        {
            return db.EstudiosJuridicos;
        }

        // GET: api/EstudiosJuridicos/5
        [ResponseType(typeof(EstudiosJuridicos))]
        public IHttpActionResult GetEstudiosJuridicos(int id)
        {
            EstudiosJuridicos estudiosJuridicos = db.EstudiosJuridicos.Find(id);
            if (estudiosJuridicos == null)
            {
                return NotFound();
            }

            return Ok(estudiosJuridicos);
        }

        // PUT: api/EstudiosJuridicos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstudiosJuridicos(EstudiosJuridicos estudiosJuridicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(estudiosJuridicos).State = EntityState.Modified;
            db.SaveChanges();            
            

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EstudiosJuridicos
        [ResponseType(typeof(EstudiosJuridicos))]
        public IHttpActionResult PostEstudiosJuridicos(EstudiosJuridicos estudiosJuridicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstudiosJuridicos.Add(estudiosJuridicos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estudiosJuridicos.Id }, estudiosJuridicos);
        }

        // DELETE: api/EstudiosJuridicos/5
        [ResponseType(typeof(EstudiosJuridicos))]
        public IHttpActionResult DeleteEstudiosJuridicos(int id)
        {
            EstudiosJuridicos estudiosJuridicos = db.EstudiosJuridicos.Find(id);
            if (estudiosJuridicos == null)
            {
                return NotFound();
            }

            db.EstudiosJuridicos.Remove(estudiosJuridicos);
            db.SaveChanges();

            return Ok(estudiosJuridicos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudiosJuridicosExists(int id)
        {
            return db.EstudiosJuridicos.Count(e => e.Id == id) > 0;
        }
    }
}