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
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (((Dominio.Usuario)Session["usuario"]).Tipo == Dominio.Usuario.EnumTipo.OPERADOR)
            {
                Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;
                List<Dominio.Cliente> clientes = sis.Clientes;

                Dominio.OrdenarClienteApellidoYNombre ordenarPorApellidoYNombre = new Dominio.OrdenarClienteApellidoYNombre();


                clientes.Sort(ordenarPorApellidoYNombre);
                ViewBag.Clientes = clientes;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
            

            
        }
    }
}