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
    public class reunionesController : Controller
    {
        private dbAlergomurciaEntities db = new dbAlergomurciaEntities();

        // GET: reuniones
        public ActionResult Index()
        {
            return Json(db.reuniones.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: reuniones/Details/5
        public ActionResult Details(int? id)
        {
            reunione reunione = db.reuniones.Find(id);
            return Json(reunione, JsonRequestBehavior.AllowGet);
        }

        // GET: reuniones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reuniones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,titulo,lugar,resumen,detalle,enlaces,documento")] reunione reunione)
        {
            if (ModelState.IsValid)
            {
                db.reuniones.Add(reunione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reunione);
        }

        // GET: reuniones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reunione reunione = db.reuniones.Find(id);
            if (reunione == null)
            {
                return HttpNotFound();
            }
            return View(reunione);
        }

        // POST: reuniones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,titulo,lugar,resumen,detalle,enlaces,documento")] reunione reunione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reunione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reunione);
        }

        // GET: reuniones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reunione reunione = db.reuniones.Find(id);
            if (reunione == null)
            {
                return HttpNotFound();
            }
            return View(reunione);
        }

        // POST: reuniones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reunione reunione = db.reuniones.Find(id);
            db.reuniones.Remove(reunione);
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
