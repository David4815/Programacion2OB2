using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ExcursionInternacional : Excursion
    {
        #region Variables
        private CompaniaAerea companiaAerea;
        #endregion


        
        #region Constructor       
        public ExcursionInternacional(string descripcion, DateTime fehcaComienzo, int cantidadDias, int stock, CompaniaAerea companiaAerea) : base(descripcion, fehcaComienzo, cantidadDias, stock)
        {
            this.companiaAerea = companiaAerea;
        }
        #endregion

        #region Propiedades
        public CompaniaAerea CompaniaAerea
        {
            get { return companiaAerea; }
            set { companiaAerea = value; }
        }
        #endregion 

        public override string ToString()
        {

            return base.ToString() + $"\nCompania aerea: {CompaniaAerea}";
        }
    }
}
