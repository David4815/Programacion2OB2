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
            else if(((Dominio.Usuario)Session["usuario"]).Tipo == Dominio.Usuario.EnumTipo.CLIENTE)
            {

            
            Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;

            Dominio.Usuario u = sis.BuscarUsuario(((Dominio.Usuario)Session["usuario"]).Username, ((Dominio.Usuario)Session["usuario"]).Password);
            Dominio.Cliente cli = sis.BuscarCliente(u);
            ViewBag.Compras = cli.Compras;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        //public ActionResult VisualizarCompras()
        //{
        //    if (Session["usuario"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //}
        public ActionResult CancelarCompraCliente(int codigoCompra)
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Dominio.Sistema sis = Dominio.Sistema.InstanciaSistema;

            Dominio.Usuario u = sis.BuscarUsuario(((Dominio.Usuario)Session["usuario"]).Username, ((Dominio.Usuario)Session["usuario"]).Password);
            Dominio.Cliente cli = sis.BuscarCliente(u);

            List<Dominio.Compra> comprasAuxiliaresCli = new List<Dominio.Compra>();
            List<Dominio.Compra> comprasAuxiliaresSis = new List<Dominio.Compra>();
            foreach(Dominio.Compra comp in cli.Compras)
            {
                if(comp.Codigo == codigoCompra)
                {
                    DateTime fecha = DateTime.Today.AddDays(-10);
                    if( fecha > comp.UnaExcursion.FechaComienzo)
                    {
                        //eliminar compra de lista de compras de cliente
                        foreach (Dominio.Compra c in cli.Compras)
                        {
                            if (c.Codigo != codigoCompra)
                            {
                                comprasAuxiliaresCli.Add(c);
                            }
                        }

                        // eliminar la compra en la lista de compras general.
                        foreach (Dominio.Compra c in sis.Compras)
                        {
                            if (c.Codigo != codigoCompra)
                            {
                                comprasAuxiliaresSis.Add(c);
                            }
                        }


                        //ajuste de stock
                        foreach (Dominio.Compra c in sis.Compras)
                        {
                            if (c.Codigo == codigoCompra)
                            {
                                foreach (Dominio.Excursion e in sis.ListaExcursiones)
                                {
                                    if (e.Codigo == c.UnaExcursion.Codigo)
                                    {
                                        e.Stock += c.CantidadPasajeros;
                                    }
                                }

                            }
                        }

                        cli.Compras = comprasAuxiliaresCli;
                        sis.Compras = comprasAuxiliaresSis;


                        ViewBag.Compras = cli.Compras;

                        
                    } else
                    {
                        ViewBag.Compras = cli.Compras;
                        ViewBag.error = "Solo se puede cancelar compra hasta 10 dias antes de la fecha de la excursion";
                    }
                }
               
            }
            return View("Index");
        }
           
    }
}

