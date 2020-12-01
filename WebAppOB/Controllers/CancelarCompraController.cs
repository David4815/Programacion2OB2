using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class CancelarCompraController : Controller
    {
        // GET: CancelarCompra
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult VisualizarCompras()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;

            Dominio.Usuario u = sis.BuscarUsuario(((Dominio.Usuario)Session["usuario"]).Username, ((Dominio.Usuario)Session["usuario"]).Password);
            ViewBag.Compras = u.Compras;
            return View("Index");
        }
        //public ActionResult CancelarCompraCliente(int codigoExcursion)
        //{
        //    if (Session["usuario"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;
        //    Sistema.Instancia.BorrarPersona(idPersona);

        //    List<Persona> personas = Sistema.Instancia.Personas;

        //    ViewBag.Personas = personas;

        //    return View("Index");
        }
    }
}