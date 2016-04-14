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
    public class tblUploadedFiledetailsController : Controller
    {
        private dbAlergomurciaEntities db = new dbAlergomurciaEntities();

        // GET: tblUploadedFiledetails
        public ActionResult Index()
        {
            return Json(db.tblUploadedFiledetails.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: tblUploadedFiledetails/Details/5
        public ActionResult Details(int? id)
        {
            tblUploadedFiledetail tblUploadedFiledetail = db.tblUploadedFiledetails.Find(id);
            return Json(tblUploadedFiledetail, JsonRequestBehavior.AllowGet);
        }

        // GET: tblUploadedFiledetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblUploadedFiledetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fileID,filenameName,filePath,Createdby,CreatedDt,Updatedby,UpdatedDt,Active,seccion,title,category,idCategory")] tblUploadedFiledetail tblUploadedFiledetail)
        {
            if (ModelState.IsValid)
            {
                db.tblUploadedFiledetails.Add(tblUploadedFiledetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUploadedFiledetail);
        }

        // GET: tblUploadedFiledetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUploadedFiledetail tblUploadedFiledetail = db.tblUploadedFiledetails.Find(id);
            if (tblUploadedFiledetail == null)
            {
                return HttpNotFound();
            }
            return View(tblUploadedFiledetail);
        }

        // POST: tblUploadedFiledetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fileID,filenameName,filePath,Createdby,CreatedDt,Updatedby,UpdatedDt,Active,seccion,title,category,idCategory")] tblUploadedFiledetail tblUploadedFiledetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUploadedFiledetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUploadedFiledetail);
        }

        // GET: tblUploadedFiledetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUploadedFiledetail tblUploadedFiledetail = db.tblUploadedFiledetails.Find(id);
            if (tblUploadedFiledetail == null)
            {
                return HttpNotFound();
            }
            return View(tblUploadedFiledetail);
        }

        // POST: tblUploadedFiledetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUploadedFiledetail tblUploadedFiledetail = db.tblUploadedFiledetails.Find(id);
            db.tblUploadedFiledetails.Remove(tblUploadedFiledetail);
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
