using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Persona : Dominio.Usuario
	{
		private int id;
		private static int ultId = 1;

		private string nombre;
		private string apellido;
		private string cedula;
        

       


        #region Properties
        public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}

		public string Cedula
		{
			get { return cedula; }
			set { cedula = value; }
		}
		public int Id
		{
			get { return id; }
			set { id = value; }
		}
	
		#endregion
		public Persona()
		{

		}
		public Persona(string username, string password, EnumTipo tipo, string nombre, string apellido, string cedula): base(username,password,tipo)
		{
			
			this.nombre = nombre;
			this.apellido = apellido;
			this.cedula = cedula;
			
			this.id = ultId++;
		}

	}
}
