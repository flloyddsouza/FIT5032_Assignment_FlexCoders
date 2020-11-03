using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlexCoders_Assignment.Models;
using FlexCoders_Assignment.Utils;
using Microsoft.AspNet.Identity;

namespace FlexCoders_Assignment.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Bookings
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // GET: Bookings/Create
       public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }

            ViewBag.workshopID = new SelectList(db.Workshops, "Id", "WorkshopName", id);
            ViewBag.dateAndTime = new SelectList(db.Workshops, "WorkshopDateTime", "WorkshopName", workshop.WorkshopDateTime);
            ViewBag.workshopName = new SelectList(db.Workshops, "WorkshopName", "WorkshopName", workshop.WorkshopName);
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,workshopID,dateAndTime,workshopName")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                bookings.userID = User.Identity.GetUserId();
                db.Bookings.Add(bookings);
                db.SaveChanges();

                try
                {
                    String toEmail = User.Identity.GetUserName();
                    String subject = "Registeration Confirmed";
                    String contents = "Hello, You have registered for the workshop " + bookings.workshopName + ". The time for the workshop is " + bookings.dateAndTime;


                    EmailSender es = new EmailSender();
                    es.Send("dsouzaflloyd.11@gmail.com",toEmail, subject, contents);
                }
                catch
                {

                }

                return RedirectToAction("Index");
            }

            ViewBag.workshopID = new SelectList(db.Workshops, "Id", "WorkshopName", bookings.workshopID);
            ViewBag.dateAndTime = new SelectList(db.Workshops, "WorkshopDateTime", "WorkshopName", bookings.dateAndTime);
            ViewBag.workshopName = new SelectList(db.Workshops, "WorkshopName", "WorkshopName", bookings.workshopName);
            return View(bookings);

        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,userID,workshopID,dateAndTime,workshopName")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookings);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookings bookings = db.Bookings.Find(id);
            db.Bookings.Remove(bookings);
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
