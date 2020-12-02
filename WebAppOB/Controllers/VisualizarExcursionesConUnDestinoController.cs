using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class VisualizarExcursionesConUnDestinoController : Controller
    {
        // GET: VisualizarExcursionesConUnDestino
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExcConUnDestino(string slcDestino)
        {
            Sistema sis = Sistema.InstanciaSistema;
            List<Excursion> excursionesBuscadas = new List<Excursion>();
            foreach(Excursion e in sis.ListaExcursiones)
            {
                foreach(Destino d in e.ListaDestinosDisponibles)
                {
                    if(d.Ciudad== slcDestino)
                    {
                        excursionesBuscadas.Add(e);
                    }
                }
            }

            ViewBag.ExcursionesBuscadas = excursionesBuscadas;
            return View("Index");
        }
    }
}