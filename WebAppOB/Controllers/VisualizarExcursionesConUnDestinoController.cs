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
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (((Dominio.Usuario)Session["usuario"]).Tipo == Dominio.Usuario.EnumTipo.OPERADOR)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }

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
            excursionesBuscadas.Sort();
            ViewBag.ExcursionesBuscadas = excursionesBuscadas;
            return View("Index");
        }
    }
}