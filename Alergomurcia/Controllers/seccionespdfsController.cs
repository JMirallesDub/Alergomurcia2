using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alergomurcia.Models;

namespace Alergomurcia.Controllers
{
    public class seccionespdfsController : Controller
    {
        private dbAlergomurciaEntities db = new dbAlergomurciaEntities();

        // GET: seccionespdfs
        public ActionResult Index()
        {
            return Json(db.seccionespdfs.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: seccionespdfs/Details/5
        public ActionResult Details(int? id)
        {
            seccionespdf seccionespdf = db.seccionespdfs.Find(id);
            return Json(seccionespdf, JsonRequestBehavior.AllowGet);
        }

        // GET: seccionespdfs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: seccionespdfs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,seccion")] seccionespdf seccionespdf)
        {
            if (ModelState.IsValid)
            {
                db.seccionespdfs.Add(seccionespdf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seccionespdf);
        }

        // GET: seccionespdfs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seccionespdf seccionespdf = db.seccionespdfs.Find(id);
            if (seccionespdf == null)
            {
                return HttpNotFound();
            }
            return View(seccionespdf);
        }

        // POST: seccionespdfs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,seccion")] seccionespdf seccionespdf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seccionespdf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seccionespdf);
        }

        // GET: seccionespdfs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seccionespdf seccionespdf = db.seccionespdfs.Find(id);
            if (seccionespdf == null)
            {
                return HttpNotFound();
            }
            return View(seccionespdf);
        }

        // POST: seccionespdfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            seccionespdf seccionespdf = db.seccionespdfs.Find(id);
            db.seccionespdfs.Remove(seccionespdf);
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
