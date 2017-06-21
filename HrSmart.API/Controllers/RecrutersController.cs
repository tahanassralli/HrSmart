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
using HrSmart.Data;
using Hrsmart.Domain.Entites;
using HrSmart.Service;

namespace HrSmart.API.Controllers
{
    public class RecrutersController : ApiController
    {
        public HrSmartContext db = new HrSmartContext();
        HrSmartService service;
        public RecrutersController()
        {
            service = new HrSmartService();
        }
        // GET: api/Recruters
        public IEnumerable<Recruter> GetRecruters()
        {
            var recruters = service.GetRecruters();
            return recruters;
        }

        // GET: api/Recruters/5
        [ResponseType(typeof(Recruter))]
        public IHttpActionResult GetRecruter(int id)
        {
            Recruter recruter = service.GetRecruter(id);
            if (recruter == null)
            {
                return NotFound();
            }

            return Ok(recruter);
        }

        // PUT: api/Recruters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecruter(int id, Recruter recruter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recruter.Id)
            {
                return BadRequest();
            }

            service.Updaterecruter(recruter);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecruterExists(id))
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

        // POST: api/Recruters
        [ResponseType(typeof(Recruter))]
        public IHttpActionResult PostRecruter(Recruter recruter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.CreateRecruter(recruter);

            return CreatedAtRoute("DefaultApi", new { id = recruter.Id }, recruter);
        }

        // DELETE: api/Recruters/5
        [ResponseType(typeof(Recruter))]
        public IHttpActionResult DeleteRecruter(int id)
        {
            Recruter recruter = db.Recruters.Find(id);
            if (recruter == null)
            {
                return NotFound();
            }

            db.Recruters.Remove(recruter);
            db.SaveChanges();

            return Ok(recruter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecruterExists(int id)
        {
            return db.Recruters.Count(e => e.Id == id) > 0;
        }
    }
}