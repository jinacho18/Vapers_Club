using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult mantCliente()
        {
            List<cListaCliente> lista = null;
            using(BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                lista = (from cl in db.v_clientes
                        select new cListaCliente
                        {
                            id = cl.id,
                            nombre = cl.nombre,
                            apellidos = cl.apellidos,
                            telefono = cl.telefono,
                            tipotel = cl.desc_tel,
                            correo = cl.correo,
                            tipoco = cl.desc_correos
                        }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult agregarCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregarCliente(cAgregarCliente ac)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ac);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    db.sp_agregarclientes(ac.nombre,ac.apellidos,ac.correo,ac.tipoc,ac.telefono,ac.tipot);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Cliente agregado correctamente";
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
        public ActionResult actualizarcliente(int id)
        {
            cActualizarCliente ac= new cActualizarCliente();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var acs = db.v_clientes.FirstOrDefault(u => u.id == id);
                ac.id=acs.id;
                ac.nombre=acs.nombre;
                ac.apellidos=acs.apellidos;
                ac.telefono=acs.telefono;
                ac.tipot=acs.tipotel;
                ac.correo = acs.correo;
                ac.tipoc = acs.tipoc;
            }
            return View(ac);
        }
        [HttpPost]
        public ActionResult actualizarcliente(cActualizarCliente acs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(acs);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    db.sp_actualizarcliente(acs.id,acs.nombre,acs.apellidos,acs.correo,acs.tipoc,acs.telefono,acs.tipot);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Cliente actualizado correctamente";
                }
                return View(acs);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar " + ex;
                return View(acs);
            }
        }
        [HttpGet]
        public ActionResult consultarcliente(int id)
        {
            cListaCliente lista = new cListaCliente();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var listas = db.v_clientes.FirstOrDefault(u=>u.id==id);
                lista.id = listas.id;
                lista.nombre = listas.nombre;
                lista.apellidos = listas.apellidos;
                lista.correo = listas.correo;
                lista.tipoco = listas.desc_correos;
                lista.telefono = listas.telefono;
                lista.tipotel = listas.desc_tel;
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult eliminarcliente(int id)
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                db.sp_eliminarcliente(id);
                db.SaveChanges();
            }
            return RedirectToAction("mantCliente", "Cliente");
        }
    }
}