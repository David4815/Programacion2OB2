using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class ClienteRegistroController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<Dominio.Cliente> clientes = Dominio.Sistema.InstanciaSistema.Clientes;

            ViewBag.Clientes = clientes;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(Dominio.Cliente cli)
        {
            

            Dominio.Sistema.InstanciaSistema.Registrarse(cli.Nombre, cli.Apellido, cli.Cedula, cli.Password);
           

            List<Dominio.Cliente> clientes = Dominio.Sistema.InstanciaSistema.Clientes;

            ViewBag.Clientes = clientes;

            return View("Index");
        }
    }
}