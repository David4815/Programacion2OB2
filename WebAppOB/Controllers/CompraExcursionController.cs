using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class CompraExcursionController : Controller
    {
        // GET: CompraExcursion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizarExcursion(int codigoExcursion)
        {
            Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;

            Dominio.Excursion e = sis.BuscarExcursion(codigoExcursion);

            

            ViewBag.Excursion = e;

            return View("Index", e);
        }
    }
}