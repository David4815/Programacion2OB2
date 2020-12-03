using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class DestinoMasVisitadoController : Controller
    {
        // GET: DestinoMasVisitado
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

        public ActionResult DestMasVisitados()
        {
            List<Destino> destinosBuscados = new List<Destino>();
            List<int> posiciones = new List<int>();
            List<int> posBuscadas = new List<int>();
           

            Sistema sis = Sistema.InstanciaSistema;

            foreach (Destino destinosPrueba in sis.ListaDestinos)
            {
                posiciones.Add(0);
            }

                foreach (Destino d in sis.ListaDestinos)
            {
                foreach (Excursion e in sis.ListaExcursiones)
                {
                    foreach(Destino des in e.ListaDestinosDisponibles)
                    {
                        if (des.Ciudad == d.Ciudad)
                        {
                            sis.ListaDestinos.IndexOf(d);
                            posiciones[sis.ListaDestinos.IndexOf(d)]++;
                        }
                    }
                }
            }

            int max = 0;
            foreach(int numero in posiciones)
            {
                if (numero > max)
                {
                    max = numero;
                }
            }

            foreach(int num in posiciones)
            {
                if (num == max)
                {
                    foreach(Destino d in sis.ListaDestinos)
                    {
                        if (sis.ListaDestinos.IndexOf(d) == posiciones.IndexOf(num))
                        {
                            destinosBuscados.Add(d);
                        }
                    }
                }
            }

            ViewBag.DestinosBuscados = destinosBuscados;
            return View("Index");
        }
    }
}