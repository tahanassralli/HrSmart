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
    public class RecrutersController : Controller
    {
        private HrSmartContext db = new HrSmartContext();

        // GET: Recruters
        public ActionResult Index()
        {
            HrSmartContext db = new HrSmartContext();
            List<Recruter> lst = new List<Recruter>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Response = client.GetAsync("api/Recruters").Result;
            if (Response.IsSuccessStatusCode)
            {
                lst = Response.Content.ReadAsAsync<List<Recruter>>().Result;
            }


            return View(lst);
        }

        // GET: Recruters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruter recruter = db.Recruters.Find(id);
            if (recruter == null)
            {
                return HttpNotFound();
            }
            return View(recruter);
        }

        // GET: Recruters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recruters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(RefferingEmployee re)
        {
            HrSmartContext db = new HrSmartContext();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.PostAsJsonAsync<RefferingEmployee>("api/Recruters", re);
            return RedirectToAction("Index");
        }

        // GET: Recruters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruter recruter = db.Recruters.Find(id);
            if (recruter == null)
            {
                return HttpNotFound();
            }
            return View(recruter);
        }

        // POST: Recruters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,organisationName,organisationAddress,organisationPhone,Role")] Recruter recruter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recruter);
        }

        // GET: Recruters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruter recruter = db.Recruters.Find(id);
            if (recruter == null)
            {
                return HttpNotFound();
            }
            return View(recruter);
        }

        // POST: Recruters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recruter recruter = db.Recruters.Find(id);
            db.Recruters.Remove(recruter);
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
