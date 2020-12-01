using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class ComprasEntreFechasController : Controller
    {
        // GET: ComprasEntreFechas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComprasEntreFechas(DateTime inicio, DateTime fin)
        {
            Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;

            List<Dominio.Compra> listaBuscada = new List<Dominio.Compra>();

                foreach (Dominio.Compra c in sis.Compras)
                {
                    if (c.UnaExcursion.FechaComienzo >= inicio && c.UnaExcursion.FechaComienzo <= fin)
                    {

                    listaBuscada.Add(c);

                    }

                }

                
            

            return View("Index");
        }
    }
}