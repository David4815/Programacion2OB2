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
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (((Dominio.Usuario)Session["usuario"]).Tipo == Dominio.Usuario.EnumTipo.OPERADOR)
            {
                Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;
                if (sis.Compras.Count == 0)
                {
                    ViewBag.Verifcar = "false";
                }
                else
                {
                    ViewBag.Verificar = "true";
                }


                return View();
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
            
        }

        
    }
}