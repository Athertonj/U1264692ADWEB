using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using U1264692.Dal;
using U1264692.Models;

namespace U1264692.Controllers
{
    public class RentalsController : Controller
    {
        private MovieRentalContext db = new MovieRentalContext();

        // GET: Rentals
        public ActionResult Index()
        {
            var rental = db.Rental.Include(r => r.customer).Include(r => r.Movies);
            return View(rental.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            ViewBag.customerID = new SelectList(db.customer, "customerID", "FirstName");
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "FilmTitle");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalID,MovieID,customerID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Rental.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.customer, "customerID", "FirstName", rental.customerID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "FilmTitle", rental.MovieID);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.customer, "customerID", "FirstName", rental.customerID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "FilmTitle", rental.MovieID);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalID,MovieID,customerID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.customer, "customerID", "FirstName", rental.customerID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "FilmTitle", rental.MovieID);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rental.Find(id);
            db.Rental.Remove(rental);
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
