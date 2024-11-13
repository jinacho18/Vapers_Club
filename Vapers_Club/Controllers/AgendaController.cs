using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        public ActionResult mantAgenda()
        {
            List<cListaAgenda> lista = null;
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                lista = (from ag in db.agendas
                         select new cListaAgenda
                         {
                             id = ag.id_evento,
                             fecha = ag.fecha,
                             detalle = ag.detalle
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult agregarEvento()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregarEvento(cAgregarEvento ae)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ae);
                }
                using(ProyectoBBD2Entities db= new ProyectoBBD2Entities())
                {
                    agendas ag = new agendas();
                    ag.fecha = ae.fecha;
                    ag.detalle = ae.detalle;
                    db.agendas.Add(ag);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Evento agregado correctamente";
                }
                return View(ae);
            }catch(Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar " + ex;
                return View(ae);
            }
        }
        [HttpGet]
        public ActionResult actualizarenvento(int id)
        {
            cActualizarEvento ae = new cActualizarEvento();
            using(ProyectoBBD2Entities db= new ProyectoBBD2Entities())
            {
                var aes = db.agendas.Find(id);
                ae.id = aes.id_evento;
                ae.fecha = aes.fecha;
                ae.detalle = aes.detalle;
            }
            return View(ae);
        }
        [HttpPost]
        public ActionResult actualizarenvento(cActualizarEvento aes)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(aes);
                }
                using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
                {
                    var ae = db.agendas.Find(aes.id);
                    ae.id_evento = aes.id;
                    ae.fecha = aes.fecha;
                    ae.detalle = aes.detalle;
                    db.Entry(ae).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Evento actualizado correctamente";
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
        public ActionResult consultarevento(int id)
        {
            cListaAgenda lista = new cListaAgenda();
            using(ProyectoBBD2Entities db= new ProyectoBBD2Entities())
            {
                var listas = db.agendas.Find(id);
                lista.id = listas.id_evento;
                lista.fecha = listas.fecha;
                lista.detalle = listas.detalle;
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult eliminarevento(int id)
        {
            using(ProyectoBBD2Entities db= new ProyectoBBD2Entities())
            {
                var agends = db.agendas.Find(id);
                db.agendas.Remove(agends);
                db.SaveChanges();
            }
            return RedirectToAction("mantagenda", "Agenda");
        }
    }
}