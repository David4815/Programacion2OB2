using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ExcursionNacional : Excursion
    {

        #region Variables
        private bool interesNacional;
        #endregion

        #region Constructor
        public ExcursionNacional(string descripcion, DateTime fehcaComienzo, int cantidadDias, int stock, bool interesNacional):base(descripcion,fehcaComienzo,cantidadDias,stock)
        {
            this.interesNacional = interesNacional;
            
        }
        #endregion

        #region Propiedades
        public bool InteresNacional
        {
            get { return interesNacional; }
            set { interesNacional = value; }
        }
        #endregion

        public override string ToString()
        {
            string esDeInteresNacional = "No";
            if (interesNacional)
            {
                esDeInteresNacional = "Si";
            }
            return base.ToString() + $", {esDeInteresNacional} es de interes nacional";
        }

        public override double PrimaSegunTipo()
        {
           //revisar hora en fechas
            double prima = 1;
            if (this.fehcaComienzo >= new DateTime(2020, 03, 01) && this.fehcaComienzo <= new DateTime(2020, 08, 31) )
            {
                //descuennto de un 10%
                prima = 0.9; 
            }
            return prima;
        }
    }
}
