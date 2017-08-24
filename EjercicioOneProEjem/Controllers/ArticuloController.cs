using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_OneProEjemplo;
using System.Data.Entity;
using System.Net;

namespace EjercicioOneProEjem.Controllers
{
    public class ArticuloController : Controller
    {
        private oneproejercicioEntities db = new oneproejercicioEntities();
        // GET: Articulo
        public ActionResult Index()
        {
            return View(db.Articulo.ToList());
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int? id)
        {
            Articulo articulo = db.Articulo.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            else return View(articulo);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            ViewBag.idFabrica = new SelectList( db.Fabricas.ToList(),"idFabrica", "nombre");
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArticulo,existencia,descripcion,costo,precioUnitario,idFabrica")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                db.Articulo.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                Articulo articulo = db.Articulo.Find(id);
                ViewBag.idFabrica = new SelectList(db.Fabricas.ToList(),"idFabrica", "nombre",articulo.idFabrica);
                return View(articulo);
            }
          
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "idArticulo,existencia,descripcion,costo,precioUnitario,idFabrica")] Articulo articulo)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add update logic here
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                Articulo art = db.Articulo.Find(id);
                return View(art);
            }
        }

        // POST: Articulo/Delete/5
       
       
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Articulo articulo = db.Articulo.Find(id);
                db.Articulo.Remove(articulo);
                db.SaveChanges();
                return Json(new { success = true, responseText = "Se borro corectamente" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { succes = false });
            }
        }
    }
}
