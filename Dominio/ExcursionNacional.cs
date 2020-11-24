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
    }
}
