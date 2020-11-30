using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Excursion
    {

        protected static int ultimoCodigo = 1000;
        protected int codigo;
        protected string descripcion;
        protected DateTime fehcaComienzo;
        protected int cantidadDias;
        protected int stock;
        protected List<Destino> listaDestinosDisponibles;



        public Excursion(string descripcion, DateTime fehcaComienzo, int cantidadDias, int stock)
        {
            this.codigo = ultimoCodigo;
            this.descripcion = descripcion;
            this.fehcaComienzo = fehcaComienzo;
            this.cantidadDias = cantidadDias;
            this.stock = stock;
            this.listaDestinosDisponibles = new List<Destino>();
            ultimoCodigo+=100;
        }

        #region Propiedades 
        
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }


        public DateTime FechaComienzo
        {
            get { return fehcaComienzo; }
            set { fehcaComienzo = value; }
        }


        public int CantidadDias
        {
            get { return cantidadDias; }
            set { cantidadDias = value; }
        }
     


        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public List<Destino> ListaDestinosDisponibles
        {
            get { return listaDestinosDisponibles; }
            //set { destinosDisponibles = value; }
        }
        #endregion

        public override string ToString()
        {
            //calculo costo total
            double costoTotal=0;
            string destinosDisponibles = "";
            foreach (Destino i in this.ListaDestinosDisponibles)
            {
                costoTotal += (i.CantidadDias * i.CostoActualDiario);
            }
            //Muestro todos los destinos
            foreach (Destino i in this.ListaDestinosDisponibles)
            {
                destinosDisponibles += $"{i.Ciudad}, {i.Pais}; ";

            }
           

            return $"Codigo: {codigo}, Desscripcion: {descripcion}, Fecha comienzo: {fehcaComienzo}, Cantidad de dias: {cantidadDias}, Stock: {stock}, Costo total(dolares): {costoTotal}, Costo total(pesos): {costoTotal * Sistema.CotizacionDolar}, Destinos : {destinosDisponibles} ";
        }

        public abstract double PrimaSegunTipo();

        public double Costo()
        {
            double costoTotal = 0;

            foreach (Destino i in this.ListaDestinosDisponibles)
            {
                costoTotal += (i.CantidadDias * i.CostoActualDiario);
            }
            return costoTotal;
        }

    }
}
