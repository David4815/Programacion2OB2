using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        #region Variables y Listas
        private static double cotizacionDolar = 43.2;
        private static Sistema instanciaSistema;
        private List<Destino> listaDestinos;
        private List<CompaniaAerea> listaCompaniasAereas;
        private List<Excursion> listaExcursiones;
        private List<Persona> personas;
        private List<Usuario> usuarios;

        



        #endregion

        #region Constructor
        private Sistema()
        {
            this.listaDestinos = new List<Destino>();
            this.listaCompaniasAereas = new List<CompaniaAerea>();
            this.listaExcursiones = new List<Excursion>();
            this.personas = new List<Persona>();
            this.usuarios = new List<Usuario>();
            this.PrecargarDatos();
            this.PrecargarDestinos();
            this.PrecargarExcursiones();
        }
        #endregion

        #region Propiedades
        public List<Destino> ListaDestinos
        {
            get { return listaDestinos; }
            //set { listaDestinos = value; }
        }

        public List<Excursion> ListaExcursiones
        {
            get { return listaExcursiones; }
            //set { listaExcursiones = value; }
        }

        public List<CompaniaAerea> ListaCompaniasAereas
        {
            get { return listaCompaniasAereas; }
            //set { listaCompaniasAereas = value; }
        }



        public static double CotizacionDolar
        {
            get { return cotizacionDolar; }
            set { cotizacionDolar = value; }
        }


        public List<Persona> Personas
        {
            get { return personas; }
            set { personas = value; }
        }

        public List<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        public static Sistema InstanciaSistema
        {

            get
            {
                if (instanciaSistema == null)
                {
                    instanciaSistema = new Sistema();
                }
                return instanciaSistema;
            }

        }

        #endregion

        #region metodos nuevos
        private void PrecargarDatos()
        {
            this.personas.Add(new Persona("rigobertamenchu", "guatemala", Usuario.EnumTipo.OPERADOR,"Rigoberta", "Menchú", 1111111));
            this.personas.Add(new Persona("armandogervaz", "soyeldiosdeort", Usuario.EnumTipo.CLIENTE,"Armando", "Gervaz", 2222222));
            this.personas.Add(new Persona("operador", "oper", Usuario.EnumTipo.OPERADOR,"Gaby", "Renna", 3333333));
            this.personas.Add(new Persona("cliente", "cli", Usuario.EnumTipo.CLIENTE,"Shirley", "Alamon", 4444444));
            

            this.usuarios.Add(new Usuario("rigobertamenchu", "guatemala", Usuario.EnumTipo.OPERADOR));
            this.usuarios.Add(new Usuario("armandogervaz", "soyeldiosdeort", Usuario.EnumTipo.CLIENTE));
            this.usuarios.Add(new Usuario("operador", "oper", Usuario.EnumTipo.OPERADOR));
            this.usuarios.Add(new Usuario("cliente", "cli", Usuario.EnumTipo.CLIENTE));
        }

        public Usuario BuscarUsuario(string username, string password)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Username == username)
                {
                    return (usuario.Password == password) ? usuario : null;
                }
            }
            return null;
        }
        #endregion  

        #region Metodos vijos

        public void AgregarDestino(string ciudad, string pais, int cantidadDias, double costoActualDiario)
        {
            Destino unDestino = new Destino(ciudad, pais, cantidadDias, costoActualDiario);
            listaDestinos.Add(unDestino);
        }

        public void PrecargarDestinos()
        {
            AgregarDestino("Montevideo", "Uruguay", 3, 120);
            AgregarDestino("Canelones", "Uruguay", 3, 120);
            AgregarDestino("Rivera", "Uruguay", 3, 120);
            AgregarDestino("Paysandu", "Uruguay", 3, 120);
            AgregarDestino("Brasilia", "Brasil", 3, 120);
            AgregarDestino("Cuzco", "Peru", 3, 120);
            AgregarDestino("Sucre", "Bolivia", 3, 120);
            AgregarDestino("Santiago de Chile", "Chile", 3, 120);
            AgregarDestino("Hanoi", "Vietnam", 3, 120);
            AgregarDestino("Canberra", "Australia", 3, 120);
        }

        public void AgregarExcursionNacional(string descripcion, DateTime fechaComienzo, int cantidadDias, int stock, bool interesNacional)
        {
            Excursion unaExursion = new ExcursionNacional(descripcion, fechaComienzo, cantidadDias, stock, interesNacional);
            listaExcursiones.Add(unaExursion);
        }

        public void AgregarExcursionInternacional(string descripcion, DateTime fechaComienzo, int cantidadDias, int stock, CompaniaAerea unaCompaniaAerea)
        {
            Excursion unaExursionInternacional = new ExcursionInternacional(descripcion, fechaComienzo, cantidadDias, stock, unaCompaniaAerea);
            listaExcursiones.Add(unaExursionInternacional);
        }
        public void AgregarCompaniaAerea(int codigo, string paisCompania)
        {
            CompaniaAerea unaCompania = new CompaniaAerea(codigo, paisCompania);
            listaCompaniasAereas.Add(unaCompania);
        }
        public void PrecargarExcursiones()
        {
            //Agrego una compania aerea
            AgregarCompaniaAerea(22, "Urguay");
            //CompaniaAerea unaCompaniaAerea = new CompaniaAerea(22, "Urguay");
            CompaniaAerea unaCompaniaAerea = listaCompaniasAereas[0];

            //Agrego excursiones nacionales

            AgregarExcursionNacional("una descripcion", new DateTime(2020, 09, 26), 5, 20, true);
            listaExcursiones[0].ListaDestinosDisponibles.Add(listaDestinos[0]);
            listaExcursiones[0].ListaDestinosDisponibles.Add(listaDestinos[1]);

            AgregarExcursionNacional("una descripcion", new DateTime(2020, 09, 26), 5, 20, true);
            listaExcursiones[1].ListaDestinosDisponibles.Add(listaDestinos[1]);
            listaExcursiones[1].ListaDestinosDisponibles.Add(listaDestinos[2]);
            
            AgregarExcursionNacional("una descripcion", new DateTime(2020, 09, 26), 5, 20, true);
            listaExcursiones[2].ListaDestinosDisponibles.Add(listaDestinos[0]);
            listaExcursiones[2].ListaDestinosDisponibles.Add(listaDestinos[2]);
            
            AgregarExcursionNacional("una descripcion", new DateTime(2020, 09, 26), 5, 20, true);
            listaExcursiones[3].ListaDestinosDisponibles.Add(listaDestinos[1]);
            listaExcursiones[3].ListaDestinosDisponibles.Add(listaDestinos[3]);

            //Agrego excursiones internacionales

            AgregarExcursionInternacional("una descripcion", new DateTime(2020, 09, 26), 5, 20, unaCompaniaAerea);
            listaExcursiones[4].ListaDestinosDisponibles.Add(listaDestinos[7]);
            listaExcursiones[4].ListaDestinosDisponibles.Add(listaDestinos[8]);

            AgregarExcursionInternacional("una descripcion", new DateTime(2020, 09, 20), 5, 20, unaCompaniaAerea);
            listaExcursiones[5].ListaDestinosDisponibles.Add(listaDestinos[9]);
            listaExcursiones[5].ListaDestinosDisponibles.Add(listaDestinos[4]);
            AgregarExcursionInternacional("una descripcion", new DateTime(2020, 09, 26), 5, 20, unaCompaniaAerea);
            listaExcursiones[6].ListaDestinosDisponibles.Add(listaDestinos[8]);
            listaExcursiones[6].ListaDestinosDisponibles.Add(listaDestinos[5]);
            AgregarExcursionInternacional("una descripcion", new DateTime(2020, 09, 26), 5, 20, unaCompaniaAerea);
            listaExcursiones[7].ListaDestinosDisponibles.Add(listaDestinos[7]);
            listaExcursiones[7].ListaDestinosDisponibles.Add(listaDestinos[6]);

            
          

        }

        //podria hacer un metodo que devuelva un lista de las excursiones que esten entre esas dos fechas asi no tiene consolewr
        public  List<Excursion> ExcursionesEntre(int unCodigoDestino, DateTime inicio, DateTime fin)
        {
            List<Excursion> listaBuscada = new List<Excursion>();

            foreach (Excursion i in listaExcursiones)
            {
                if (i.FechaComienzo >= inicio && i.FechaComienzo <= fin)
                {

                    foreach (Destino j in i.ListaDestinosDisponibles)
                    {

                        if (unCodigoDestino - 1 == listaDestinos.IndexOf(j))
                        {
                            listaBuscada.Add(i);
                        }
                    }

                }

            }

            return listaBuscada;
        }
        #endregion








    }
}
