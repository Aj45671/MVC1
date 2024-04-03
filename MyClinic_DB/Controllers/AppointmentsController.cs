using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClinic_DB.Models;

namespace MyClinic_DB.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private ClinicDB db = new ClinicDB();

        // GET: Appointments
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string searchBy, string searchValue)
        {
            if (searchBy == "PatientName")
            {
                return View(db.Appointments.Where(x => x.PatientName == searchValue || searchValue == null).ToList());
            }
            else
            {
                return View(db.Appointments.Where(x => x.Progress.StartsWith(searchValue) || searchValue == null).ToList());
            }
            
        }

        // GET: Appointments/Details/5
      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointId,DoctorId,PatientName,Date,Bill,Desease,Prescriptions,Progress")] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointments);
                db.SaveChanges();
                return RedirectToAction("Welcome");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", appointments.DoctorId);
            return View(appointments);
        }

        // GET: Appointments/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", appointments.DoctorId);
            return View(appointments);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "AppointId,DoctorId,PatientName,Date,Bill,Desease,Prescriptions,Progress")] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", appointments.DoctorId);
            return View(appointments);
        }

        // GET: Appointments/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointments appointments = db.Appointments.Find(id);
            db.Appointments.Remove(appointments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Welcome()
        {
            return View();
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
