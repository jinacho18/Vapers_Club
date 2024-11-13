using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class EntregaController : Controller
    {
        // GET: Entregas
        public ActionResult mantEntrega()
        {
            List<cListaEntrega> lista = null;
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                lista = (from en in db.v_entregas
                         select new cListaEntrega
                         {
                             id = en.id,
                             fecha=en.fecha_pedido,
                             prodnomb=en.nombre,
                             estado=en.desc_estado,
                             cantidad=en.cantidad
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult agregarEntrega()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregarEntrega(cAgregarEntrega ae)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ae);
                }
                using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
                {
                    db.sp_agregarentrega(ae.fecha, ae.idp, ae.cantidad, 1);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Entrega agregada correctamente";
                }
                return View(ae);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar " + ex;
                return View(ae);
            }
        }
        [HttpGet]
        public ActionResult actualizarentrega(int id)
        {
            cActualizarEntrega ae = new cActualizarEntrega();
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var aes = db.v_entregas.FirstOrDefault(u => u.id == id);
                ae.id = aes.id;
                ae.fecha=aes.fecha_pedido;
                ae.idp = aes.nombre;
                ae.cantidad = aes.cantidad;
                ae.estado = aes.estado;
            }
            return View(ae);
        }
        [HttpPost]
        public ActionResult actualizarentrega(cActualizarEntrega aes)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(aes);
                }
                using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
                {
                    db.sp_actualizarentrega(aes.id, aes.fecha, aes.idp, aes.cantidad, aes.estado);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Entrega actualizada correctamente";
                }
                return View(aes);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar " + ex;
                return View(aes);
            }
        }
        [HttpGet]
        public ActionResult consultarentrega(int id)
        {
            cListaEntrega lista = new cListaEntrega();
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var listas = db.v_entregas.FirstOrDefault(u=>u.id==id);
                lista.id = listas.id;
                lista.fecha=listas.fecha_pedido;
                lista.prodnomb = listas.nombre;
                lista.estado = listas.desc_estado;
                lista.cantidad = listas.cantidad;
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult eliminarentrega(int id)
        {
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var entregas = db.entregas.Find(id);
                db.entregas.Remove(entregas);
                db.SaveChanges();
            }
            return RedirectToAction("mantEntrega", "Entrega");
        }
    }
}