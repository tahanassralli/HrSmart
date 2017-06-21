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
    public class RefferingEmployeesController : ApiController
    {
        HrSmartService service;
        public HrSmartContext db = new HrSmartContext();
        public RefferingEmployeesController()
        {
            service = new HrSmartService();
        }

        // GET: api/RefferingEmployees
        public IEnumerable<RefferingEmployee> GetRefferingEmployees()
        {
            var refferings = service.GetRefferings();
            return refferings;
        }

        // GET: api/RefferingEmployees/5
        [ResponseType(typeof(RefferingEmployee))]
        public IHttpActionResult GetRefferingEmployee(int id)
        {
            RefferingEmployee refferingEmployee = service.GetReffering(id);
            if (refferingEmployee == null)
            {
                return NotFound();
            }

            return Ok(refferingEmployee);
        }

        // PUT: api/RefferingEmployees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRefferingEmployee(int id, RefferingEmployee refferingEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != refferingEmployee.Id)
            {
                return BadRequest();
            }

            service.Updatereffering(refferingEmployee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefferingEmployeeExists(id))
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

        // POST: api/RefferingEmployees
        [ResponseType(typeof(RefferingEmployee))]
        public IHttpActionResult PostRefferingEmployee(RefferingEmployee refferingEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.CreateReffering(refferingEmployee);

            return CreatedAtRoute("DefaultApi", new { id = refferingEmployee.Id }, refferingEmployee);
        }

        // DELETE: api/RefferingEmployees/5
        [ResponseType(typeof(RefferingEmployee))]
        public IHttpActionResult DeleteRefferingEmployee(int id)
        {
            RefferingEmployee refferingEmployee = db.Refferings.Find(id);
            if (refferingEmployee == null)
            {
                return NotFound();
            }

            db.Refferings.Remove(refferingEmployee);
            db.SaveChanges();

            return Ok(refferingEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RefferingEmployeeExists(int id)
        {
            return db.Refferings.Count(e => e.Id == id) > 0;
        }
    }
}