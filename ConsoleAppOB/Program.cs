using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOB
{
    class Program
    {
        private static Sistema sistemaPrincipal = Sistema.InstanciaSistema;
        static void Main(string[] args)
        {

            sistemaPrincipal.PrecargarDestinos();
            sistemaPrincipal.PrecargarExcursiones();
            #region Menu Principal

            bool sigo = true;
            do
            {
                Console.WriteLine("\n*****************************************************************************************");
                Console.WriteLine("*                                 MENU PRINCIPAL                                        *");
                Console.WriteLine("*****************************************************************************************\n");
                Console.WriteLine("         1 - Ingresar un destino");
                Console.WriteLine("         2 - Visualizar todos los destinos disponibles");
                Console.WriteLine("         3 - Modificar la cotizacion del dolar");
                Console.WriteLine("         4 - Registrar excursiones(precargadas)");
                Console.WriteLine("         5 - Listar todas las excursiones ingresadas");
                Console.WriteLine("         6 - Listar excursiones que vayan a un destino dado entre dos fechas");
                Console.WriteLine("         7 - Salir\n");

                int numero = FunAux.PedirNumero("Seleccione una opcion", "ingreso incorrecto", 1, 7);

                switch (numero)
                {
                    case 1:
                        IngresarDestino();
                        break;

                    case 2:
                        MostrarDestino();
                        break;

                    case 3:
                        ModificarCotizacionDolar();

                        break;
                    case 4:
                        Console.WriteLine("Registrar excursiones (precargadas)");
                        break;

                    case 5:
                        MostrarExcursiones();
                        break;

                    case 6:
                        MostrarExcursionesEntre();
                     break;

                    case 7:
                        Console.WriteLine("Salir");
                        sigo = false;
                        break;


                }
            } while (sigo);
            #endregion
        }

        #region Metodos
        public static void IngresarDestino()
        {
            Console.WriteLine("\nINGRESO DE DESTINO:\n");

            string ciudad = FunAux.PedirTextoMayor("Ingrese una ciudad", "Al menos tres caracteres requeridos", 3);

            string pais = FunAux.PedirTextoMayor("\nIngrese un pais", "Al menos tres caracteres requeridos", 3);

            foreach (Destino i in sistemaPrincipal.ListaDestinos)
            {
                if (i.Ciudad == ciudad && i.Pais == pais)
                {
                    Console.WriteLine("\nEl destino ingresado ya existe\n");
                    return;
                }
            }
            int cantidadDias = FunAux.PedirNumeroMayor("\nIngrese cantidad de dias en el distino", "Ingrese un numero mayor a cero", 0);

            double costoActual = FunAux.PedirNumeroDoubleMayor("\nIngrese costo actual diario", "Ingrese un numero mayor a cero", 0);

            sistemaPrincipal.AgregarDestino(ciudad, pais, cantidadDias, costoActual);

            Console.WriteLine("\nDestino ingresado correctamente\n");
            Console.WriteLine($"Destio ingresado: \n\n{sistemaPrincipal.ListaDestinos.Last()}\n");



        }
        public static void MostrarDestino()
        {
            Console.WriteLine("\nListado de Destinos:");

            if (sistemaPrincipal.ListaDestinos.Count == 0)
            {
                Console.WriteLine("\nNo hay destinos ingresados");
            }
            else
            {
                foreach (Destino i in sistemaPrincipal.ListaDestinos)
                {
                    Console.WriteLine($"\n{sistemaPrincipal.ListaDestinos.IndexOf(i) + 1} - {i}");
                }
            }
        }

        public static void MostrarExcursiones()
        {
            Console.WriteLine("\nListado de Excursiones:");

            if (sistemaPrincipal.ListaExcursiones.Count == 0)
            {
                Console.WriteLine("\nNo hay excursiones ingresadas");
            }
            else
            {
                foreach (Excursion i in sistemaPrincipal.ListaExcursiones)
                {
                    Console.WriteLine($"\n{i}");
                }
            }

        }

       

        public static void MostrarExcursionesEntre()
        {
            MostrarDestino();
            DateTime inicio = FunAux.PedirFecha("\nIngrese fecha inicio(dd/mm/aaaa): ", "\nFormato incorrecto, ingrese la fecha en formato dd/mm/aaaa");
            DateTime fin = FunAux.PedirFecha("\nIngrese fecha fin(dd/mm/aaaa): ", "\nFormato incorrecto, ingrese la fecha en formato dd/mm/aaaa");
            int numeroDestino = FunAux.PedirNumero("\nSeleccione un numero destino de los listados anteriormente", "Numero de destino seleccion no existe. Ingrese un destino de los listados anteriormente.", 1, 10);
            List<Excursion> listaBuscada = sistemaPrincipal.ExcursionesEntre(numeroDestino, inicio, fin);
            
            if (listaBuscada.Count == 0)
            {
                Console.WriteLine($"\nNo hay excursiones entre la fecha {inicio} y la fecha {fin}\n");
            }
            else
            {
                foreach (Excursion i in listaBuscada)
                {
                    Console.WriteLine($"\n{i}\n");
                }

            }

        }

        public static void ModificarCotizacionDolar()
        {
            Console.WriteLine($"\nLa cotizacion actual del dolar es de: {Sistema.CotizacionDolar} pesos");
            double nuevaCotizacion = FunAux.PedirNumeroDoubleMayor("\nIngrese nuevo valor del dolar:\n", "\nIngrese un numero mayor a cero\n", 0);
            Sistema.CotizacionDolar = nuevaCotizacion;

            Console.WriteLine($"\nCotizacion actualizada, el nuevo valor del dolar es de {nuevaCotizacion} pesos\n");
        }

        #endregion

    }
}
