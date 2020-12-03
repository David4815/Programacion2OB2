using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class VerComprasEntreFechasController : Controller
    {
        // GET: VerComprasEntreFechas
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
        public ActionResult CompEntreFechas(string fechaInicio, string fechaFin)
        {

            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (((Dominio.Usuario)Session["usuario"]).Tipo == Dominio.Usuario.EnumTipo.OPERADOR)
            {
                DateTime inicioVerifcado;
                bool exito = DateTime.TryParseExact(fechaInicio, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out inicioVerifcado);
                DateTime finVerifcado;
                bool exito2 = DateTime.TryParseExact(fechaFin, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out finVerifcado);
                Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;

                List<Dominio.Compra> listaBuscada = new List<Dominio.Compra>();

                foreach (Dominio.Compra c in sis.Compras)
                {
                    if (c.UnaExcursion.FechaComienzo >= inicioVerifcado && c.UnaExcursion.FechaComienzo <= finVerifcado)
                    {

                        listaBuscada.Add(c);

                    }

                }

                ViewBag.ComprasBuscadas = listaBuscada;
                ViewBag.FechaInicio = inicioVerifcado;
                ViewBag.FechaFin = finVerifcado;



                return View("Index");
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }

            
        }
    }
}