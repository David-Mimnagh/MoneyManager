using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoneyManager.DAL;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class QuickPurchasesController : Controller
    {
        private QuickPurchaseContext db = new QuickPurchaseContext();

        // GET: QuickPurchases
        public ActionResult Index()
        {
            return View(db.QuickPurchases.ToList());
        }

        // GET: QuickPurchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickPurchase quickPurchase = db.QuickPurchases.Find(id);
            if (quickPurchase == null)
            {
                return HttpNotFound();
            }
            return View(quickPurchase);
        }

        // GET: QuickPurchases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuickPurchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuickPurchaseName,QuickPurchaseDate,QuickPurchaseAmount,QuickPurchaseOrigin,QuickPurchaseReason")] QuickPurchase quickPurchase)
        {
            if (ModelState.IsValid)
            {
                db.QuickPurchases.Add(quickPurchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quickPurchase);
        }

        // GET: QuickPurchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickPurchase quickPurchase = db.QuickPurchases.Find(id);
            if (quickPurchase == null)
            {
                return HttpNotFound();
            }
            return View(quickPurchase);
        }

        // POST: QuickPurchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QuickPurchaseName,QuickPurchaseDate,QuickPurchaseAmount,QuickPurchaseOrigin,QuickPurchaseReason")] QuickPurchase quickPurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quickPurchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quickPurchase);
        }

        // GET: QuickPurchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickPurchase quickPurchase = db.QuickPurchases.Find(id);
            if (quickPurchase == null)
            {
                return HttpNotFound();
            }
            return View(quickPurchase);
        }

        // POST: QuickPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuickPurchase quickPurchase = db.QuickPurchases.Find(id);
            db.QuickPurchases.Remove(quickPurchase);
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
