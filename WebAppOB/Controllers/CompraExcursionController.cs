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

        public ActionResult ComprarExcursion(int codigoExcursion, string txtCantPasajerosMayores, string txtCantPasajerosMenores)
        {

            int cantidadPasajerosTotal = int.Parse(txtCantPasajerosMayores) + int.Parse(txtCantPasajerosMenores);
            bool hayStock = false;

            Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;

            Dominio.Excursion e = sis.BuscarExcursion(codigoExcursion);
            

            if(e.Stock >= cantidadPasajerosTotal)
            {
                hayStock = true;
            }
            if (hayStock)
            {
                Dominio.Compra unaCompra = new Dominio.Compra(e, cantidadPasajerosTotal);
                sis.Compras.Add(unaCompra);
                sis.BuscarCliente(sis.BuscarUsuario(((Dominio.Usuario)Session["usuario"]).Username, ((Dominio.Usuario)Session["usuario"]).Password)).Compras.Add(unaCompra);
                e.Stock -= cantidadPasajerosTotal;
                ViewBag.ErrMsg = "Compra exitosa";
            }
            else
            {
                ViewBag.ErrMsg = "No hay stock suficiente";
            }

            ViewBag.Excursion = e;
            return View("Index");
        }
    }
}