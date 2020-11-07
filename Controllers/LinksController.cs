using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlexCoders_Assignment.Models;
/*
 *  Author Flloyd Dsouza
 *  This controller manages the Links of Courses
 */



namespace FlexCoders_Assignment.Controllers
{
    [Authorize]
    public class LinksController : Controller
    {

        private Model1Container db = new Model1Container();


        // GET: Links/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(int? id)
        {
            Course data = TempData["mydata"] as Course;
            int courseId;
         
            if(data != null)
            {
                courseId = data.Id;
            } else if (id != null)
            {
                courseId = (int)id;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
    
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", courseId);
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,Name,LinkURL,CourseId")] Links links)
        {
            if (ModelState.IsValid)
            {
                db.Links.Add(links);
                db.SaveChanges();
                ModelState.Clear();
                //return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", links.CourseId);
            return View();
        }


        // GET: Links/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", links.CourseId);
            return View(links);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,LinkURL,CourseId")] Links links, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(links).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);

            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", links.CourseId);
            return View(links);
        }

        // GET: Links/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(links);
        }

        // POST: Links/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            Links links = db.Links.Find(id);
            db.Links.Remove(links);
            db.SaveChanges();
            return Redirect(returnUrl);
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
