using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            
            return View(db.Insurees.ToList());
        }


        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(string firstName, string lastName, string emailAddress, DateTime dateofbirth, int caryear, string carmake, string carmodel, int speedingtickets, bool dui, bool coveragetype, int quote)

        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(carmake) || string.IsNullOrEmpty(carmodel))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (InsuranceEntities db = new InsuranceEntities())
                {
                    var signup = new Insuree();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;
                    signup.DateOfBirth = dateofbirth;
                    signup.CarYear = caryear;
                    signup.SpeedingTickets = speedingtickets;
                    signup.Dui = dui;
                    signup.CoverageType = coveragetype;
                    signup.Quote = quote;


                    quote = 50;
                    var today = DateTime.Today;
                    var age = today.Year - dateofbirth.Year;
                    if (dateofbirth > today.AddYears(-25))
                    {
                        quote = quote + 25;
                    }
                    else if (dateofbirth > today.AddYears(-18))
                    {
                        quote = quote + 100;

                    }
                    else if (dateofbirth > today.AddYears(-100))
                    {
                        quote = quote + 25;
                    }


                    if (caryear < 2000)
                    {
                        quote = quote + 25;
                    }
                    else if (caryear > 2015)
                    {
                        quote = quote + 25;
                    }

                    if (carmake == "Porsche")
                    {
                        quote = quote + 25;
                    }

                    if (carmake == "Porsche" && carmodel == "911 Carrera")
                    {
                        quote = quote + 25;
                    }

                    if (speedingtickets > 0)
                    {
                        quote = quote + (speedingtickets * 10);
                    }



                    if (dui)
                    {
                        quote = quote + (quote * 25 / 100);
                    }
                    else
                    {
                        quote = quote + 0;
                    }



                    if (coveragetype)
                    {
                        quote = quote + (quote * 50 / 100);
                    }
                    else
                    {
                        quote = quote + 0;
                    }


                    signup.Quote = quote;
                    db.Insurees.Add(signup);
                   
                    db.SaveChanges();

                    @ViewBag.Total = quote;



                    return View("Total");


                }




            }


        }


        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,Dui,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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
