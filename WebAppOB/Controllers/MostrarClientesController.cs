using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class MostrarClientesController : Controller
    {
        // GET: MostrarClientes
        public ActionResult Index()
        {

            Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;
            List<Dominio.Cliente> clientes = sis.Clientes;
            ViewBag.Clientes = clientes;

            return View();
        }
    }
}