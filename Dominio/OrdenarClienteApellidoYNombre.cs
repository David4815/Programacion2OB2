using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class OrdenarClienteApellidoYNombre : IComparer<Cliente>
    {
        #region  Miembros de IComparer<Cliente>

        //public
        //int Compare(Cliente x, Cliente y)
        //{
        //    return x.Apellido.CompareTo(y.Apellido);
        //}
        #endregion

        public int Compare(Cliente x, Cliente y)
        {
            int ComparaPersona = string.Compare(x.Apellido, y.Apellido);
            if (ComparaPersona == 0)
                ComparaPersona = string.Compare(x.Nombre, y.Nombre);
            return ComparaPersona;
        }
    }
}
