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
    public class UsersController : Controller
    {
        private dbAlergomurciaEntities db = new dbAlergomurciaEntities();

        // GET: Users
        public ActionResult Index()
        {
            return Json(db.Users.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            User user = db.Users.Find(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,usuario,password,login,articulos_insertar,articulos_editar,articulos_eliminar,reuniones_insertar,reuniones_editar,reuniones_eliminar,noticias_insertar,noticias_editar,noticias_eliminar,usuarios_activar,usuarios_permisos,activo,subir_ficheros,apellidos,dni,fecha_nacimiento,direccion_particular,localidad,provincia,codigo_postal,email,telefono_movil,telefono_fijo,puesto_trabajo,centro_trabajo,direccion_trabajo,localidad_trabajo,provincia_trabajo,codigo_postal_trabajo,telefono_trabajo,nombre1_aval,email1_aval,nombre2_aval,email2_aval,banco,direccion_banco,localidad_banco,titular,codigo_entidad,codigo_sucursal,codigo_control,codigo_cuenta,alta")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,usuario,password,login,articulos_insertar,articulos_editar,articulos_eliminar,reuniones_insertar,reuniones_editar,reuniones_eliminar,noticias_insertar,noticias_editar,noticias_eliminar,usuarios_activar,usuarios_permisos,activo,subir_ficheros,apellidos,dni,fecha_nacimiento,direccion_particular,localidad,provincia,codigo_postal,email,telefono_movil,telefono_fijo,puesto_trabajo,centro_trabajo,direccion_trabajo,localidad_trabajo,provincia_trabajo,codigo_postal_trabajo,telefono_trabajo,nombre1_aval,email1_aval,nombre2_aval,email2_aval,banco,direccion_banco,localidad_banco,titular,codigo_entidad,codigo_sucursal,codigo_control,codigo_cuenta,alta")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
