using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cwg_Exercise.Data.Context;
using Cwg_Exercise.Models;
using Cwg_Exercise.Business_Logic.Concrete;

namespace Cwg_Exercise.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        private Admin_Implementation adminImplementation = new Admin_Implementation();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult ViewApproved() {
          var approvedApps =  adminImplementation.ViewSpecificApplications("approved").AsEnumerable();
            return View(approvedApps);
        }
        public ActionResult ViewPending() {
            var pendingApps = adminImplementation.ViewSpecificApplications("pending").AsEnumerable();

            return View(pendingApps);
        }
        public ActionResult ViewRejected() {
            var rejectedApps = adminImplementation.ViewSpecificApplications("rejected").AsEnumerable();

            return View(rejectedApps);
        }

       
        public ActionResult ApproveApplication(int id)
        {
            var approveApp = adminImplementation.ApproveCustomerApplication(id);
            if (approveApp == true)
            {
                return RedirectToAction("ViewApproved");
            }

            return View("ViewApproved");
        }
        
        public ActionResult RejectApplication(int id)
        {
            var rejectApp = adminImplementation.RejectCustomerApplication(id);
            if (rejectApp == true)
            {
                return RedirectToAction("ViewRejected");
            }

            return View("ViewRejected");
        }

        // GET: Admin/Dashboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAccountApplication customerAccountApplication = db.Customers.Find(id);
            if (customerAccountApplication == null)
            {
                return HttpNotFound();
            }
            return View(customerAccountApplication);
        }

        // GET: Admin/Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Dashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,customerName,phoneNumber,address,email,accountType,applicationStatus,password,confirmPassword")] CustomerAccountApplication customerAccountApplication)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customerAccountApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerAccountApplication);
        }

        // GET: Admin/Dashboard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAccountApplication customerAccountApplication = db.Customers.Find(id);
            if (customerAccountApplication == null)
            {
                return HttpNotFound();
            }
            return View(customerAccountApplication);
        }

        // POST: Admin/Dashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,customerName,phoneNumber,address,email,accountType,applicationStatus,password,confirmPassword")] CustomerAccountApplication customerAccountApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerAccountApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerAccountApplication);
        }

        // GET: Admin/Dashboard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAccountApplication customerAccountApplication = db.Customers.Find(id);
            if (customerAccountApplication == null)
            {
                return HttpNotFound();
            }
            return View(customerAccountApplication);
        }

        // POST: Admin/Dashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerAccountApplication customerAccountApplication = db.Customers.Find(id);
            db.Customers.Remove(customerAccountApplication);
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
