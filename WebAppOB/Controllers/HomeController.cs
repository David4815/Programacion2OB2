using System;
//Vinculo el dominio
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;
             List<Excursion> excursiones =  sis.ListaExcursiones;
            ViewBag.Excursiones = excursiones;
            return View();
        }
    }
}