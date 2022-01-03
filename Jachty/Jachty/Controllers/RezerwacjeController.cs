using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jachty;

namespace Jachty.Controllers
{
    public class RezerwacjeController : Controller
    {
        private SmagaEntities db = new SmagaEntities();

        // GET: Rezerwacje
        public ActionResult Index()
        {
            var Rezerwacje = db.Rezerwacje.Include(r => r.Dane_Klientow).Include(r => r.Jachty);
            return View(Rezerwacje.ToList());
        }

        // GET: Rezerwacje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacje rezerwacje = db.Rezerwacje.Find(id);
            if (rezerwacje == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacje);
        }

        // GET: Rezerwacje/Create
        public ActionResult Create()
        {
            ViewBag.id_klienta = new SelectList(db.Dane_Klientow, "id_klienta", "Imie");
            ViewBag.id_jachtu = new SelectList(db.Jachties, "id_jachtu", "Nazwa");
            return View();
        }

        // POST: Rezerwacje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rezerwacji,id_klienta,id_jachtu,Data_Poczatek,Data_Koniec,Cena_Total,Cena_Zaliczka")] Rezerwacje rezerwacje)
        {
            if (ModelState.IsValid)
            {
                db.Rezerwacje.Add(rezerwacje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_klienta = new SelectList(db.Dane_Klientow, "id_klienta", "Imie", rezerwacje.id_klienta);
            ViewBag.id_jachtu = new SelectList(db.Jachties, "id_jachtu", "Nazwa", rezerwacje.id_jachtu);
            return View(rezerwacje);
        }

        // GET: Rezerwacje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacje rezerwacje = db.Rezerwacje.Find(id);
            if (rezerwacje == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_klienta = new SelectList(db.Dane_Klientow, "id_klienta", "Imie", rezerwacje.id_klienta);
            ViewBag.id_jachtu = new SelectList(db.Jachties, "id_jachtu", "Nazwa", rezerwacje.id_jachtu);
            return View(rezerwacje);
        }

        // POST: Rezerwacje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rezerwacji,id_klienta,id_jachtu,Data_Poczatek,Data_Koniec,Cena_Total,Cena_Zaliczka")] Rezerwacje rezerwacje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezerwacje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_klienta = new SelectList(db.Dane_Klientow, "id_klienta", "Imie", rezerwacje.id_klienta);
            ViewBag.id_jachtu = new SelectList(db.Jachties, "id_jachtu", "Nazwa", rezerwacje.id_jachtu);
            return View(rezerwacje);
        }

        // GET: Rezerwacje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacje rezerwacje = db.Rezerwacje.Find(id);
            if (rezerwacje == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacje);
        }

        // POST: Rezerwacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezerwacje rezerwacje = db.Rezerwacje.Find(id);
            db.Rezerwacje.Remove(rezerwacje);
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
