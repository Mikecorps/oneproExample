using DAL_OneProEjemplo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioOneProEjem.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes+
        private oneproejercicioEntities db = new oneproejercicioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult entregas()
        {
            var entregas = from pedido in db.Pedido
                           join detalle in db.DetallePedido on pedido.idPedido equals detalle.idPedido
                           select new {name = pedido.Cliente, direccion = pedido.Cliente.Direccion,cantidad=detalle.cantidad,
                               descripcion=detalle.Articulo.descripcion, fabrica=pedido.Fabricas.nombre };
            ViewBag.data = entregas;
            return View(entregas);
        }
    }
}