using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class VisualizarEstadisticasController : Controller
    {
        // GET: VisualizarEstadisticas
        public ActionResult Index()
        {

            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (((Dominio.Usuario)Session["usuario"]).Tipo == Dominio.Usuario.EnumTipo.OPERADOR)
            {
                Sistema sis = Sistema.InstanciaSistema;
                List<Destino> destinos = sis.ListaDestinos;
                ViewBag.DestinosSistema = destinos;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
            

            
        }
    }
}