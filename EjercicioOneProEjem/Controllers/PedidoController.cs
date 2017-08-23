using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_OneProEjemplo;
using System.Net;
using System.Data.Entity;

namespace EjercicioOneProEjem.Controllers
{
    public class PedidoController : Controller
    {
        //objeto del mapeo de la BD.
        private oneproejercicioEntities db = new oneproejercicioEntities();

        // GET: Pedido
        public ActionResult Index()
        {
            return View(db.Pedido.ToList());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Cliente.ToList(), "idCliente", "nombre");
            ViewBag.idFabrica = new SelectList(db.Fabricas.ToList(), "idFabrica", "nombre");
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedido,idCliente,fechaTime,idFabrica")] Pedido pedido)
        {

            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedido);

        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ObtenerItemEditCliente(pedido.idCliente);
            ObtenerItemEditFabrica(pedido.idFabrica);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedido, idCliente, fechaTime, idFabrica")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private void ObtenerItemEditCliente(object selectPedido = null)
        {
            var pedidoFabQuery = from d in db.Cliente
                                   orderby d.nombre
                                   select d;
            ViewBag.idCliente = new SelectList(pedidoFabQuery, "idCliente", "nombre",selectPedido);
        }

        private void ObtenerItemEditFabrica(object selectPedido = null)
        {
            var pedidoFabQuery = from d in db.Fabricas
                                 orderby d.nombre
                                 select d;
            ViewBag.idFabrica = new SelectList(pedidoFabQuery, "idFabrica", "nombre", selectPedido);
        }

    }
}
