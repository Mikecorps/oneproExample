using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL_OneProEjemplo;

namespace EjercicioOneProEjem.Controllers
{
    public class distribuidorsController : Controller
    {
        private oneproejercicioEntities db = new oneproejercicioEntities();

        // GET: distribuidors
        public ActionResult Index()
        {
            return View(db.distribuidor.ToList());
        }

        // GET: distribuidors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distribuidor distribuidor = db.distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // GET: distribuidors/Create
        public ActionResult Create()
        {
            ViewBag.idFabrica = new SelectList(db.Fabricas.ToList(), "idFabrica", "nombre");
            
            return View();
        }

        // POST: distribuidors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idFabrica,nombreDistribuidor,apellidoPaterno,apellidoMaterno,telefono,email")] distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                db.distribuidor.Add(distribuidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distribuidor);
        }

        // GET: distribuidors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distribuidor distribuidor = db.distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // POST: distribuidors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idFabrica,nombreDistribuidor,apellidoPaterno,apellidoMaterno,telefono,email")] distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distribuidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distribuidor);
        }

        // GET: distribuidors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distribuidor distribuidor = db.distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // POST: distribuidors/Delete/5
       
        public ActionResult DeleteConfirmed(int id)
        {
            distribuidor distribuidor = db.distribuidor.Find(id);
            db.distribuidor.Remove(distribuidor);
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
