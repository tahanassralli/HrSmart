using Hrsmart.Domain.Entites;
using HrSmart.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class RefferingController : Controller
    {
        // GET: Reffering
        public ActionResult Index()
        {
            HrSmartContext db = new HrSmartContext();
            List<RefferingEmployee> lst = new List<RefferingEmployee>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Response = client.GetAsync("Api/RefferingEmployees").Result;
            if (Response.IsSuccessStatusCode)
            {
                lst = Response.Content.ReadAsAsync<List<RefferingEmployee>>().Result;
            }


            return View(lst);
        }

        // GET: Reffering/Details/5
        public ActionResult Details(int? id)
        {
            HrSmartContext db = new HrSmartContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefferingEmployee refferingEmployee = db.Refferings.Find(id);
            if (refferingEmployee == null)
            {
                return HttpNotFound();
            }
            return View(refferingEmployee);
        }

        // GET: Reffering/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reffering/Create
        [HttpPost]
        public ActionResult Create(RefferingEmployee re)
        {
            HrSmartContext db = new HrSmartContext();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.PostAsJsonAsync<RefferingEmployee>("Api/RefferingEmployees", re);
            return RedirectToAction("Index");
        }

        // GET: Reffering/Edit/5
        

        // POST: Reffering/Edit/5
        
        public ActionResult Edit(int? id)
        {
            HrSmartContext db = new HrSmartContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefferingEmployee refferingEmployee = db.Refferings.Find(id);
            if (refferingEmployee == null)
            {
                return HttpNotFound();
            }
            return View(refferingEmployee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,organisationName,organisationAddress,organisationPhone,Role,RewardCredit")] RefferingEmployee refferingEmployee)
        {
            if (ModelState.IsValid)
            {
                HrSmartContext db = new HrSmartContext();
                db.Entry(refferingEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refferingEmployee);
        }

        // GET: Reffering/Delete/5
       

        // POST: Reffering/Delete/5
        public ActionResult Delete(int? id)
        {
            HrSmartContext db = new HrSmartContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefferingEmployee refferingEmployee = db.Refferings.Find(id);
            if (refferingEmployee == null)
            {
                return HttpNotFound();
            }
            return View(refferingEmployee);
        }

        // POST: RefferingEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HrSmartContext db = new HrSmartContext();
            RefferingEmployee refferingEmployee = db.Refferings.Find(id);
            db.Refferings.Remove(refferingEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
