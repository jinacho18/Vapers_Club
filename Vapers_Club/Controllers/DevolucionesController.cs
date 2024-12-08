using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models; 
using Vapers_Club.Models.ViewModels; 

namespace Vapers_Club.Controllers 
{
    public class DevolucionesController : Controller
    {
        // GET: Devoluciones
        public ActionResult Index()
        {
            List<cListaDevolucion> lista = null;
            using (BaseDatosEntities1 db = new BaseDatosEntities1()) 
            {
                lista = (from dv in db.v_devolucion
                         select new cListaDevolucion
                         {
                             id = dv.id,
                             idc = dv.cliente ?? 0,
                             idp = dv.proveedor ?? 0,
                             ncliente = dv.nombre,
                             apellidos = dv.apellidos,
                             nproveedor = dv.nprove,
                             razon = dv.razon
                         }).ToList();
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult CreateCliente()
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var clientes = db.clientes
                    .Select(a => new SelectListItem
                    {
                        Value = a.id.ToString(),
                        Text = a.id + " - " + a.nombre + " - " + a.apellidos
                    }).ToList();

                ViewBag.Clientes = clientes;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateCliente(cCreateDevolucion cd)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    using (BaseDatosEntities1 db = new BaseDatosEntities1())
                    {
                        var clientes = db.clientes
                            .Select(a => new SelectListItem
                            {
                                Value = a.id.ToString(),
                                Text = a.id + " - " + a.nombre + " - " + a.apellidos
                            }).ToList();

                        ViewBag.Clientes = clientes;
                    }
                    return View(cd);
                }

                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    devolucione dv = new devolucione();
                    dv.cliente = cd.cliente;
                    dv.proveedor = null;
                    dv.razon = cd.razon;
                    db.devoluciones.Add(dv);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Devolución agregada correctamente";
                    return RedirectToAction("Index", "Devoluciones");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar " + ex;
                return View(cd);
            }
        }

        [HttpGet]
        public ActionResult CreateProveedor()
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var proveedores = db.proveedores
                    .Select(a => new SelectListItem
                    {
                        Value = a.id.ToString(),
                        Text = a.id + " - " + a.nombre
                    }).ToList();

                ViewBag.Proveedores = proveedores;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateProveedor(cCreateDevolucion cd)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    using (BaseDatosEntities1 db = new BaseDatosEntities1())
                    {
                        var proveedores = db.proveedores
                            .Select(a => new SelectListItem
                            {
                                Value = a.id.ToString(),
                                Text = a.id + " - " + a.nombre
                            }).ToList();

                        ViewBag.Proveedores = proveedores;
                    }
                    return View(cd);
                }

                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    devolucione dv = new devolucione();
                    dv.cliente = null;
                    dv.proveedor = cd.proveedor;
                    dv.razon = cd.razon;
                    db.devoluciones.Add(dv);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Devolución agregada correctamente";
                    return RedirectToAction("Index", "Devoluciones");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar " + ex;
                return View(cd);
            }
        }

        [HttpGet]
        public ActionResult EditCliente(int id)
        {
            cEditDevolucion ed = new cEditDevolucion();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var clientes = db.clientes
                    .Select(a => new SelectListItem
                    {
                        Value = a.id.ToString(),
                        Text = a.id + " - " + a.nombre + " - " + a.apellidos
                    }).ToList();

                ViewBag.Clientes = clientes;
                var eds = db.devoluciones.Find(id);
                ed.id = eds.id;
                ed.cliente = eds.cliente.Value;
                ed.proveedor = 0;
                ed.razon = eds.razon;
            }
            return View(ed);
        }

        public ActionResult EditProveedor(int id)
        {
            cEditDevolucion ed = new cEditDevolucion();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var proveedores = db.proveedores
                    .Select(a => new SelectListItem
                    {
                        Value = a.id.ToString(),
                        Text = a.id + " - " + a.nombre
                    }).ToList();

                ViewBag.Proveedores = proveedores;
                var eds = db.devoluciones.Find(id);
                ed.id = eds.id;
                ed.cliente = 0;
                ed.proveedor = eds.proveedor.Value;
                ed.razon = eds.razon;
            }
            return View(ed);
        }
        [HttpPost]
        public ActionResult EditCliente(cEditDevolucion ed)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    using (BaseDatosEntities1 db = new BaseDatosEntities1())
                    {
                        var clientes = db.clientes
                            .Select(a => new SelectListItem
                            {
                                Value = a.id.ToString(),
                                Text = a.id + " - " + a.nombre + " - " + a.apellidos
                            }).ToList();

                        ViewBag.Clientes = clientes;
                    }
                    return View(ed);
                }

                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    var edv = db.devoluciones.Find(ed.id);
                    edv.id = ed.id;
                    edv.cliente = ed.cliente;
                    edv.proveedor = null;
                    edv.razon = ed.razon;
                    db.Entry(edv).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Devolución actualizada correctamente";
                    return RedirectToAction("Index", "Devoluciones");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar " + ex;
                return View(ed);
            }
        }

        public ActionResult EditProveedor(cEditDevolucion ed)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    using (BaseDatosEntities1 db = new BaseDatosEntities1())
                    {
                        var proveedores = db.proveedores
                            .Select(a => new SelectListItem
                            {
                                Value = a.id.ToString(),
                                Text = a.id + " - " + a.nombre
                            }).ToList();

                        ViewBag.Proveedores = proveedores;
                    }
                    return View(ed); // Esto ya es el retorno en caso de error de validación
                }

                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    var edv = db.devoluciones.Find(ed.id);
                    edv.id = ed.id;
                    edv.cliente = null;
                    edv.proveedor = ed.proveedor;
                    edv.razon = ed.razon;
                    db.Entry(edv).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Devolución actualizada correctamente";
                    return RedirectToAction("Index", "Devoluciones");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar " + ex;
                return View(ed);
            }
        }

        [HttpGet]
        public ActionResult DetailsCliente(int id)
        {
            cDevolucion lista = new cDevolucion();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var listas = db.v_devolucion.FirstOrDefault(u => u.id == id);
                lista.id = listas.id;
                lista.cliente = listas.cliente.Value;
                lista.ncliente = listas.nombre;
                lista.apellidos = listas.apellidos;
                lista.razon = listas.razon;
                lista.proveedor = 0;
                lista.nproveedor = "No aplica";
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult DetailsProveedor(int id)
        {
            cDevolucion lista = new cDevolucion();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var listas = db.v_devolucion.FirstOrDefault(u => u.id == id);
                lista.id = listas.id;
                lista.cliente = 0;
                lista.ncliente = "No aplica";
                lista.apellidos = "No aplica";
                lista.razon = listas.razon;
                lista.proveedor = listas.proveedor.Value;
                lista.nproveedor = listas.nprove;
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var dev = db.devoluciones.Find(id);
                db.devoluciones.Remove(dev);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Devoluciones");
        }
    }
}