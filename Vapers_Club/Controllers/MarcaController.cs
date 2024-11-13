using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models.ViewModels;
using Vapers_Club.Models;

namespace Vapers_Club.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult mantMarca()
        {
            List<cListaMarca> lista = null;
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                lista = (from ma in db.marcas
                         select new cListaMarca
                         {
                             id=ma.id,
                             nombre=ma.nombre
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult agregarMarca()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregarMarca(cAgregarMarca am)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(am);
                }
                using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
                {
                    marcas ma = new marcas();
                    ma.nombre = am.nombre;
                    db.marcas.Add(ma);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Marca agregada correctamente";
                }
                return View(am);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar " + ex;
                return View(am);
            }
        }
        [HttpGet]
        public ActionResult actualizarmarca(int id)
        {
            cActualizarMarca am = new cActualizarMarca();
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var ams = db.marcas.Find(id);
                am.id = ams.id;
                am.nombre = ams.nombre;
            }
            return View(am);
        }
        [HttpPost]
        public ActionResult actualizarmarca(cActualizarMarca ams)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ams);
                }
                using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
                {
                    var am = db.marcas.Find(ams.id);
                    am.id = ams.id;
                    am.nombre = ams.nombre;
                    db.Entry(am).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Marca actualizada correctamente";
                }
                return View(ams);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar " + ex;
                return View(ams);
            }
        }
        [HttpGet]
        public ActionResult consultarmarca(int id)
        {
            cListaMarca lista = new cListaMarca();
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var listas = db.marcas.Find(id);
                lista.id = listas.id;
                lista.nombre = listas.nombre;
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult eliminarmarca(int id)
        {
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var marcas = db.marcas.Find(id);
                db.marcas.Remove(marcas);
                db.SaveChanges();
            }
            return RedirectToAction("mantMarca", "Marca");
        }
    }
}