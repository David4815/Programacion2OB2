using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (((Dominio.Usuario)Session["usuario"]).Tipo == Dominio.Usuario.EnumTipo.CLIENTE)
            {
                Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;
                List<Excursion> excursiones = sis.ListaExcursiones;
                ViewBag.Excursiones = excursiones;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}