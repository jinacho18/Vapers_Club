using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vapers_Club.Models;
using Vapers_Club.Models.ViewModels;

namespace Vapers_Club.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpGet]
        public ActionResult Ingresa()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Ingresar(cLogin login)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            using (BaseDatosEntities1 db = new BaseDatosEntities1())
            {
                var existenciaUsuario = db.usuarios.Where(p => p.cedula == login.userusuario && p.contra == login.ctrUsuario).FirstOrDefault();

                if (existenciaUsuario != null)
                {
                    if (existenciaUsuario.rol == 1)
                    {
                        Session["ROL"] = "Administrador";
                        Session.Timeout = 45;
                        return RedirectToAction("Menu", "Home");
                    }
                    else
                    {
                        ViewBag.ValorMensaje = 0;
                        ViewBag.MensajeProceso = "Usuario no es ADMINISTRADOR";
                        return View("Login");
                    }
                }
                else
                {
                    ViewBag.ValorMensaje = 0;
                    ViewBag.MensajeProceso = "Usuario no existe";
                    return View("Login");
                }

            }
        }
    }
}