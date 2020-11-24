using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PerformLogin(Usuario u)
        {
            Usuario usu = Sistema.InstanciaSistema.BuscarUsuario(u.Username, u.Password);

            if (usu == null)
            {
                ViewBag.ErrMsg = "No existe un usuario con dichas credenciales.";
                return View("Index");
            }
            else
            {
                Session["usuario"] = usu;
                if (usu.Tipo == Usuario.EnumTipo.CLIENTE) { 
                    return RedirectToAction("Index", "Home");
                }
                //si es operador
                else 
                {
                    return RedirectToAction("Index", "Home");
                }
              
                    
            }
        }

        public ActionResult LogOut()
        {
            Session["usuario"] = null;
            return View("Index");
        }
    }
}