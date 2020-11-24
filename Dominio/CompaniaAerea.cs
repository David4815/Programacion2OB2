using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompaniaAerea
    {

        #region Variables
        private int codigo;
        private string pais;
        #endregion

        #region Constructor
        public CompaniaAerea(int codigo, string pais)
        {
            this.codigo = codigo;
            this.pais = pais;
        }
        #endregion



        #region Propiedades
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        #endregion


        public override string ToString()
        {
            return $"codigo: {codigo}, Pais origen de la compania: {pais}";
        }
    }
}
