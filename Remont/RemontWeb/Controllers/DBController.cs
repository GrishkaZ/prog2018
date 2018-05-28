using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RemontWeb.Models;

namespace RemontWeb.Controllers
{
    public class DBController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DB
        public ActionResult Index()
        {
            return View(db.RemontModels.ToList());
        }

        // GET: DB/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRemontModel dbRemontModels = db.RemontModels.Find(id);
            if (dbRemontModels == null)
            {
                return HttpNotFound();
            }
            return View(dbRemontModels);
        }*/

        // GET: DB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Days,Filled,FullName,Price,Currency,BrokenDevice,BuySomeDetailsYourself,AdditionalRequests")] DBRemontModel dbRemontModels)
        {
            if (ModelState.IsValid)
            {
                db.RemontModels.Add(dbRemontModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbRemontModels);
        }

        // GET: DB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRemontModel dbRemontModels = db.RemontModels.Find(id);
            if (dbRemontModels == null)
            {
                return HttpNotFound();
            }
            return View(dbRemontModels);
        }

        // POST: DB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Days,Filled,FullName,Price,Currency,BrokenDevice,BuySomeDetailsYourself,AdditionalRequests")] DBRemontModel dbRemontModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbRemontModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbRemontModels);
        }

        // GET: DB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRemontModel dbRemontModel = db.RemontModels.Find(id);
            if (dbRemontModel == null)
            {
                return HttpNotFound();
            }
            return View(dbRemontModel);
        }

        /*// POST: DB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBRemontModel dbRemontModels = db.RemontModels.Find(id);
            //dbRemontModels.Breakages.Clear();
            db.RemontModels.Remove(dbRemontModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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
