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
    public class FabricasController : Controller
    {
        private oneproejercicioEntities db = new oneproejercicioEntities();

        // GET: Fabricas
        public ActionResult Index()
        {
            return View(db.Fabricas.ToList());
        }

        // GET: Fabricas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricas fabricas = db.Fabricas.Find(id);
            if (fabricas == null)
            {
                return HttpNotFound();
            }
            return View(fabricas);
        }

        // GET: Fabricas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabricas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFabrica,nombre,descripcion,telefono")] Fabricas fabricas)
        {
            if (ModelState.IsValid)
            {
                db.Fabricas.Add(fabricas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabricas);
        }

        // GET: Fabricas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricas fabricas = db.Fabricas.Find(id);
            if (fabricas == null)
            {
                return HttpNotFound();
            }
            return View(fabricas);
        }

        // POST: Fabricas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFabrica,nombre,descripcion,telefono")] Fabricas fabricas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricas);
        }

        // GET: Fabricas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricas fabricas = db.Fabricas.Find(id);
            if (fabricas == null)
            {
                return HttpNotFound();
            }
            return View(fabricas);
        }

        // POST: Fabricas/Delete/5
       
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Fabricas fabricas = db.Fabricas.Find(id);
                foreach (var pedido in db.Pedido.Where(p => p.idFabrica == id))
                    db.Pedido.Remove(pedido);
                foreach (var articulo in db.Articulo.Where(a => a.idFabrica == id).ToList())
                    db.Articulo.Remove(articulo);
                db.Fabricas.Remove(fabricas);
                db.SaveChanges();
                return Json(new { success = true, responseText = "Se borro corectamente" }, JsonRequestBehavior.AllowGet);
        }
            catch {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { succes = false });
            }
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
