﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult mantProveedor()
        {
            List<cListaProveedores> lista = null;
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                lista = (from pr in db.v_proveedores
                         select new cListaProveedores
                         {
                             id=pr.id,
                             nombre=pr.nombre,
                             telefono = pr.telefono,
                             tipot = pr.desc_tel,
                             correo = pr.correo,
                             tipoc = pr.desc_correos
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult agregarProveedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregarProveedor(cAgregarProveedor ap)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ap);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    db.sp_agregarproveedores(ap.nombre,ap.correo,ap.tipoc,ap.telefono,ap.tipot);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Proveedor agregado correctamente";
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
        public ActionResult actualizarproveedor(int id)
        {
            cActualizarProveedor ap = new cActualizarProveedor();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var aps = db.v_proveedores.FirstOrDefault(u => u.id == id);
                ap.id = aps.id;
                ap.nombre = aps.nombre;
                ap.correo=aps.correo;
                ap.telefono = aps.telefono;
                ap.tipot=aps.tipotel;
                ap.tipoc=aps.tipoc;
            }
            return View(ap);
        }
        [HttpPost]
        public ActionResult actualizarproveedor(cActualizarProveedor aps)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(aps);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    db.sp_actualizarproveedores(aps.id,aps.nombre,aps.correo,aps.tipoc,aps.telefono,aps.tipot);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Proveedor actualizado correctamente";
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
        public ActionResult consultarproveedor(int id)
        {
            cListaProveedores lista = new cListaProveedores();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var listas = db.v_proveedores.FirstOrDefault(u=>u.id==id);
                lista.id = listas.id;
                lista.nombre = listas.nombre;
                lista.correo = listas.correo;
                lista.tipoc = listas.desc_correos;
                lista.telefono = listas.telefono;
                lista.tipot = listas.desc_tel;
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult eliminarproveedor(int id)
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                db.sp_eliminarproveedor(id);
                db.SaveChanges();
            }
            return RedirectToAction("mantProveedor", "Proveedor");
        }
        [HttpGet]
        public ActionResult agregarpp(int id)
        {
            Asignarproducto ap = new Asignarproducto();
            using(BaseDatosEntities1 db= new BaseDatosEntities1())
            {
                var aps = db.proveedores.Find(id);
                ap.id = aps.id;
                ap.nombre = "";
            }
            return View(ap);
        }
        [HttpPost]
        public ActionResult agregarpp(Asignarproducto ap)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ap);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    db.sp_agregarproductoproveedor(ap.id, ap.nombre);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Producto asignado a proveedor exitosamente";
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
        public ActionResult consultarproductos(int id)
        {
            List<Productoproveedores> lista = null;
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                lista = (from p in db.v_prodprovee
                         where p.id == id
                         select new Productoproveedores
                         {
                             id=p.id,
                             nombre = p.nombre
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult eliminaraprodpr(int id, string ip)
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                db.sp_eliminarproductoproveedor(id,ip);
                db.SaveChanges();
            }
            return RedirectToAction("mantProveedor", "Proveedor");
        }
    }
}