using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class FunAux
    {
        #region DUDAS
        //----------------------------------------------------------------------------------------

        //Al ingresar destino, ciudad y pais hay que controlar que no tengan numeros? existen ciudades con numeros en su nombre
        //instacia de la clase sistemas afuera del metodo main
        //las companias aereas son una lista que esta en sistema o creo una sola
        //los set y get de objetos y listas como son
        //FALTA CONTROLAR QUE EN LAS EXCURSIONES INTERNACIONALE NO SE PUEDA ELEJIR A URUGUAY
            


        //----------------------------------------------------------------------------------------
        #endregion

        //Pedir un numero que sea mayor a un minimo
        public static int PedirNumeroMayor(string msg, string errMsg, int min)
        {
            bool exito;
            int num;
            do
            {
                Console.WriteLine(msg);
                string strNum = Console.ReadLine();
                exito = int.TryParse(strNum, out num) && num > min;
                if (!exito)
                    Console.WriteLine(errMsg);
            } while (!exito);
            return num;

        }

        //Pedir un numero que sea mayor a un minimo con decimales
        public static double PedirNumeroDoubleMayor(string msg, string errMsg, int min)
        {
            bool exito;
            double num;
            do
            {
                Console.WriteLine(msg);
                string strNum = Console.ReadLine();
                exito = double.TryParse(strNum, out num) && num > min;
                if (!exito)
                    Console.WriteLine(errMsg);
            } while (!exito);
            return num;

        }
        //Pedir un texto que sea mayor a un minimo
        public static string PedirTextoMayor(string msg, string errMsg, int min)
        {
            bool exito;
            string str;
            do
            {
                Console.WriteLine(msg);
                 str = Console.ReadLine();
                exito =  str.Length >= min;
                if (!exito)
                    Console.WriteLine(errMsg);
            } while (!exito);

            return str;

        }

        //Pedir un numero que este entre otros dos
        public static int PedirNumero(string msg, string errMsg, int min, int max)
        {
            bool exito;
            int num;
            do
            {
                Console.WriteLine(msg);
                string strNum = Console.ReadLine();
                exito = int.TryParse(strNum, out num) && num >= min && num <= max;
                if (!exito)
                    Console.WriteLine(errMsg);
            } while (!exito);
            return num;

        }

        //Pedir una fecha en formato dia/mes/año
        public static DateTime PedirFecha(string msg, string errMsg)
        {
            bool exito;
            DateTime fecha;
            do
            {
                Console.WriteLine(msg);
                string strNum = Console.ReadLine();
                exito = DateTime.TryParseExact(strNum,"dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha);
                if (!exito)
                    Console.WriteLine(errMsg);
            } while (!exito);
            return fecha;

        }
    }
}
