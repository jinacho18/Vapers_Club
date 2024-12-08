using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class AlmacenController : Controller
    {
        public ActionResult Index()
        {
            List<cListaAlmacenes> lista = null;
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                lista = (from pr in db.almacenes
                         select new cListaAlmacenes
                         {
                             id = pr.id,
                             nombre = pr.nombre
                         }).ToList();
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(cAgregarAlmacen ap)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ap);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    almacene al = new almacene();
                    al.nombre = ap.nombre;
                    al.direccion = ap.direccion;
                    db.almacenes.Add(al);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Almacén agregado correctamente";
                }
                return View(ap);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar " + ex;
                return View(ap);
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            cEditAlmacen ap = new cEditAlmacen();
            using (BaseDatosEntities1 db = new BaseDatosEntities1()) 
            {
                var aps = db.almacenes.Find(id);
                ap.Id = aps.id;
                ap.nombre = aps.nombre;
                ap.direccion = aps.direccion;
            }
            return View(ap);
        }

        [HttpPost]
        public ActionResult Update(cEditAlmacen aps)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(aps);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1()) 
                {
                    var ap = db.almacenes.Find(aps.Id);
                    ap.id = aps.Id;
                    ap.nombre = aps.nombre;
                    ap.direccion = aps.direccion;
                    db.Entry(ap).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Almacén actualizado correctamente";
                }
                return View(aps);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar " + ex;
                return View(aps);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            cAlmacen lista = new cAlmacen();
            using (BaseDatosEntities1 db = new BaseDatosEntities1()) 
            {
                var listas = db.almacenes.Find(id);
                lista.Id = listas.id;
                lista.nombre = listas.nombre;
                lista.direccion = listas.direccion;
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1()) 
            {
                var productos = db.v_almaprod.FirstOrDefault(u => u.idalmacen == id);
                if (productos != null)
                {
                    db.sp_eliminarmacenprod(id);
                    db.almacenes.Find(id);
                    db.SaveChanges();
                }
                else
                {
                    db.almacenes.Find(id);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Almacen");
        }

        [HttpGet]
        public ActionResult agregarpa(int id)
        {
            asignaralmacen ap = new asignaralmacen();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var aps = db.almacenes.Find(id);
                ap.idalmacen = aps.id;
                ap.producto = "";
            }
            return View(ap);
        }

        [HttpPost]
        public ActionResult agregarpa(asignaralmacen ap)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ap);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1()) 
                {
                    db.sp_agregaralmacenprod(ap.producto, ap.idalmacen);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Producto asignado a almacén exitosamente";
                }
                return View(ap);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar " + ex;
                return View(ap);
            }
        }

        [HttpGet]
        public ActionResult consultarprodal(int id)
        {
            List<asignaralmacen> lista = null;
            using (BaseDatosEntities1 db = new BaseDatosEntities1()) // Cambiado el contexto
            {
                lista = (from p in db.v_almaprod
                         where p.idalmacen == id
                         select new asignaralmacen
                         {
                             idalmacen = p.idalmacen,
                             producto = p.nombre
                         }).ToList();
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult eliminaraprodal(int id, string prod)
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1()) // Cambiado el contexto
            {
                db.sp_eliminarmacenprod2(id, prod);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Almacen");
        }
    }
}