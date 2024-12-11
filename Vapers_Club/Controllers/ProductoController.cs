using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult mantProducto()
        {
            List<cListaProducto> lista = null;
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                lista = (from pr in db.v_productos
                         select new cListaProducto
                         {
                             id = pr.id,
                             nombre=pr.Nombre_Producto,
                             precio=pr.precio,
                             cantidad=pr.cantidad,
                             nombrem=pr.Nombre_Marca,
                             nombrec=pr.Nombre_Categ,
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult agregarProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregarProducto(cAgregarProducto ap)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ap);
                }

                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    // Usar una transacción explícita si es necesario
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.sp_agregarproducto(ap.nombre, ap.marca, ap.categ, ap.cantidad, ap.codigo, ap.unidadmedida, ap.vencimiento, ap.precio);
                            db.SaveChanges();  // Si no es necesario debido al procedimiento almacenado, puedes quitarlo
                            transaction.Commit(); // Confirmar la transacción
                            ViewBag.ValorMensaje = 1;
                            ViewBag.MensajeProceso = "Producto agregado correctamente";
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Revertir en caso de error
                            ViewBag.ValorMensaje = 0;
                            ViewBag.MensajeProceso = "Error al agregar el producto: " + ex.Message;
                        }
                    }
                }

                return View(ap);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error inesperado: " + ex.Message;
                return View(ap);
            }
        }

        [HttpGet]
        public ActionResult actualizarproducto(int id)
        {
            cActualizarProducto ap = new cActualizarProducto();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var aps = db.v_productos.FirstOrDefault(u=>u.id==id);
                ap.id = aps.id;
                ap.nombre=aps.Nombre_Producto;
                ap.marca=aps.Nombre_Marca;
                ap.categ = aps.Nombre_Categ;
                ap.cantidad = aps.cantidad;
                ap.precio = aps.precio;
            }
            return View(ap);
        }
        [HttpPost]
        public ActionResult actualizarproducto(cActualizarProducto aps)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(aps);
                }
                using (BaseDatosEntities1 db = new BaseDatosEntities1())
                {
                    db.sp_actualizarproducto(aps.id, aps.nombre, aps.marca, aps.categ, aps.cantidad, aps.codigo, aps.unidadmedida, aps.vencimiento, aps.precio);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Producto actualizado correctamente";
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
        public ActionResult consultarproducto(int id)
        {
            cListaProducto lista = new cListaProducto();
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var listas = db.v_productos.FirstOrDefault(u => u.id == id);
                lista.id = listas.id;
                lista.nombre = listas.Nombre_Producto;
                lista.nombrem=listas.Nombre_Marca;
                lista.nombrec = listas.Nombre_Categ;
                lista.cantidad = listas.cantidad;
                lista.precio = listas.precio;
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult consultarproveedores(int id)
        {
            List<Productoproveedores> lista = null;
            using(BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                lista = (from p in db.v_proveedoresprod
                         where p.id==id
                         select new Productoproveedores
                         {
                             nombre = p.nombre
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult eliminarproducto(int id)
        {
            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                db.sp_eliminarproducto(id);
                db.SaveChanges();
            }
            return RedirectToAction("mantProducto", "Producto");
        }
    }
}