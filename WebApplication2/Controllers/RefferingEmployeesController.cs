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

namespace WebApplication2.Controllers
{
    public class RefferingEmployeesController : Controller
    {
        private HrSmartContext db = new HrSmartContext();

        // GET: RefferingEmployees
        public ActionResult Index()
        {
            return View(db.Refferings.ToList());
        }

        // GET: RefferingEmployees/Details/5
        public ActionResult Details(int? id)
        {
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

        // GET: RefferingEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RefferingEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Password,organisationName,organisationAddress,organisationPhone,Role,RewardCredit")] RefferingEmployee refferingEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Refferings.Add(refferingEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(refferingEmployee);
        }

        // GET: RefferingEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
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

        // POST: RefferingEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,organisationName,organisationAddress,organisationPhone,Role,RewardCredit")] RefferingEmployee refferingEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refferingEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refferingEmployee);
        }

        // GET: RefferingEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
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
            RefferingEmployee refferingEmployee = db.Refferings.Find(id);
            db.Refferings.Remove(refferingEmployee);
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
