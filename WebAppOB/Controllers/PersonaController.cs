using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOB.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<Dominio.Persona> personas = Dominio.Sistema.InstanciaSistema.Personas;

            ViewBag.Personas = personas;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPersona(Dominio.Persona p)
        {
            

            Dominio.Sistema.InstanciaSistema.Registrarse(p.Nombre, p.Apellido, p.Cedula, p.Password);
           

            List<Dominio.Persona> personas = Dominio.Sistema.InstanciaSistema.Personas;

            ViewBag.Personas = personas;

            return View("Index");
        }
    }
}