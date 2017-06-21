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
    public class TenantAdminsController : ApiController
    {
        public HrSmartContext db = new HrSmartContext();
        HrSmartService service;
        public TenantAdminsController()
        {
            service = new HrSmartService();
        }

        // GET: api/TenantAdmins/5
        [ResponseType(typeof(TenantAdmin))]
        public IHttpActionResult GetTenantAdmin(int id)
        {
            TenantAdmin tenantAdmin = db.TenantAdmis.Find(id);
            if (tenantAdmin == null)
            {
                return NotFound();
            }

            return Ok(tenantAdmin);
        }

        // PUT: api/TenantAdmins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenantAdmin(int id, TenantAdmin tenantAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenantAdmin.TenantAdminID)
            {
                return BadRequest();
            }

            db.Entry(tenantAdmin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantAdminExists(id))
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

        // POST: api/TenantAdmins
        [ResponseType(typeof(TenantAdmin))]
        public IHttpActionResult PostTenantAdmin(TenantAdmin tenantAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TenantAdmis.Add(tenantAdmin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tenantAdmin.TenantAdminID }, tenantAdmin);
        }

        // DELETE: api/TenantAdmins/5
        [ResponseType(typeof(TenantAdmin))]
        public IHttpActionResult DeleteTenantAdmin(int id)
        {
            TenantAdmin tenantAdmin = db.TenantAdmis.Find(id);
            if (tenantAdmin == null)
            {
                return NotFound();
            }

            db.TenantAdmis.Remove(tenantAdmin);
            db.SaveChanges();

            return Ok(tenantAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantAdminExists(int id)
        {
            return db.TenantAdmis.Count(e => e.TenantAdminID == id) > 0;
        }

    }
}