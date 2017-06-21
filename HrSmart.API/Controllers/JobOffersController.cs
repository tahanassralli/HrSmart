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
    public class JobOffersController : ApiController
    {
        public HrSmartContext db = new HrSmartContext();
        HrSmartService service;
        public JobOffersController()
        {
            service = new HrSmartService();
        }

        // GET: api/JobOffers
        public IEnumerable<JobOffer> GetJobOffers()
        {
            var jobs = service.GetJoboffer();
            return jobs;
        }

        // GET: api/JobOffers/5
        [ResponseType(typeof(JobOffer))]
        public IHttpActionResult GetJobOffer(int id)
        {
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            return Ok(jobOffer);
        }

        // PUT: api/JobOffers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobOffer(int id, JobOffer jobOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobOffer.JobOfferID)
            {
                return BadRequest();
            }

            db.Entry(jobOffer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOfferExists(id))
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

        // POST: api/JobOffers
        [ResponseType(typeof(JobOffer))]
        public IHttpActionResult PostJobOffer(JobOffer jobOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.CreateJoboffer(jobOffer);

            return CreatedAtRoute("DefaultApi", new { id = jobOffer.JobOfferID }, jobOffer);
        }

        // DELETE: api/JobOffers/5
        [ResponseType(typeof(JobOffer))]
        public IHttpActionResult DeleteJobOffer(int id)
        {
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            db.JobOffers.Remove(jobOffer);
            db.SaveChanges();

            return Ok(jobOffer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobOfferExists(int id)
        {
            return db.JobOffers.Count(e => e.JobOfferID == id) > 0;
        }

    }
}