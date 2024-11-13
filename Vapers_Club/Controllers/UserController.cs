using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult mantUser()
        {
            List<cListaUser> lista = null;
            using (ProyectoBBD2Entities db = new ProyectoBBD2Entities())
            {
                lista = (from user in db.v_usuarios
                         select new cListaUser
                         {
                             id = user.id,
                             cedula = user.cedula,
                             rol = user.desc_rol
                         }).ToList();
            }
            return View(lista);
        }
        [HttpGet]
        public ActionResult agregaruser()
        {
            return View();
        }
        public ActionResult agregaruser(cAgregarUser au)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(au);
                }
                using(ProyectoBBD2Entities db= new ProyectoBBD2Entities())
                {
                    usuarios us = new usuarios();
                    us.cedula = au.cedula;
                    us.contra = au.contra;
                    us.rol = au.rol;
                    db.usuarios.Add(us);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Usuario agregado correctamente";
                }
                return View(au);
            }
            catch(Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al agregar el usuario " + ex;
                return View(au);
            }
        }
        [HttpGet]
        public ActionResult actualizaruser(int id)
        {
            cActualizarUser au = new cActualizarUser();
            using(ProyectoBBD2Entities db= new ProyectoBBD2Entities())
            {
                var aus = db.usuarios.Find(id);
                au.id = aus.id;
                au.cedula = aus.cedula;
                au.contra = aus.contra;
                au.rol = aus.rol;
            }
            return View(au);
        }
        [HttpPost]
        public ActionResult actualizaruser(cActualizarUser aus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(aus);
                }
                using(ProyectoBBD2Entities db= new ProyectoBBD2Entities())
                {
                    var au = db.usuarios.Find(aus.id);
                    au.cedula = aus.cedula;
                    au.contra = aus.contra;
                    au.rol = aus.rol;
                    db.Entry(au).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Usuario actualizado correctamente";
                }
                return View(aus);
            }catch(Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar el usuario " + ex;
                return View(aus);
            }
        }
        [HttpGet]
        public ActionResult eliminarusuario(int id)
        {
            using(ProyectoBBD2Entities db= new ProyectoBBD2Entities())
            {
                var users = db.usuarios.Find(id);
                db.usuarios.Remove(users);
                db.SaveChanges();
            }
            return RedirectToAction("mantUser", "User");
        }
    }
}