using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        private Excursion unaExcursion;
        private int cantidadPasajeros;

        

        public Excursion UnaExcursion
        {
            get { return unaExcursion; }
            set { unaExcursion = value; }
        }


        public int CantidadPasajeros
        {
            get { return cantidadPasajeros; }
            set { cantidadPasajeros = value; }
        }

        public Compra(Excursion unaExcursion, int cantidadPasajeros)
        {
            this.unaExcursion = unaExcursion;
            this.cantidadPasajeros = cantidadPasajeros;
        }

    }
}
