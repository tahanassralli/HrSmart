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
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApplication2.Controllers
{
    public class JobOffersController : Controller
    {
        private HrSmartContext db = new HrSmartContext();

        // GET: JobOffers
        public ActionResult Index()
        {
            HrSmartContext db = new HrSmartContext();
            List<JobOffer> lst = new List<JobOffer>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Response = client.GetAsync("api/JobOffers").Result;
            if (Response.IsSuccessStatusCode)
            {
                lst = Response.Content.ReadAsAsync<List<JobOffer>>().Result;
            }


            return View(lst);
        }

        // GET: JobOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Create
        public ActionResult Create()
        {
            ViewBag.RecuterID = new SelectList(db.Recruters, "Id", "FirstName");
            return View();
        }

        // POST: JobOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(JobOffer re)
        {
            HrSmartContext db = new HrSmartContext();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.PostAsJsonAsync<JobOffer>("api/JobOffers", re);
            return RedirectToAction("Index");
        }

        // GET: JobOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecuterID = new SelectList(db.Recruters, "Id", "FirstName", jobOffer.RecuterID);
            return View(jobOffer);
        }

        // POST: JobOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobOfferID,NameJobOffer,Description,StartDate,ExpirationDate,PointGet,RecuterID")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecuterID = new SelectList(db.Recruters, "Id", "FirstName", jobOffer.RecuterID);
            return View(jobOffer);
        }

        // GET: JobOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobOffer jobOffer = db.JobOffers.Find(id);
            db.JobOffers.Remove(jobOffer);
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
