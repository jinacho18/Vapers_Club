﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult mantCateg()
        {
            List<cListaCateg> lista = null;
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                lista = (from ca in db.categorias
                         select new cListaCateg
                         {
                             id = ca.id,
                             nombre = ca.nombre
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult agregarCateg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregarCateg(cAgregarCateg ac)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ac);
                }
                using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
                {
                    categorias ca = new categorias();
                    ca.nombre = ac.nombre;
                    db.categorias.Add(ca);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Categoria agregada correctamente";
                }
                return View(ac);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar " + ex;
                return View(ac);
            }
        }
        [HttpGet]
        public ActionResult actualizarcateg(int id)
        {
            cActualizarCateg ca = new cActualizarCateg();
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var cas = db.categorias.Find(id);
                ca.id = cas.id;
                ca.nombre = cas.nombre;
            }
            return View(ca);
        }
        [HttpPost]
        public ActionResult actualizarcateg(cActualizarCateg cas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(cas);
                }
                using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
                {
                    var ca = db.categorias.Find(cas.id);
                    ca.id = cas.id;
                    ca.nombre = cas.nombre;
                    db.Entry(ca).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Categoria actualizado correctamente";
                }
                return View(cas);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar " + ex;
                return View(cas);
            }
        }
        [HttpGet]
        public ActionResult consultarcateg(int id)
        {
            cListaCateg lista = new cListaCateg();
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var listas = db.categorias.Find(id);
                lista.id = listas.id;
                lista.nombre = listas.nombre;
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult eliminarcateg(int id)
        {
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                var categs = db.categorias.Find(id);
                db.categorias.Remove(categs);
                db.SaveChanges();
            }
            return RedirectToAction("mantCateg", "Categoria");
        }
    }
}