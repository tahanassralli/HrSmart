using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HrSmart.Data;
using Hrsmart.Domain.Entites;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WebApplication2.Controllers
{
    public class TenantAdminsController : Controller
    {
        private HrSmartContext db = new HrSmartContext();

        // GET: TenantAdmins
        public ActionResult Index()
        {
            HrSmartContext db = new HrSmartContext();
            List<TenantAdmin> lst = new List<TenantAdmin>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Response = client.GetAsync("api/TenantAdmins").Result;
            if (Response.IsSuccessStatusCode)
            {
                lst = Response.Content.ReadAsAsync<List<TenantAdmin>>().Result;
            }


            return View(lst);
        }

        // GET: TenantAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantAdmin tenantAdmin = db.TenantAdmis.Find(id);
            if (tenantAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tenantAdmin);
        }

        // GET: TenantAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TenantAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(TenantAdmin re)
        {
            HrSmartContext db = new HrSmartContext();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.PostAsJsonAsync<TenantAdmin>("api/TenantAdmins", re);
            return RedirectToAction("Index");
        }

        // GET: TenantAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantAdmin tenantAdmin = db.TenantAdmis.Find(id);
            if (tenantAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tenantAdmin);
        }

        // POST: TenantAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenantAdminID,FirstName,LastName,Email,Password,organisationName,organisationAddress,organisationPhone")] TenantAdmin tenantAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenantAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenantAdmin);
        }

        // GET: TenantAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantAdmin tenantAdmin = db.TenantAdmis.Find(id);
            if (tenantAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tenantAdmin);
        }

        // POST: TenantAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TenantAdmin tenantAdmin = db.TenantAdmis.Find(id);
            db.TenantAdmis.Remove(tenantAdmin);
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
