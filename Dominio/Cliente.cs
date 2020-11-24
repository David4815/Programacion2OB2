using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Cliente
	{
		private int id;
		private static int ultId = 1;

		private string nombre;
		private string apellido;
		private int cedula;
		private

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

		public int Cedula
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
		public Cliente()
		{

		}
		public Cliente(string nombre, string apellido, int cedula)
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.cedula = cedula;
			this.id = ultId++;
		}

	}
}
